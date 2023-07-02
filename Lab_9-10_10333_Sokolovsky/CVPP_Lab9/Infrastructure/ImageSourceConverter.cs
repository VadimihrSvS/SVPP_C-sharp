using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace SVPP_Lab9.Infrastructure
{
    public class ImageSourceConverter : IValueConverter
    {
        string root = Directory.GetCurrentDirectory();
        string imageDirectory => Path.Combine(root, "Images");

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;
            var image = new BitmapImage();
            using (var stream = File.OpenRead(Path.Combine(imageDirectory, (string)value)))
            {
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = stream;
                image.EndInit();
            }
            return image;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
