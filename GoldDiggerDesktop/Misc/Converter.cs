using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace GoldDiggerDesktop.Misc
{
    class TextToInt : IValueConverter
    {
        // IntToString: ViewModel->View.
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString();
        }

        // StringToInt: View->ViewModel.
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return int.TryParse(value.ToString(), out int i) ? i : 0;
        }
    }
}
