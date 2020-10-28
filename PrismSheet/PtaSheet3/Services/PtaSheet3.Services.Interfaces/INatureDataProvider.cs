using PtaSheet3.Core.Models;

namespace PtaSheet3.Services.Interfaces
{
    public interface INatureDataProvider
    {

        /// <summary>
        ///     Retrieves all loaded Natures
        /// </summary>
        /// <returns><see cref="NatureCollection"/></returns>
        NatureCollection RetrieveNatures();

        /// <summary>
        ///     Retrieves a particular Nature by its name
        /// </summary>
        /// <param name="name">The case insensitive name of the Nature</param>
        /// <returns><see cref="Nature"/></returns>
        /// <exception cref="Core.Content.AmbiguousLookupException"/>
        Nature GetNature(string name);

    }
}
