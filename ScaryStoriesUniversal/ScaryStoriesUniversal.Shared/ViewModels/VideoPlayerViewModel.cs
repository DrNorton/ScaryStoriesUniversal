using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using MyToolkit.Multimedia;
using MyToolkit.Utilities;
using ScaryStoriesUniversal.ViewModels.Base;
using ScaryStoriesUniversal.Views;

namespace ScaryStoriesUniversal.ViewModels
{
    public class VideoPlayerViewModel:LoadingScreen
    {
        private string _videoSource;
        public string Url { get; set; }
        public string Name { get; set; }

        public string VideoSource
        {
            get { return _videoSource; }
            set
            {
                _videoSource = value;
                base.NotifyOfPropertyChange(()=>VideoSource);
            }
        }

        public VideoPlayerViewModel(INavigationService navigationService)
            :base(navigationService)
        {
            
        }

        protected async override void OnViewReady(object view)
        {
            VideoSource = await PrepareUrl(Url);
        
            base.OnViewReady(view);
        }

        private async Task<string> PrepareUrl(string url)
        {
            var res=HttpUtilityExtensions.ParseQueryString(new Uri(url).Query);
            var key= res["?v"];
            base.Wait(true);
            YouTubeUri youtubeUrl;
            youtubeUrl=await YouTube.GetVideoUriAsync(key, YouTubeQuality.QualityHigh);
            if (youtubeUrl == null)
            {
                youtubeUrl = await YouTube.GetVideoUriAsync(key, YouTubeQuality.QualityMedium);
            }
            base.Wait(false);
            return youtubeUrl.Uri.ToString();
        }

        private static async Task PlayVideo()
        {
          
            var url = await YouTube.GetVideoUriAsync("6wTBdybRNPc", YouTubeQuality.Quality720P);
            if (url != null)
            {
                //player.Source = url.Uri;
                //player.Play();
            }
        }
    }
}
