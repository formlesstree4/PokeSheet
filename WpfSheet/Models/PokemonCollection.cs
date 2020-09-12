using System.Collections.ObjectModel;

namespace WpfSheet.Models
{

    /// <summary>
    ///     The base object type for the Pokemon data
    /// </summary>
    public sealed class PokemonCollection
    {

        /// <summary>
        ///     Gets / sets the array of usable Pokemon
        /// </summary>
        public ObservableCollection<Pokemon> Pokemon { get; set; }

    }

}
