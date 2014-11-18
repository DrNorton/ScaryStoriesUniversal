using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Provider;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;
using Caliburn.Micro;
using ScaryStoriesUniversal.Api;
using ScaryStoriesUniversal.Api.Entities;
using ScaryStoriesUniversal.Controllers.Models;
using ScaryStoriesUniversal.Database.Entities;

using ScaryStoriesUniversal.Database.Repositories.Base;
using ScaryStoriesUniversal.ViewModels.Base;

namespace ScaryStoriesUniversal.ViewModels
{
    public class PhotoViewModel : LoadingScreen, IHandle<FileSavePickerResponse>
    {
        private readonly IApiService _apiService;
        private readonly IEventAggregator _eventAggregator;
        private readonly IPhotoCachingRepository _photoCachingRepository;
        private Photo _photo;
        public string PhotoId { get; set; }

        public Photo Photo
        {
            get { return _photo; }
            set
            {
                _photo = value;
                base.NotifyOfPropertyChange(()=>Photo);
            }
        }

        public PhotoViewModel(IApiService apiService,IEventAggregator eventAggregator,IPhotoCachingRepository photoCachingRepository,INavigationService navigationService)
            :base(navigationService)
        {
            _apiService = apiService;
            _eventAggregator = eventAggregator;
            _photoCachingRepository = photoCachingRepository;
            _eventAggregator.Subscribe(this);
        }

        protected async override void OnViewReady(object view)
        {
            await GetPhoto();
            base.OnViewReady(view);
        }

        private async Task GetPhoto()
        {
            Photo = await _apiService.GetPhoto(PhotoId);
            await _photoCachingRepository.InsertAsync(new PhotoEntity()
            {
                Id = Photo.Id,
                Image = Photo.Image,
                Thumb = Photo.Thumb
            });

        }

        public async  void Save()
        {
#if WINDOWS_PHONE_APP
            _eventAggregator.PublishOnUIThread(new FileSavePickerRequest() { Name = Photo.Id });
#endif

#if WINDOWS_APP
            
            FileSavePicker savePicker = new FileSavePicker();
            savePicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            // Dropdown of file types the user can save the file as
            savePicker.FileTypeChoices.Add(Photo.Id, new List<string>() { ".jpg" });
            // Default file name if the user does not type one in or select a file to replace
            savePicker.SuggestedFileName = Photo.Id;
            var result=await savePicker.PickSaveFileAsync();
            await SaveFile(result);
#endif

        }

        public async void Handle(FileSavePickerResponse message)
        {
            StorageFile file = message.File;
            await SaveFile(file);
        }

        private async Task SaveFile(StorageFile file)
        {
            if (file != null)
            {
                // Prevent updates to the remote version of the file until we finish making changes and call CompleteUpdatesAsync.
                CachedFileManager.DeferUpdates(file);
                // write to file
                await FileIO.WriteBytesAsync(file, Photo.Image);
                // Let Windows know that we're finished changing the file so the other app can update the remote version of the file.
                // Completing updates may require Windows to ask for user input.
                FileUpdateStatus status = await CachedFileManager.CompleteUpdatesAsync(file);
            }
        }
    }
}
