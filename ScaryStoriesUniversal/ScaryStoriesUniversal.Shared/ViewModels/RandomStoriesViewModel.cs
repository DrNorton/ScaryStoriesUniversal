using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using ScaryStoriesUniversal.Api;
using ScaryStoriesUniversal.Api.Entities;
using ScaryStoriesUniversal.Helpers;
using ScaryStoriesUniversal.ViewModels.Base;

namespace ScaryStoriesUniversal.ViewModels
{
    public class RandomStoriesViewModel : VirtualizationListViewModel<Story>
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private readonly StoryListIdsContainer _idsContainer;

        public RandomStoriesViewModel(INavigationService navigationService, IApiService apiService, StoryListIdsContainer idsContainer)
            :base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            _idsContainer = idsContainer;

            base.ViewTitle = "Случайность";
        }

        public override async Task<IEnumerable<Story>> GetItems(uint count)
        {
            _currentEndIndex = new Random().Next(1, 1300);
            var items = await _apiService.GetStories((int)count, _currentEndIndex);
            return items;
        }
        public void NavigateToFind()
        {
            _navigationService.UriFor<FindViewModel>().Navigate();
        }

        public override void OnSelectItem(Story item)
        {
            var list = Items.Cast<Story>().ToList();
            _idsContainer.SetIds(list.Select(x => x.Id));
            _idsContainer.Position = list.IndexOf(item);
            _navigationService.UriFor<StoryViewModel>().Navigate();
        }
    }
}
