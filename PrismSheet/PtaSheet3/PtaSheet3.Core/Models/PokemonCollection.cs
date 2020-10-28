using System.Collections.ObjectModel;

namespace PtaSheet3.Core.Models
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


        public override string ToString() => $"Pokemon: {Pokemon.Count} item(s)";

    }

}
