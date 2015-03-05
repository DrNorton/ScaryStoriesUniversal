using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Caliburn.Micro;
using Microsoft.WindowsAzure.MobileServices;
using ScaryStoriesUniversal.Api;
using ScaryStoriesUniversal.Api.Entities;
using ScaryStoriesUniversal.Helpers;
using ScaryStoriesUniversal.ViewModels.Base;

namespace ScaryStoriesUniversal.ViewModels
{
    public class SourceViewModel:VirtualizationListViewModel<Story>
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private readonly StoryListIdsContainer _idsContainer;
        private SourceVideoViewModel _sourceVideoViewModel;
        private Source _source;
        private long _totalStoriesCount;
        private Visibility _photoSectionVisibility=Visibility.Collapsed;
        public string SourceId { get; set; }

        public Source Source
        {
            get { return _source; }
            set
            {
                _source = value;
                base.NotifyOfPropertyChange(()=>Source);
            }
        }

        public SourceVideoViewModel SourceVideoViewModel
        {
            get { return _sourceVideoViewModel; }
            set
            {
                _sourceVideoViewModel = value;
                base.NotifyOfPropertyChange(()=>SourceVideoViewModel);
            }
        }

        public long TotalStoriesCount
        {
            get { return _totalStoriesCount; }
            set
            {
                _totalStoriesCount = value;
                if (value != null && value != 0)
                {
                    PhotoSectionVisibility=Visibility.Visible;
                }
                base.NotifyOfPropertyChange(()=>TotalStoriesCount);
            }
        }

        public Visibility PhotoSectionVisibility
        {
            get { return _photoSectionVisibility; }
            set
            {
                _photoSectionVisibility = value;
                base.NotifyOfPropertyChange(()=>PhotoSectionVisibility);
            }
        }

        public SourceViewModel(INavigationService navigationService, IApiService apiService, StoryListIdsContainer idsContainer)
            :base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            _idsContainer = idsContainer;
           
        }

       
        

        protected async override void OnViewReady(object view)
        {
            SourceVideoViewModel = new SourceVideoViewModel(_apiService, _navigationService,SourceId);
            LoadSource();
            base.OnViewReady(view);
        }

        private async void LoadSource()
        {
            Source = await _apiService.GetSource(SourceId);
        }

        public void NavigateToAllStories()
        {
            
        }

        public void NavigateToVideos()
        {
            
        }

        public async void WebNavigateToUrl()
        {
            var success = await Windows.System.Launcher.LaunchUriAsync(new Uri(Source.Url));
        }

        public override async Task<IEnumerable<Story>> GetItems(uint count)
        {
            var items=await _apiService.GetBySourceId(SourceId, (int)count, _currentEndIndex);
            TotalStoriesCount = ((ITotalCountProvider)items).TotalCount;
            return items;
        }

        public override void OnSelectItem(Story item)
        {
            var list = Items.Cast<Story>().ToList();
            _idsContainer.SetIds(list.Select(x => x.Id));
            _idsContainer.Position = list.IndexOf(item);
            _navigationService.UriFor<StoryViewModel>().Navigate();
        }
    }


    public class SourceVideoViewModel : VirtualizationListViewModel<Video>
    {
        private readonly IApiService _apiService;
        private readonly INavigationService _navigationService;
        private readonly string _sourceId;
        private long _totalVideosCount;
        private Visibility _videoSectionVisibility=Visibility.Collapsed;

        public SourceVideoViewModel(IApiService apiService,INavigationService navigationService,string sourceId)
            :base(navigationService)
        {
            _apiService = apiService;
            _navigationService = navigationService;
            _sourceId = sourceId;
        }

        public long TotalVideosCount
        {
            get { return _totalVideosCount; }
            set
            {
                _totalVideosCount = value;
                if (value != null && value != 0)
                {
                    VideoSectionVisibility = Visibility.Visible;
                }
                base.NotifyOfPropertyChange(()=>TotalVideosCount);
            }
        }

        public Visibility VideoSectionVisibility
        {
            get { return _videoSectionVisibility; }
            set
            {
                _videoSectionVisibility = value;
                base.NotifyOfPropertyChange(()=>VideoSectionVisibility);
            }
        }

        public async override Task<IEnumerable<Video>> GetItems(uint count)
        {
             var items= await _apiService.GetVideosBySourceId(_sourceId, (int)count, _currentEndIndex);
             TotalVideosCount = ((ITotalCountProvider)items).TotalCount;
            return items;
        }

        public override void OnSelectItem(Video item)
        {
            _navigationService.UriFor<VideoViewModel>().WithParam(x => x.VideoId, item.Id.ToString()).Navigate();
        }
    }
}
