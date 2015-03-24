using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Caliburn.Micro;

// The Blank Application template is documented at http://go.microsoft.com/fwlink/?LinkId=234227
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using ScaryStoriesUniversal.Api;
using ScaryStoriesUniversal.Api.Entities;
using ScaryStoriesUniversal.Controllers;
using ScaryStoriesUniversal.Controllers.Models;
using ScaryStoriesUniversal.Database.DataAccess;
using ScaryStoriesUniversal.Database.Repositories;
using ScaryStoriesUniversal.Database.Repositories.Base;
using ScaryStoriesUniversal.Helpers;
using ScaryStoriesUniversal.Services;
using ScaryStoriesUniversal.Services.Settings;
using ScaryStoriesUniversal.Services.Tiles;
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
            AsyncSynchronizationContext.Register();
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
            RegisterViewModels();
             InitLocalStore();
         //   var apiService = new ApiService("http://localhost:16781", null);
             var apiService = new ApiService(@"http://storiesmobileservice.azure-mobile.net/", "eOxFathFeOfvquGBFoAZmDsGJuifQH42");
            apiService.OnErrorHandled+=apiService_OnErrorHandled;
            _container.RegisterInstance(typeof(IApiService), "", apiService);
            _container.RegisterInstance(typeof(AnimationManager),"",new AnimationManager());
            _container.RegisterInstance(typeof(StoryListIdsContainer),"",new StoryListIdsContainer());
            _container.RegisterPerRequest(typeof(IMessageProvider),"",typeof(MessageProvider));
            _container.RegisterSingleton(typeof(PickerController), null, typeof(PickerController));
            var pickerController = _container.GetInstance(typeof(PickerController), null) as PickerController;
            pickerController.Start();
            //init Settings
            var settingsProvider = new SettingsProvider();
            if (settingsProvider.TextSettings == null)
            {
                var info = new TextInfoSettings();
                info.LineHeight = 1;
                info.Size = 15;
                info.Font = "Arial";
                settingsProvider.TextSettings = info;
            }
            _container.RegisterInstance(typeof(ISettingsProvider),"",settingsProvider);
            _container.RegisterInstance(typeof(ITileService),"",new TileService());
           
        }

        private void apiService_OnErrorHandled(Exception e)
        {
            var messageProvider=(IMessageProvider)_container.GetInstance(typeof (IMessageProvider), "");
            messageProvider.ShowCustomOkMessageBox("Ошибка получения данных с сервиса. Проверьте интернет-соединение.", "Ошибка");
        }

        void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            e.SetObserved();
            ExceptionHandler.LogException(e.Exception);
        }

        private void RegisterViewModels()
        {
            _container.PerRequest<MainViewModel>();
            _container.PerRequest<AllStoriesViewModel>();
            _container.PerRequest<StoryViewModel>();
            _container.PerRequest<AllPhotosViewModel>();
            _container.PerRequest<PhotoViewModel>();
            _container.PerRequest<VideoViewModel>();
            _container.PerRequest<FindViewModel>();
            _container.PerRequest<AllVideosViewModel>();
            _container.PerRequest<VideoPlayerViewModel>();
            _container.PerRequest<FavoritesViewModel>();
            _container.PerRequest<AllSourcesViewModel>();
            _container.PerRequest<SourceViewModel>();
            _container.PerRequest<SettingsViewModel>();
            _container.PerRequest<RandomStoriesViewModel>();
        }

        private void InitLocalStore()
        {
            var dbConnection=new DbConnection("localstore.db");
            //Таск зарегим в viewModel
            //await dbConnection.InitializeDatabase();
            _container.RegisterInstance(typeof(IDbConnection), "", dbConnection);
            _container.RegisterPerRequest(typeof(IFavoriteStoriesRepository), "", typeof(FavoriteStoriesRepository));
            _container.RegisterPerRequest(typeof(IPhotoCachingRepository), "", typeof(PhotoCachingRepository));
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

        protected override void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            ExceptionHandler.HandleException(new Exception(e.Message, e.Exception));
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }

        protected override void OnFileOpenPickerActivated(FileOpenPickerActivatedEventArgs args)
        {
            Debug.WriteLine("dadadad");
            base.OnFileOpenPickerActivated(args);
        }

        protected override void OnResuming(object sender, object e)
        {
            Debug.WriteLine("dadadad");
            base.OnResuming(sender, e);
        }

        protected override void OnFileSavePickerActivated(FileSavePickerActivatedEventArgs args)
        {
            
            Debug.WriteLine("dadadad");
            base.OnFileSavePickerActivated(args);
        }

        protected override void OnShareTargetActivated(ShareTargetActivatedEventArgs args)
        {
            Debug.WriteLine("asdasd");
            base.OnShareTargetActivated(args);
        }

        protected override void OnActivated(IActivatedEventArgs args)
        {
 #if WINDOWS_PHONE_APP
            switch (args.Kind)
            {
                case ActivationKind.PickSaveFileContinuation:
                    var file = args as FileSavePickerContinuationEventArgs;
                    if (file != null)
                    {
                        IoC.Get<IEventAggregator>().PublishOnUIThread(new FileSavePickerResponse() { File = file.File });
                    }
                   
                    break;
           
            }
#endif
          
            base.OnActivated(args);
        }
    }
}