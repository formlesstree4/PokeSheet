using PtaSheet3.Core.Models;

namespace PtaSheet3.Services.Interfaces
{

    /// <summary>
    ///     A data provider interface. This is not intended to be utilized by the application directly, rather other providers will reference this directly
    /// </summary>
    /// <remarks>
    ///     The purpose of this provider is to offer unified access to all data collections utilized across the application.
    ///     The application will then use the divided providers to perform fine-grained access of this information. Some may argue that this isn't exactly
    ///     the best kind of development practice but I also don't care what anyone says.
    /// </remarks>
    public interface IDataProvider
    {

        PokemonCollection RetrievePokemon();

        MoveCollection RetrieveMoves();

        AbilityCollection RetrieveAbilities();

        NatureCollection RetrieveNatures();

        TypesCollection RetrieveTypes();

    }

}
