using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml.Controls;
using Caliburn.Micro;

// The Blank Application template is documented at http://go.microsoft.com/fwlink/?LinkId=234227
using ScaryStoriesUniversal.Database.DataAccess;
using ScaryStoriesUniversal.Database.Entities;
using ScaryStoriesUniversal.Database.Repositories;
using ScaryStoriesUniversal.Database.Repositories.Base;

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
            _container.PerRequest<MainViewModel>();
            var dbPath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "scaryStories.sqlite");
            await InitializeDatabaseAndRegisterDbConnection(dbPath);
            InitializeRepositories();
            await InitTestData();
        }

        private async Task InitTestData()
        {
            var storyRepository=(IStoryRepository)_container.GetInstance(typeof (IStoryRepository), null);
            var categoryRepository =(ICategoryRepository) _container.GetInstance(typeof(ICategoryRepository), null);
            await categoryRepository.InsertCategoryAsync(new Category() {CreatedTime = DateTime.Now, Name = "Призраки"});
        }

        private void InitializeRepositories()
        {
            _container.RegisterPerRequest(typeof(IStoryRepository),null,typeof(StoryRepository));
            _container.RegisterPerRequest(typeof(ICategoryRepository), null, typeof(CategoryRepository));
        }

        private async Task  InitializeDatabaseAndRegisterDbConnection(string path)
        {
            var oDbConnection = new DbConnection(path);
            oDbConnection.InitializeDatabase();
            _container.RegisterInstance(typeof(IDbConnection),null,oDbConnection);
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