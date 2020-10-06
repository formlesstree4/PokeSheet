using System;
using System.Collections.Concurrent;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WpfSheet.Content;
using WpfSheet.Models;

namespace WpfSheet.Converters
{
    public sealed class PokemonTypeImageSourceConverter : IValueConverter
    {
        private static readonly ConcurrentDictionary<PokemonType, ImageSource> ImageSourceCache = new ConcurrentDictionary<PokemonType, ImageSource>();


        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is PokemonType pt)) return null;
            return ImageSourceCache.GetOrAdd(pt, p =>
            {
                var imagePath = ResourceHandler.RetrieveTypeImagePath(p);
                if (!System.IO.File.Exists(imagePath)) return null;
                var url = new Uri(imagePath);
                return new BitmapImage(url);
            });
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException("You cannot go from an ImageSource back to a Pokemon Type");
    }
}
