using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Caliburn.Micro;
using ScaryStoriesUniversal.Api;
using ScaryStoriesUniversal.Api.Entities;
using ScaryStoriesUniversal.Database.Entities;
using ScaryStoriesUniversal.Database.Repositories.Base;
using ScaryStoriesUniversal.Helpers;
using ScaryStoriesUniversal.Services;
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


        public StoryViewModel(INavigationService navigationService,IApiService apiService,StoryListIdsContainer idsContainer,IMessageProvider messageProvider,IFavoriteStoriesRepository favoriteStoriesRepository)
            :base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            _idsContainer = idsContainer;
            _messageProvider = messageProvider;
            _favoriteStoriesRepository = favoriteStoriesRepository;
        }

        public async void WebNavigateToUrl()
        {
            if (!String.IsNullOrEmpty(Story.Url))
            {
                var success = await Windows.System.Launcher.LaunchUriAsync(new Uri(Story.Url));
            }
        }

        public async void Back()
        {
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


        public async void Next()
        {
            await GetStoryById(_idsContainer.Next());
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
