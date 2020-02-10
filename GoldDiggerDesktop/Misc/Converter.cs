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

    class StreamToImage : IValueConverter
    {
        // ViewModel->View.
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            using (var stream = new System.IO.MemoryStream(value as byte[]))
            {
                var image = new System.Windows.Media.Imaging.BitmapImage();
                //image.BeginInit();
                //image.StreamSource = stream;
                //image.EndInit();
                image.StreamSource = stream;
                return image as System.Windows.Media.ImageSource;
            }
            throw new NotImplementedException($"Should not be reached: [{nameof(StreamToImage)}.{nameof(Convert)}]");
        }

        // View->ViewModel.
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException($"Should not be reached: [{nameof(StreamToImage)}.{nameof(ConvertBack)}]");
        }
    }
}
