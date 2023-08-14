using System;
using System.Globalization;
using System.Windows.Data;

namespace OnlyDox
{
    public class SubtractValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double width && parameter is string offsetStr && double.TryParse(offsetStr, out double offset))
            {
                return width - offset;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
