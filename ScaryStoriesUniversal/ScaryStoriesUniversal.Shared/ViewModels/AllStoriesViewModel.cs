using System;
using System.Collections.Generic;
using System.Text;
using Caliburn.Micro;
using ScaryStoriesUniversal.Api;

namespace ScaryStoriesUniversal.ViewModels
{
    public class AllStoriesViewModel:LoadingScreen
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;

        public AllStoriesViewModel(INavigationService navigationService,IApiService apiService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
        }

        protected override void OnViewReady(object view)
        {
            base.OnViewReady(view);
        }
    }
}
