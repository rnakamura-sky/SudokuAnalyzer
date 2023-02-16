using System;
using System.Globalization;
using System.Windows.Data;

namespace Sudoku.WPF.Views.Converters
{
    public class BoolToOpacityConverter : IValueConverter
    {
        private static double TrueValue = 1.0;
        private static double FalseValue = 0.5;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isChecked = value as bool?;
            if (isChecked is null)
            {
                return TrueValue;
            }

            if (isChecked.Value)
            {
                return TrueValue;
            }
            return FalseValue;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
