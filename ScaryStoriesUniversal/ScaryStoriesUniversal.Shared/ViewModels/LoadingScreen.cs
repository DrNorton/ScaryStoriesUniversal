using Caliburn.Micro;

namespace ScaryStoriesUniversal.ViewModels
{
    public class LoadingScreen : Screen
    {
        private bool _indicatorVisible;
        private bool _isLoading;
        private bool _isAllMenuEnabled = true;

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

        protected virtual void Wait(bool wait)
        {
            IsLoading = wait;
            IsAllMenuEnabled = !wait;
        }
    }
}