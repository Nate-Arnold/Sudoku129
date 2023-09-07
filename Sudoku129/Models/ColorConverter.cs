using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Sudoku129.Models
{
    [ValueConversion(typeof(Brush), typeof(string))]
    public class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not null and not (object)"0")
            {
                Brush brush = (SolidColorBrush)new BrushConverter().ConvertFromString((string)value);
                return brush;
            }

            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //WIP
            //var colorString = (string)new BrushConverter().ConvertToString(value);
            //return colorString;
            throw new NotImplementedException();
        }
    }
}
