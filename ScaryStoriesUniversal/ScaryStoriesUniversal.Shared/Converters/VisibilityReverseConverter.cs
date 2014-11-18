using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace ScaryStoriesUniversal.Converters
{
    public class VisibilityReverseConverter : IValueConverter
	{
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool bValue = (bool)value;
            return bValue ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            Visibility visibility = (Visibility)value;
            return visibility != Visibility.Visible;
        }
    }
}