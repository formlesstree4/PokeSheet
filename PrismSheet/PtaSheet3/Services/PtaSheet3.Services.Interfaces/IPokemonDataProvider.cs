using PtaSheet3.Core.Models;

namespace PtaSheet3.Services.Interfaces
{
    public interface IPokemonDataProvider
    {

        /// <summary>
        ///     Retrieves all loaded Pokemon
        /// </summary>
        /// <returns><see cref="PokemonCollection"/></returns>
        PokemonCollection RetrievePokemon();

        /// <summary>
        ///     Retrieves a particular Pokemon by its name
        /// </summary>
        /// <param name="name">The case insensitive name of the Pokemon</param>
        /// <returns><see cref="Pokemon"/></returns>
        /// <exception cref="Core.Content.AmbiguousLookupException"/>
        Pokemon GetPokemon(string name);

        /// <summary>
        ///     Retrieves a particular Pokemon by its National Pokedex ID
        /// </summary>
        /// <param name="national">The national dex ID</param>
        /// <returns><see cref="Pokemon"/></returns>
        /// <remarks>In instances of ambiguity (such as alternate forms) this method will currently throw an Exception</remarks>
        /// <exception cref="Core.Content.AmbiguousLookupException"/>
        Pokemon GetPokemon(int national);

    }

}
