using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.Connectivity;
using Caliburn.Micro;
using ScaryStoriesUniversal.Api;
using ScaryStoriesUniversal.Api.Entities;
using ScaryStoriesUniversal.ViewModels.Base;
using Telerik.Core.Data;

namespace ScaryStoriesUniversal.ViewModels
{
    public class AllPhotosViewModel:VirtualizationListViewModel<Photo>
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
       
        public AllPhotosViewModel(INavigationService navigationService,IApiService apiService)
            :base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
        }

        public override void OnSelectItem(Photo item)
        {
            _navigationService.UriFor<PhotoViewModel>().WithParam(x => x.PhotoId, item.Id.ToString()).Navigate();
         
        }

        public async override Task<IEnumerable<Photo>> GetItems(uint count)
        {
            return await _apiService.GetPhotos((int)count, _currentEndIndex);
        }
    }
}
