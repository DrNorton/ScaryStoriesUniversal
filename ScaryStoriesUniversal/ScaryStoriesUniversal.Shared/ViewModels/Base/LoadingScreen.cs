using Caliburn.Micro;
using MyToolkit.Command;

namespace ScaryStoriesUniversal.ViewModels.Base
{
    public class LoadingScreen : Screen
    {
        private readonly INavigationService _navigationService;
        private bool _indicatorVisible;
        private bool _isLoading;
        private bool _reverseLoading;
        private bool _isAllMenuEnabled = true;
        private string _viewTitle;
        public CommandBase BackNavigationCommand { get; set; }
        public string ViewTitle
        {
            get { return _viewTitle; }
            set
            {
                _viewTitle = value;
                base.NotifyOfPropertyChange(()=>ViewTitle);
            }
        }


        public LoadingScreen(INavigationService navigationService)
        {
            _navigationService = navigationService;
            BackNavigationCommand=new RelayCommand(BackNavigation);
        }

        public void BackNavigation()
        {
            _navigationService.GoBack();
        }
        
        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                base.NotifyOfPropertyChange(() => IsLoading);
            }
        }

        public bool IsAllMenuEnabled
        {
            get { return _isAllMenuEnabled; }
            set
            {
                _isAllMenuEnabled = value;
                base.NotifyOfPropertyChange(() => IsAllMenuEnabled);
            }
        }

        public bool ReverseLoading
        {
            get { return _reverseLoading; }
            set
            {
                _reverseLoading = value;
                base.NotifyOfPropertyChange(()=>ReverseLoading);
            }
        }

        protected virtual void Wait(bool wait)
        {
            IsLoading = wait;
            ReverseLoading = !wait;
            IsAllMenuEnabled = !wait;
        }
    }
}