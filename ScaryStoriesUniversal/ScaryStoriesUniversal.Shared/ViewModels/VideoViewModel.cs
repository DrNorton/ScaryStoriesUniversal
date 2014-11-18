using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using ScaryStoriesUniversal.Api;
using ScaryStoriesUniversal.Api.Entities;
using ScaryStoriesUniversal.ViewModels.Base;

namespace ScaryStoriesUniversal.ViewModels
{
    public class VideoViewModel:LoadingScreen
    {
        private readonly IApiService _apiService;
        private readonly INavigationService _navigationService;
        private Video _video;
        public string VideoId { get; set; }

        public Video Video
        {
            get { return _video; }
            set
            {
                _video = value;
                base.NotifyOfPropertyChange(()=>Video);
            }
        }

        public VideoViewModel(IApiService apiService,INavigationService navigationService)
            :base(navigationService)
        {
            _apiService = apiService;
            _navigationService = navigationService;
        }

        protected async override void OnViewReady(object view)
        {
             GetVideoById(VideoId);
            base.OnViewReady(view);
        }

        private async Task GetVideoById(string videoId)
        {
            Video = await _apiService.GetVideo(videoId);
        }

        public void VideoThumbTap()
        {
         _navigationService.UriFor<VideoPlayerViewModel>().WithParam(x=>x.Url,_video.Url.ToString()).Navigate();
        }

    }

}
