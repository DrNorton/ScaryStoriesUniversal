using Caliburn.Micro;



namespace ScaryStoriesUniversal.ViewModels
{
    public class MainViewModel:LoadingScreen
    {
        private readonly INavigationService _navigationService;
       

        public MainViewModel(INavigationService navigationService )
        {
            _navigationService = navigationService;
        }

        public void NavigateToAllStories()
        {
            _navigationService.UriFor<AllStoriesViewModel>().Navigate();
        }
    }
}
