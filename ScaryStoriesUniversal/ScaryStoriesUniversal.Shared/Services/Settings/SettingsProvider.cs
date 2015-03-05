using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Windows.Storage;

namespace ScaryStoriesUniversal.Services.Settings
{
    public class SettingsProvider : ISettingsProvider
    {
        private ApplicationDataContainer _roamingSettings;

        public SettingsProvider()
        {
            _roamingSettings = Windows.Storage.ApplicationData.Current.RoamingSettings;
            
        }

        public  TextInfoSettings TextSettings
        {
            get { return StorageHelper.GetCompositeSetting<TextInfoSettings>("TextSettings"); }
            set
            {
                 StorageHelper.SetCompositeSetting<TextInfoSettings>("TextSettings",value);
            }
        }
    }
}
