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

    /// <summary>
    ///     Takes in a Pokemon and returns out the appropriate image source
    /// </summary>
    [ValueConversion(typeof(Pokemon), typeof(ImageSource))]
    public sealed class SpriteImageSourceConverter : IValueConverter
    {

        private static readonly ConcurrentDictionary<Pokemon, ImageSource> ImageSourceCache = new ConcurrentDictionary<Pokemon, ImageSource>();



        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Pokemon pokemon)) return null;
            return ImageSourceCache.GetOrAdd(pokemon, p =>
            {
                var imagePath = ResourceHandler.RetrievePokemonSpritePath(p);
                if (!System.IO.File.Exists(imagePath)) return null;
                var url = new Uri(imagePath);
                return new BitmapImage(url);
            });
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException("You cannot go from an ImageSource back to a Pokemon");


    }
}
