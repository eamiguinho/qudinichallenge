using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace QudiniChallenge.Windows
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (!(value is bool)) return Visibility.Collapsed;
            if ((bool) value)
            {
                return Visibility.Visible;
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new System.NotImplementedException();
        }
    }
}