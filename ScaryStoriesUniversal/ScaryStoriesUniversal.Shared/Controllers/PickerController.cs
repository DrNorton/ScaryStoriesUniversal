using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Provider;
using Caliburn.Micro;
using ScaryStoriesUniversal.Api.Entities;
using ScaryStoriesUniversal.Controllers.Models;

namespace ScaryStoriesUniversal.Controllers
{
    public class PickerController :  IHandle<FileSavePickerRequest>
    {
        private readonly IEventAggregator _events;

        public PickerController(IEventAggregator events)
        {
            _events = events;
        }

        public void Start()
        {
            _events.Subscribe(this);
        }


        public async void Handle(FileSavePickerRequest message)
        {
            FileSavePicker savePicker = new FileSavePicker();
            savePicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
                        // Dropdown of file types the user can save the file as
                        savePicker.FileTypeChoices.Add(message.Name, new List<string>() { ".jpg" });
                        // Default file name if the user does not type one in or select a file to replace
            savePicker.SuggestedFileName = message.Name;
#if WINDOWS_PHONE_APP
              savePicker.PickSaveFileAndContinue();
#endif
            //var response = new FileSavePickerResponse { Tag = message.Tag, File = await fp.PickSaveFileAsync() };

            //_events.Publish(response, action => Task.Factory.StartNew(action));
        }




       
    }
}
