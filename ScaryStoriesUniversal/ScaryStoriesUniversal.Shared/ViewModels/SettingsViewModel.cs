using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Caliburn.Micro;
using ScaryStoriesUniversal.Services.Settings;
using ScaryStoriesUniversal.ViewModels.Base;

namespace ScaryStoriesUniversal.ViewModels
{
    public class SettingsViewModel:LoadingScreen
    {
        private readonly ISettingsProvider _provider;

        private List<FontFamily> _fonts;
        private double _textSize;
        private double _lineHeight;
        private FontFamily _currentFont;
        private TextInfoSettings _textSettings;


        public SettingsViewModel(INavigationService navigationService,ISettingsProvider provider)
            :base(navigationService)
        {
            _provider = provider;
            CreateFontFamilyList();
            TextSettings = provider.TextSettings;
            _textSize = TextSettings.Size;
            _lineHeight = TextSettings.LineHeight;
            if (!String.IsNullOrEmpty(TextSettings.Font))
            {
                _currentFont = _fonts.FirstOrDefault(x => x.Source == TextSettings.Font);
            }
            else
            {
                _currentFont = _fonts.FirstOrDefault(x => x.Source == "Arial");
            }
            navigationService.Navigating += SaveOnBack;

        }

        private void SaveOnBack(object sender, NavigatingCancelEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Back)
            {
                _textSettings.Font = CurrentFont.Source;
                _textSettings.LineHeight = _lineHeight;
                _textSettings.Size = _textSize;
                _provider.TextSettings = _textSettings;
            }
        }

        private void CreateFontFamilyList()
        {
            _fonts = new List<FontFamily>();
            _fonts.Add(new FontFamily("Arial"));
            _fonts.Add(new FontFamily("Calibri"));
            _fonts.Add(new FontFamily("Comic Sans MS"));
            _fonts.Add(new FontFamily("Courier New"));
            _fonts.Add(new FontFamily("Georgia"));
            _fonts.Add(new FontFamily("Lucida Sans Unicode"));
            _fonts.Add(new FontFamily("Malgun Gothic"));
            _fonts.Add(new FontFamily("Meiryo UI"));
            _fonts.Add(new FontFamily("Segoe UI"));
            _fonts.Add(new FontFamily("Tahoma"));
            _fonts.Add(new FontFamily("Times New Roman"));
            _fonts.Add(new FontFamily("Trebuchet MS"));
            _fonts.Add(new FontFamily("Verdana"));
            _fonts.Add(new FontFamily("Webdings"));
        }
    
        public List<FontFamily> Fonts
        {
            get { return _fonts; }
            set
            {
                _fonts = value;
                base.NotifyOfPropertyChange(()=>Fonts);
            }
        }
        public double TextSize
        {
            get { return _textSize; }
            set
            {
                _textSize = value;
                base.NotifyOfPropertyChange(()=>TextSize);
            }
        }
        public double LineHeight
        {
            get { return _lineHeight; }
            set
            {
                _lineHeight = value;
                base.NotifyOfPropertyChange(() => LineHeight);
            }
        }

        public FontFamily CurrentFont
        {
            get { return _currentFont; }
            set
            {
                _currentFont = value;
                base.NotifyOfPropertyChange(()=>CurrentFont);
            }
        }

        public TextInfoSettings TextSettings
        {
            get { return _textSettings; }
            set
            {
                _textSettings = value;
                base.NotifyOfPropertyChange(()=>TextSettings);
            }
        }
    }
}
