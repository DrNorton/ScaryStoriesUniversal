using System;
using System.Collections.Generic;
using System.Text;
using Windows.Storage;

namespace ScaryStoriesUniversal.Controllers.Models
{
    public class FileSavePickerResponse
    {
        public string Tag { get; set; }
        public StorageFile File { get; set; }
    }
}
