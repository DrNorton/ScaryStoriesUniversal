using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace ScaryStoriesUniversal.Services
{
    public interface IMessageProvider
    {
        Task<IUICommand> ShowCustomOkMessageBox(string message, string title);

        void ShowPhoto(byte[] image);
    }
}
