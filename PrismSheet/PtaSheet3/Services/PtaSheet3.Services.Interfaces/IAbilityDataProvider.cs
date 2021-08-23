using PtaSheet3.Core.Models;
using System.Collections.Generic;

namespace PtaSheet3.Services.Interfaces
{
    public interface IAbilityDataProvider
    {

        /// <summary>
        ///     Retrieves all loaded Abilities
        /// </summary>
        /// <returns><see cref="AbilityCollection"/></returns>
        AbilityCollection RetrieveAbilities();

        /// <summary>
        ///     Retrieves a particular Ability by its name
        /// </summary>
        /// <param name="name">The case insensitive name of the Ability</param>
        /// <returns><see cref="Ability"/></returns>
        /// <exception cref="Core.Content.AmbiguousLookupException"/>
        Ability GetAbility(string name);

        /// <summary>
        ///     Retrieves a Pokemon's regular abilities
        /// </summary>
        /// <param name="pokemon">The <see cref="Pokemon"/> to look up</param>
        /// <returns>A non-null collection of <see cref="Ability"/></returns>
        IEnumerable<Ability> GetPokemonRegularAbilities(Pokemon pokemon);

        /// <summary>
        ///     Retrieves a Pokemon's high abilities
        /// </summary>
        /// <param name="pokemon">The <see cref="Pokemon"/> to look up</param>
        /// <returns>A non-null collection of <see cref="Ability"/></returns>
        IEnumerable<Ability> GetPokemonHighAbilities(Pokemon pokemon);

        /// <summary>
        /// Writes all changes out back to file
        /// </summary>
        void FlushChanges();

    }

}
