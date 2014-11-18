using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Popups;
using Caliburn.Micro;

namespace ScaryStoriesUniversal.Helpers
{
    public static class ExceptionHandler
    {

        public static void LogException(Exception ex)
        {
            // e.g. MarkedUp.AnalyticClient.Error(ex.Message, ex);
        }

        /// <summary>
        /// Handles failure for application exception on UI thread (or initiated from UI thread via async void handler)
        /// </summary>
        public static void HandleException(Exception ex)
        {

            LogException(ex);

            Execute.OnUIThread(async () =>
            {
                var dialog = new MessageDialog(GetDisplayMessage(ex), "Unknown Error");
                await dialog.ShowAsync();
            });

        }

        /// <summary>
        /// Gets the error message to display from an exception
        /// </summary>
        public static string GetDisplayMessage(Exception ex)
        {
            string errorMessage;
#if DEBUG
            errorMessage = (ex.Message + " " + ex.StackTrace);
#else
                errorMessage = "An unknown error has occurred, please try again";
#endif
            return errorMessage;
        }
    }

}
