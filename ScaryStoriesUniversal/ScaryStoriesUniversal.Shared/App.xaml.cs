using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml.Controls;
using Caliburn.Micro;

// The Blank Application template is documented at http://go.microsoft.com/fwlink/?LinkId=234227
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using ScaryStoriesUniversal.Api;
using ScaryStoriesUniversal.Api.Entities;
using ScaryStoriesUniversal.ViewModels;
using ScaryStoriesUniversal.Views;

namespace ScaryStoriesUniversal
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public sealed partial class App
    {
        private WinRTContainer _container;
        
        public App()
        {
            InitializeComponent();
        }

        protected async  override void Configure()
        {
            _container = new WinRTContainer();
            _container.RegisterWinRTServices();
            RegisterViewModels();
            var apiService = new ApiService("http://localhost:16781", null);
            _container.RegisterInstance(typeof(IApiService), "", apiService);
            InitLocalStore(apiService);
        }

        private void RegisterViewModels()
        {
            _container.PerRequest<MainViewModel>();
            _container.PerRequest<AllStoriesViewModel>();
        }

        private async void InitLocalStore(IApiService apiService)
        {
            if (apiService.ServiceClient.SyncContext.IsInitialized)
            {
                var store = new MobileServiceSQLiteStore("localsync12.db");
                store.DefineTable<Story>();
                await store.InitializeAsync();
            }
           
        }


        protected override void PrepareViewFirst(Frame rootFrame)
        {
            _container.RegisterNavigationService(rootFrame);
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            if (args.PreviousExecutionState == ApplicationExecutionState.Running)
                return;

            DisplayRootView<MainView>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }
}