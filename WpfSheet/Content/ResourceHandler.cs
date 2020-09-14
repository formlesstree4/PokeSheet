using Newtonsoft.Json;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using DryIoc;
using WpfSheet.Models;
using WpfSheet.ViewModels;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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
        public static string GetAbilityFile => Path.Combine(StartupPath, "Content", "JSON", "abilities.json");

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



        public static MainWindowViewModel MainViewModel => Container.Resolve<MainWindowViewModel>();

        public static SheetViewModel PokemonSheetViewModel => Container.Resolve<SheetViewModel>();

        public static ImageSource ApplicationIcon => new BitmapImage(new Uri(Path.Combine(StartupPath, "Content", "Images", "app-icon.ico")));



        static ResourceHandler()
        {
            Container = new Container();
            ImportFromJsonFiles();
            Container.Register<MainWindowViewModel>();
            Container.Register<SheetViewModel>();
        }



        public static string RetrievePokemonImagePath(Pokemon p)
        {
            return RetrieveImageForType(p, "pokemon");
        }

        public static string RetrievePokemonSpritePath(Pokemon p)
        {
            return RetrieveImageForType(p, "sprites");
        }

        private static string RetrieveImageForType(Pokemon p, string folderType)
        {
            //if (!int.TryParse(p.Pokedex.National, out var nationalId)) return null;
            var nationalId = p.Pokedex.National;
            var basePath = Path.Combine(StartupPath, "Content", "Images", folderType);

            switch (nationalId)
            {
                case 386: // Deoxys
                    return Path.Combine(basePath, nationalId.ToString(), $"{nationalId}-{CalculateDeoxysForme(p)}.png");
                case 412: // Burmy
                case 413: // Wormadam
                    return Path.Combine(basePath, nationalId.ToString(), $"{nationalId}-{CalculateBurmyForme(p)}.png");
                case 479: // Rotom
                    return Path.Combine(basePath, nationalId.ToString(), $"{nationalId}{CalculateRotomForme(p)}.png");
                case 487: // Giratina
                    return Path.Combine(basePath, nationalId.ToString(), $"{nationalId}-{CalculateGiratinaForme(p)}.png");
                case 492: // Shaymin
                    return Path.Combine(basePath, nationalId.ToString(), $"{nationalId}-{CalculateShayminForme(p)}.png");
                case 585: // Deerling
                case 586: // Sawsbuck
                    return Path.Combine(basePath, nationalId.ToString(), $"{nationalId}-{CalculateAppropriateSeason()}.png");
                case 648: // Meloetta
                    return Path.Combine(basePath, nationalId.ToString(), $"{nationalId}-{CalculateMeloettaForme(p)}.png");
                default:
                    return Path.Combine(basePath, $"{nationalId}.png");
            }
        }

        private static string CalculateDeoxysForme(Pokemon p)
        {
            var species = p.Name.ToLowerInvariant();
            if (species.Contains("attack")) return "attack";
            if (species.Contains("defense")) return "defense";
            if (species.Contains("speed")) return "speed";
            return "normal";
        }

        private static string CalculateBurmyForme(Pokemon p)
        {
            var species = p.Name.ToLowerInvariant();
            if (species.Contains("plant")) return "plant";
            if (species.Contains("sandy")) return "sandy";
            return "trash";
        }

        private static string CalculateRotomForme(Pokemon p)
        {
            var species = p.Name.ToLowerInvariant();
            if (species.Contains("fan")) return "-fan";
            if (species.Contains("frost")) return "-frost";
            if (species.Contains("heat")) return "-heat";
            if (species.Contains("mow")) return "-mow";
            if (species.Contains("wash")) return "-wash";
            return string.Empty;
        }

        private static string CalculateGiratinaForme(Pokemon p)
        {
            return p.Name.ToLowerInvariant().Contains("origin") ? "origin" : "altered";
        }

        private static string CalculateShayminForme(Pokemon p)
        {
            return p.Name.ToLowerInvariant().Contains("sky") ? "sky" : "land";
        }

        private static string CalculateAppropriateSeason()
        {
            // This uses the implementation that Generation V utilized to determine what the visual effect
            // of this Pokemon should look like. This was lifted straight out of Bulbapedia:
            // https://bulbapedia.bulbagarden.net/wiki/Deerling_(Pok%C3%A9mon)
            // https://bulbapedia.bulbagarden.net/wiki/Sawsbuck_(Pok%C3%A9mon)
            switch (DateTime.Now.Month)
            {
                case 1: // January
                case 5: // May
                case 9: // September
                    return "spring";

                case 2: // February
                case 6: // June
                case 10: // October
                    return "summer";

                case 3: // March
                case 7: // July
                case 11: // November
                    return "autumn";

                case 4: // April
                case 8: // August
                case 12: // December
                    return "winter";
            }

            // This is apparently the default type in games after Generation V.
            // So we will default to that if, for whatever reason, we end up out here.
            // In theory, this won't ever happen.
            return "spring";

        }

        private static string CalculateMeloettaForme(Pokemon p)
        {
            return p.Name.ToLowerInvariant().Contains("step") ? "step" : "aria";
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

            // Order the pokemon collection (since National is STILL a string
            pokemonCollection.Pokemon = new ObservableCollection<Pokemon>(pokemonCollection.Pokemon.OrderBy(p => p.Pokedex.National));

            Container.RegisterInstance(pokemonCollection);
            Container.RegisterInstance(moveCollection);
            Container.RegisterInstance(abilityCollection);
        }

    }

}
