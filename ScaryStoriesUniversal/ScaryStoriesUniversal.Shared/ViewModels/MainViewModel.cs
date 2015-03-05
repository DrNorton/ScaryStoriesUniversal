using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Caliburn.Micro;
using ScaryStoriesUniversal.Api;
using ScaryStoriesUniversal.Database.DataAccess;
using ScaryStoriesUniversal.Database.Entities;

using ScaryStoriesUniversal.Database.Repositories.Base;
using ScaryStoriesUniversal.Helpers;
using ScaryStoriesUniversal.ViewModels.Base;
using Category = ScaryStoriesUniversal.Api.Entities.Category;
using Source = ScaryStoriesUniversal.Api.Entities.Source;
using Story = ScaryStoriesUniversal.Api.Entities.Story;


namespace ScaryStoriesUniversal.ViewModels
{
    public class MainViewModel:LoadingScreen
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private readonly IFavoriteStoriesRepository _favoriteStoriesRepository;
        private readonly StoryListIdsContainer _idsContainer;
        private readonly IPhotoCachingRepository _photoCachingRepository;
        private IEnumerable<Category> _categories;
        private IEnumerable<Source> _sources;
        private IEnumerable<FavoriteStory> _favoritesStories;
        private FavoriteStory _selectedFavoriteStory;
        private Source _selectedSource;
        private PhotoEntity _backgroundImage;


        public MainViewModel(INavigationService navigationService, IApiService apiService, IFavoriteStoriesRepository favoriteStoriesRepository, StoryListIdsContainer idsContainer,IPhotoCachingRepository photoCachingRepository)
            :base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            _favoriteStoriesRepository = favoriteStoriesRepository;
            _idsContainer = idsContainer;
            _photoCachingRepository = photoCachingRepository;
        }

        protected async override void OnInitialize()
        {
            await IoC.Get<IDbConnection>().InitializeDatabase();
            LoadFavorites();
            LoadSources();
            LoadBackground();
            base.OnInitialize();
        }

        private async void LoadBackground()
        {
         
             var images=await _photoCachingRepository.GetRandomPhoto();
            if (images != null && images.Any())
            {
                BackgroundImage = images.FirstOrDefault();
            }
            else
            {
                var fromResource = LoadFromResource("Hauted-House-by-Potapova1920.jpg");
                var photoEntity = new PhotoEntity()
                {
                    CreatedAt = DateTime.Now,
                    Id = Guid.NewGuid().ToString(),
                    Image = fromResource,
                    Thumb = fromResource
                };
                await _photoCachingRepository.InsertAsync(photoEntity);
                BackgroundImage = photoEntity;
            }
        }

        private static byte[] LoadFromResource(string name)
        {
         
            using (Stream stream = typeof(MainViewModel).GetTypeInfo().Assembly.GetManifestResourceStream("ScaryStoriesUniversal."+name))
            {
                MemoryStream buffer = new MemoryStream();
                stream.CopyTo(buffer);

                return buffer.ToArray();
            }
        }

        private async void LoadSources()
        {
            Sources = await _apiService.GetSources(50,0);
        }

        public IEnumerable<Category> Categories
        {
            get { return _categories; }
            set
            {
                _categories = value;
                base.NotifyOfPropertyChange(()=>Categories);
            }
        }

        public IEnumerable<Source> Sources
        {
            get { return _sources; }
            set
            {
                _sources = value;
                base.NotifyOfPropertyChange(()=>Sources);
            }
        }

        public IEnumerable<FavoriteStory> FavoritesStories
        {
            get { return _favoritesStories; }
            set
            {
                _favoritesStories = value;
                base.NotifyOfPropertyChange(()=>FavoritesStories);
            }
        }

        public FavoriteStory SelectedFavoriteStory
        {
            get { return _selectedFavoriteStory; }
            set
            {
                _selectedFavoriteStory = value;
                if (value != null)
                {
                    NavigateToSelectedFavoriteStory(value);
                }
                
                base.NotifyOfPropertyChange(()=>SelectedFavoriteStory);
            }
        }

        public Source SelectedSource
        {
            get { return _selectedSource; }
            set
            {
                _selectedSource = value;
                if (value != null)
                {
                    NavigateToSelectedSource(value);
                }
                
                base.NotifyOfPropertyChange(()=>SelectedSource);
            }
        }

        public PhotoEntity BackgroundImage
        {
            get { return _backgroundImage; }
            set
            {
                _backgroundImage = value;
                base.NotifyOfPropertyChange(()=>BackgroundImage);
            }
        }

        private void NavigateToSelectedSource(Source value)
        {
            _navigationService.UriFor<SourceViewModel>().WithParam(x=>x.SourceId,value.Id).Navigate();
        }

        private void NavigateToSelectedFavoriteStory(FavoriteStory value)
        {
            _idsContainer.SetIds(new List<string>(){value.Id});
            _idsContainer.Position = 0;
            _navigationService.UriFor<StoryViewModel>().Navigate();
            SelectedFavoriteStory = null;
        }


        private async void LoadFavorites()
        {
            FavoritesStories=await _favoriteStoriesRepository.GetAll();
        }

        public void NavigateToAllStories()
        {
            _navigationService.UriFor<AllStoriesViewModel>().Navigate();
        }

        public void NavigateToAllPhotos()
        {
            _navigationService.UriFor<AllPhotosViewModel>().Navigate();
            
        }

        public void NavigateToSources()
        {
            _navigationService.UriFor<AllSourcesViewModel>().Navigate();
        }
        public void NavigateToFavorites()
        {
            _navigationService.UriFor<FavoritesViewModel>().Navigate();
        }

        public void NavigateToVideos()
        {
            _navigationService.UriFor<AllVideosViewModel>().Navigate();
        }

        public void Settings()
        {
            _navigationService.UriFor<SettingsViewModel>().Navigate();
        }
    }
}
