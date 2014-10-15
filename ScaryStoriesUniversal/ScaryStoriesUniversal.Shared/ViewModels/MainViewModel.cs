using Caliburn.Micro;
using ScaryStoriesUniversal.Database.Repositories.Base;


namespace ScaryStoriesUniversal.ViewModels
{
    public class MainViewModel:Screen
    {
        private readonly INavigationService _navigationService;
        private readonly IStoryRepository _storyRepository;

        public MainViewModel(INavigationService navigationService,IStoryRepository storyRepository )
        {
            _navigationService = navigationService;
            _storyRepository = storyRepository;
        }
    }
}
