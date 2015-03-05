using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.SpeechSynthesis;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Caliburn.Micro;
using ScaryStoriesUniversal.Api;
using ScaryStoriesUniversal.Api.Entities;
using ScaryStoriesUniversal.Database.Entities;
using ScaryStoriesUniversal.Database.Repositories.Base;
using ScaryStoriesUniversal.Helpers;
using ScaryStoriesUniversal.Services;
using ScaryStoriesUniversal.Services.Settings;
using ScaryStoriesUniversal.ViewModels.Base;
using Story = ScaryStoriesUniversal.Api.Entities.Story;

namespace ScaryStoriesUniversal.ViewModels
{
    public class StoryViewModel:LoadingScreen
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private readonly StoryListIdsContainer _idsContainer;
        private readonly IMessageProvider _messageProvider;
        private readonly IFavoriteStoriesRepository _favoriteStoriesRepository;
        private Story _story;
        private Photo _photo;
        private Visibility _toFavoriteButtonVisible=Visibility.Collapsed;
        private Visibility _deleteFromFavoriteButtonVisible=Visibility.Collapsed;
        private TextInfoSettings _textSettings;
        private FontFamily _currentFont;
        private MediaElement _speechPlayer;
        private Visibility _playButtonVisibility=Visibility.Visible;
        private Visibility _stopButtonVisibility=Visibility.Collapsed;

        public Story Story
        {
            get { return _story; }
            set
            {
                _story = value;
                base.NotifyOfPropertyChange(()=>Story);
            }
        }

        public Photo Photo
        {
            get { return _photo; }
            set
            {
                _photo = value;
                base.NotifyOfPropertyChange(()=>Photo);
            }
        }

        public FontFamily CurrentFont
        {
            get { return _currentFont; }
            set
            {
                _currentFont = value;
                base.NotifyOfPropertyChange(()=>CurrentFont);
            }
        }

        public StoryViewModel(INavigationService navigationService,IApiService apiService,StoryListIdsContainer idsContainer,IMessageProvider messageProvider,IFavoriteStoriesRepository favoriteStoriesRepository,ISettingsProvider settingsProvider)
            :base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            _idsContainer = idsContainer;
            _messageProvider = messageProvider;
            _favoriteStoriesRepository = favoriteStoriesRepository;
            TextSettings=settingsProvider.TextSettings;
            CurrentFont = new FontFamily(TextSettings.Font);
            _speechPlayer=new MediaElement();
            _navigationService.Navigating += _navigationService_Navigating;
        }

        void _navigationService_Navigating(object sender, Windows.UI.Xaml.Navigation.NavigatingCancelEventArgs e)
        {
                StopPlaying();
        }

        public async void WebNavigateToUrl()
        {
            if (!String.IsNullOrEmpty(Story.Url))
            {
                var success = await Windows.System.Launcher.LaunchUriAsync(new Uri(Story.Url));
            }
        }

        public void NavigateToSettings()
        {
            _navigationService.UriFor<SettingsViewModel>().Navigate();
        }

        public async void Back()
        {
            StopPlaying();
           await GetStoryById(_idsContainer.Back());
        }

        public bool CanBack
        {
            get { return _idsContainer.CanBack(); }
        }

        public bool CanNext
        {
            get
            {
                return _idsContainer.CanNext();
            }
        }

        public Visibility ToFavoriteButtonVisible
        {
            get { return _toFavoriteButtonVisible; }
            set
            {
                _toFavoriteButtonVisible = value;
                base.NotifyOfPropertyChange(()=>ToFavoriteButtonVisible);
            }
        }

        public Visibility DeleteFromFavoriteButtonVisible
        {
            get { return _deleteFromFavoriteButtonVisible; }
            set
            {
                _deleteFromFavoriteButtonVisible = value;
                base.NotifyOfPropertyChange(() => DeleteFromFavoriteButtonVisible);
            }
        }

        public TextInfoSettings TextSettings
        {
            get { return _textSettings; }
            set
            {
                _textSettings = value;
                base.NotifyOfPropertyChange(()=>TextSettings);
            }
        }

        public Visibility PlayButtonVisibility
        {
            get { return _playButtonVisibility; }
            set
            {
                _playButtonVisibility = value;
                base.NotifyOfPropertyChange(()=>PlayButtonVisibility);
            }
        }

        public Visibility StopButtonVisibility
        {
            get { return _stopButtonVisibility; }
            set
            {
                _stopButtonVisibility = value;
                base.NotifyOfPropertyChange(()=>StopButtonVisibility);
            }
        }


        public async void Next()
        {
            StopPlaying();
            await GetStoryById(_idsContainer.Next());
        }

        private void StopPlaying()
        {
            _speechPlayer.Stop();
            StopButtonVisibility = Visibility.Collapsed;
            PlayButtonVisibility = Visibility.Visible;
        }

        public async void ToFavorite()
        {
            await _favoriteStoriesRepository.InsertAsync(new FavoriteStory(){CreatedAt = Story.CreatedAt,Id = Story.Id,Name = Story.Name,Thumb = Photo.Thumb});
            IsFavoriteVisible();
        }

        public async void DeleteFromFavorite()
        {
            await _favoriteStoriesRepository.DeleteAsync(Story.Id.ToString());
            IsUnfavoriteVisible();
        }

        public async void Synthese()
        {
            if (_speechPlayer.CurrentState == MediaElementState.Paused)
            {
                _speechPlayer.Play();
                StopButtonVisibility = Visibility.Visible;
                PlayButtonVisibility = Visibility.Collapsed;
            }
            else
            {
                var synth = new Windows.Media.SpeechSynthesis.SpeechSynthesizer();
                var stream = await synth.SynthesizeTextToStreamAsync(Story.Text);
                _speechPlayer.SetSource(stream, stream.ContentType);
                _speechPlayer.Play();
                PlayButtonVisibility=Visibility.Collapsed;
                StopButtonVisibility = Visibility.Visible; 
            }
          
        }

        public async void StopSynthese()
        {
            _speechPlayer.Pause();
             PlayButtonVisibility=Visibility.Visible;
            StopButtonVisibility = Visibility.Collapsed;
        }

        protected async override void OnViewReady(object view)
        {
            var currentId = _idsContainer.GetCurrentStoryId();
            await GetStoryById(currentId);
        }

        private async Task GetStoryById(string currentId)
        {
            base.Wait(true);
            Story = await _apiService.GetStory(currentId);
            base.Wait(false);
            Photo = await _apiService.GetPhoto(Story.PhotoId);
           
           await RefreshAppBarButtons();
        }

        public  void ImageTap()
        {
           _navigationService.UriFor<PhotoViewModel>().WithParam(x=>x.PhotoId,_photo.Id).Navigate();
        }

        private async Task RefreshAppBarButtons()
        {
            base.NotifyOfPropertyChange(() => CanBack);
            base.NotifyOfPropertyChange(() => CanNext);
            var isFavorite=await _favoriteStoriesRepository.CheckIsFavorite(Story.Id.ToString());
            if (isFavorite)
            {
                IsFavoriteVisible();
            }
            else
            {
                IsUnfavoriteVisible();
            }
            PlayButtonVisibility = Visibility.Visible;
            StopButtonVisibility = Visibility.Collapsed;
        }

        private void IsUnfavoriteVisible()
        {
            DeleteFromFavoriteButtonVisible = Visibility.Collapsed;
            ToFavoriteButtonVisible = Visibility.Visible;
        }

        private void IsFavoriteVisible()
        {
            DeleteFromFavoriteButtonVisible = Visibility.Visible;
            ToFavoriteButtonVisible = Visibility.Collapsed;
        }
    }
}
