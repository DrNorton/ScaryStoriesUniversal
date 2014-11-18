using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.Micro;
using ScaryStoriesUniversal.Api;
using ScaryStoriesUniversal.Api.Entities;
using ScaryStoriesUniversal.ViewModels.Base;

namespace ScaryStoriesUniversal.ViewModels
{
    public class AllSourcesViewModel : VirtualizationListViewModel<Source>
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;

        public AllSourcesViewModel(INavigationService navigationService,IApiService apiService)
            :base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
        }


        public async override System.Threading.Tasks.Task<IEnumerable<Source>> GetItems(uint count)
        {
            base.Wait(true);
            var items= await _apiService.GetSources((int)count, _currentEndIndex);
            base.Wait(false);
            return items;
        }

        public override void OnSelectItem(Source item)
        {
             _navigationService.UriFor<SourceViewModel>().WithParam(x => x.SourceId, item.Id).Navigate();
        }
    }
}
