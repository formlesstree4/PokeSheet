using PtaSheet3.Core.Models;
using System.Collections.Generic;

namespace PtaSheet3.Services.Interfaces
{
    public interface IMoveDataProvider
    {

        /// <summary>
        ///     Retrieves a collection of <see cref="Move"/> instances that are used when leveling up a Pokemon
        /// </summary>
        /// <param name="pokemon">The <see cref="Pokemon"/> instance to retrieve moves by</param>
        /// <returns>A non-null collection of zero or more <see cref="Move"/> instances</returns>
        IEnumerable<Move> GetPokemonMovesByLevel(Pokemon pokemon);

        /// <summary>
        ///     Retrieves a collection of <see cref="Move"/> instances that a Pokemon can learn from an Egg
        /// </summary>
        /// <param name="pokemon">The <see cref="Pokemon"/> instance to retrieve moves by</param>
        /// <returns>A non-null collection of zero or more <see cref="Move"/> instances</returns>
        IEnumerable<Move> GetPokemonMovesByEgg(Pokemon pokemon);

        /// <summary>
        ///     Retrieves a collection of <see cref="Move"/> instances that a Pokemon can learn from a Move Tutor
        /// </summary>
        /// <param name="pokemon">The <see cref="Pokemon"/> instance to retrieve moves by</param>
        /// <returns>A non-null collection of zero or more <see cref="Move"/> instances</returns>
        IEnumerable<Move> GetPokemonMovesByTutor(Pokemon pokemon);

        /// <summary>
        ///     Retrieves a particular move with optional type details to narrow down ambiguity
        /// </summary>
        /// <param name="name">The case insensitive name of the move</param>
        /// <param name="type">An optional instance of <see cref="PokemonType"/> to help narrow down instances of duplicated moves (such as Curse)</param>
        /// <returns><see cref="Move"/></returns>
        Move GetMove(string name, PokemonType type = null);

    }

}