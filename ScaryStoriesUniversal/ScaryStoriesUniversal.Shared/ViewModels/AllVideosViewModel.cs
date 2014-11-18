using System;
using System.Collections.Generic;
using System.Text;
using Caliburn.Micro;
using ScaryStoriesUniversal.Api;
using ScaryStoriesUniversal.Api.Entities;
using ScaryStoriesUniversal.ViewModels.Base;

namespace ScaryStoriesUniversal.ViewModels
{
    public class AllVideosViewModel:VirtualizationListViewModel<Video>
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;

        public AllVideosViewModel(INavigationService navigationService,IApiService apiService)
            :base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
         
        }

        public async override System.Threading.Tasks.Task<IEnumerable<Video>> GetItems(uint count)
        {
            return await _apiService.GetVideos((int)count, _currentEndIndex);
        }

        public override void OnSelectItem(Video item)
        {
            _navigationService.UriFor<VideoViewModel>().WithParam(x => x.VideoId, item.Id.ToString()).Navigate();
        }
    }
}
