using System.Globalization;
using System.Windows.Data;

namespace Messenger.App.Convertors
{
    public class BoolToHorizontalAlignConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? "Right" : "Left";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
