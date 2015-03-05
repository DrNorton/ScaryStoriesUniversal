using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Media;

namespace ScaryStoriesUniversal.Services.Settings
{
    public class TextInfoSettings
    {
        private double _size;
        private double _lineHeight;
        private string _font;

        public double Size
        {
            get { return _size; }
            set { _size = value; }
        }
        public double LineHeight
        {
            get { return _lineHeight; }
            set { _lineHeight = value; }
        }
        public string Font
        {
            get { return _font; }
            set { _font = value; }
        }

    }
}
