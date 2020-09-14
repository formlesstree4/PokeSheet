using Newtonsoft.Json;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using DryIoc;
using WpfSheet.Models;

namespace WpfSheet.Content
{
    public static class ResourceHandler
    {

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern int GetModuleFileName(IntPtr hModule, StringBuilder buffer, int length);

        private static string _path = null;

        /// <summary>
        ///     Gets the dependency injection container.
        /// </summary>
        public static Container Container { get; private set; }

        /// <summary>
        ///     Gets the absolute path where the Pokemon JSON file is located.
        /// </summary>
        public static string GetPokemonFile => Path.Combine(StartupPath, "Content", "JSON", "pokemon.json");

        /// <summary>
        ///     Gets the absolute path where the Move JSN file is located.
        /// </summary>
        public static string GetMoveFile => Path.Combine(StartupPath, "Content", "JSON", "moves.json");

        /// <summary>
        ///     Gets the absolute path where the Ability JSON file is located.
        /// </summary>
        public static string GetAbilityFile => Path.Combine(StartupPath, "JSON", "abilities.json");

        /// <summary>
        ///     Gets the startup path of this program.
        /// </summary>
        public static string StartupPath
        {
            get
            {
                if (_path == null)
                {
                    StringBuilder buffer = new StringBuilder(260);
                    GetModuleFileName(IntPtr.Zero, buffer, buffer.Capacity);
                    _path = Path.GetDirectoryName(buffer.ToString());
                }
                new FileIOPermission(FileIOPermissionAccess.PathDiscovery, _path).Demand();
                return _path;
            }
        }



        /// <summary>
        ///     Initialize the resource handler
        /// </summary>
        public static void Initialize()
        {
            Container = new Container();
            ImportFromJsonFiles();
        }

        /// <summary>
        ///     Sets up the container with the necessary data
        /// </summary>
        private static void ImportFromJsonFiles()
        {
            var rawPokemonContent = File.ReadAllText(GetPokemonFile);
            var rawMoveContent = File.ReadAllText(GetMoveFile);
            var rawAbilityContent = File.ReadAllText(GetAbilityFile);

            var pokemonCollection = JsonConvert.DeserializeObject<PokemonCollection>(rawPokemonContent);
            var moveCollection = JsonConvert.DeserializeObject<MoveCollection>(rawMoveContent);
            var abilityCollection = JsonConvert.DeserializeObject<AbilityCollection>(rawAbilityContent);

            Container.RegisterInstance(pokemonCollection);
            Container.RegisterInstance(moveCollection);
            Container.RegisterInstance(abilityCollection);
        }

    }

}
