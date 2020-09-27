using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using WpfSheet.Content;
using WpfSheet.Models;

namespace WpfSheet.Converters
{

    /// <summary>
    ///     Converts the incoming <see cref="Nature"/> object to its respective Color
    /// </summary>
    [ValueConversion(typeof(Nature), typeof(Brush))]
    public sealed class PokemonNatureToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(parameter is string stat)) throw new ArgumentNullException("NULL is not a supported target stat type", nameof(parameter));
            if (!(value is Nature nature)) throw new ArgumentNullException("The supplied value parameter cannot be NULL", nameof(value));

            var color = ResourceHandler.NeutralStat;
            if (nature.IncreaseStat.Equals(stat, StringComparison.OrdinalIgnoreCase)) color = ResourceHandler.PositiveStat;
            if (nature.DecreaseStat.Equals(stat, StringComparison.OrdinalIgnoreCase)) color = ResourceHandler.NegativeStat;
            return new SolidColorBrush(color);
        }

        /// <summary>
        ///     Not implemented
        /// </summary>
        /// <exception cref="NotImplementedException"/>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();

    }

}
