using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace QudiniChallenge.UWP
{
    public class ImageGravatarConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
            {
                return "ms-appx:///Assets/defaultuser.png";
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new System.NotImplementedException();
        }
    }
}