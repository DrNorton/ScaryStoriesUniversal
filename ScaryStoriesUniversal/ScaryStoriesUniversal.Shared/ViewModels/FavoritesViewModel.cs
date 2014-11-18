using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.Micro;
using ScaryStoriesUniversal.Api;
using ScaryStoriesUniversal.Database.Entities;
using ScaryStoriesUniversal.Database.Repositories.Base;
using ScaryStoriesUniversal.Helpers;
using ScaryStoriesUniversal.ViewModels.Base;
using Story = ScaryStoriesUniversal.Api.Entities.Story;

namespace ScaryStoriesUniversal.ViewModels
{
    public class FavoritesViewModel: VirtualizationListViewModel<FavoriteStory>
    {
        private readonly IApiService _apiService;
        private readonly IFavoriteStoriesRepository _favoriteStoriesRepository;
        private readonly StoryListIdsContainer _idsContainer;
        private readonly INavigationService _navigationService;

        public FavoritesViewModel(IApiService apiService, IFavoriteStoriesRepository favoriteStoriesRepository, StoryListIdsContainer idsContainer,INavigationService navigationService)
            :base(navigationService)
        {
            _apiService = apiService;
            _favoriteStoriesRepository = favoriteStoriesRepository;
            _idsContainer = idsContainer;
            _navigationService = navigationService;
        }

        public async override System.Threading.Tasks.Task<IEnumerable<FavoriteStory>> GetItems(uint count)
        {
            base.Wait(true);
            var items= await _favoriteStoriesRepository.GetFetch((int)count, _currentEndIndex);
            base.Wait(false);
            return items;
        }

        public override void OnSelectItem(FavoriteStory item)
        {
            var list = Items.Cast<FavoriteStory>().ToList();
            _idsContainer.SetIds(list.Select(x => x.Id));
            _idsContainer.Position = list.IndexOf(item);
            _navigationService.UriFor<StoryViewModel>().Navigate();
        }
    }
}
