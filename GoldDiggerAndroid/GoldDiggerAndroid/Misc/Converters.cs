using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Linq;

using Xamarin.Forms;

namespace GoldDiggerAndroid.Misc
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
