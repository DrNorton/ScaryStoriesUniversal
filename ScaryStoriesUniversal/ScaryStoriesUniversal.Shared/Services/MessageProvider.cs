using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Microsoft.VisualBasic.CompilerServices;

namespace ScaryStoriesUniversal.Services
{
   public class MessageProvider:IMessageProvider
    {
        public async Task<IUICommand> ShowCustomOkMessageBox(string message, string title)
        {

            var messageDialog = new MessageDialog(message);
            messageDialog.Title = title;
            messageDialog.Commands.Clear();
            messageDialog.Commands.Add(new UICommand(){Label = "Ок",Id = 0});
            return await messageDialog.ShowAsync();
        }

        public void ShowPhoto(byte[] image)
        {
            throw new NotImplementedException();
        }

       
    }
}
