using System;
using System.Globalization;
using System.Windows.Data;

namespace OpenKHS.Converters
{
    public class DiagnosticsValueOutputter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Console.WriteLine(">>>>>>>>>>>>>>>>>>>From "
                + nameof(DiagnosticsValueOutputter) + " reading the value: " + value +
                " <<<<<<<<<<<<<<<<<<");
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}