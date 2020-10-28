using PtaSheet3.Core.Models;
using System.Collections.Generic;

namespace PtaSheet3.Services.Interfaces
{

    /// <summary>
    ///     Provides Pokemon type information
    /// </summary>
    public interface ITypeDataProvider
    {

        /// <summary>
        ///     Retrieves all loaded Types
        /// </summary>
        /// <returns><see cref="TypesCollection"/></returns>
        TypesCollection RetrieveTypes();


        /// <summary>
        ///     Retrieves a particular Type by its name
        /// </summary>
        /// <param name="name">The case insensitive name of the Type</param>
        /// <returns><see cref="PokemonType"/></returns>
        /// <exception cref="Core.Content.AmbiguousLookupException"/>
        PokemonType GetType(string name);


        /// <summary>
        ///     Retrieves the types of a Pokemon
        /// </summary>
        /// <param name="pokemon"><see cref="Pokemon"/></param>
        /// <returns>A non-null collection of one or more <see cref="PokemonType"/> instances</returns>
        /// <remarks>There is a special <see cref="PokemonType"/> that should be called the None type. This type should not be returned by this method</remarks>
        IEnumerable<PokemonType> GetPokemonTypes(Pokemon pokemon);

    }
}
