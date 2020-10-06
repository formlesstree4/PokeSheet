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
using System.Collections.Generic;

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
        ///     Gets the ViewModel used for the Main Window
        /// </summary>
        public static MainWindowViewModel MainViewModel => Container.Resolve<MainWindowViewModel>();

        /// <summary>
        ///     Gets the ViewModel used for the Sheet
        /// </summary>
        public static SheetViewModel PokemonSheetViewModel => Container.Resolve<SheetViewModel>();

        /// <summary>
        ///     Gets the Application Icon
        /// </summary>
        public static ImageSource ApplicationIcon => new BitmapImage(new Uri(Path.Combine(StartupPath, "Content", "Images", "app-icon.ico")));


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
        ///     Gets the absolute path where the Nature JSON file is located.
        /// </summary>
        public static string GetNatureFile => Path.Combine(StartupPath, "Content", "JSON", "natures.json");

        /// <summary>
        ///     Gets the absolute path where the Types JSON file is located.
        /// </summary>
        public static string GetTypesFile => Path.Combine(StartupPath, "Content", "JSON", "types.json");

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

        public static readonly Color NegativeStat = Color.FromArgb(255, 0, 198, 245);
        public static readonly Color PositiveStat = Color.FromArgb(255, 222, 23, 56);
        public static readonly Color NeutralStat = Color.FromArgb(255, 0, 0, 0);


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

        public static IEnumerable<string> RetrievePokemonGenders(Pokemon p)
        {
            var genders = new List<string>();
            if (p.Gender.Male > 0) genders.Add("Male");
            if (p.Gender.Female > 0) genders.Add("Female");
            if (!genders.Any()) genders.Add("Genderless");
            return genders;
        }

        public static string RetrieveTypeImagePath(PokemonType t) => Path.Combine(StartupPath, "Content", "Images", "Types", t.Icon);

        public static int GetExperienceForLevel(int level)
        {
            var levelToExperience = new[]
            {
                0,25,50,100,150,200,400,600,800,1000,1500,2000,3000,4000,5000,6000,
                7000,8000,9000,10000,11500,13000,14500,16000,17500,19000,20500,22000,
                23500,25000,27500,30000,32500,35000,37500,40000,42500,45000,47500,50000,
                55000,60000,65000,70000,75000,80000,85000,90000,95000
            };

            if (level < 0) level = 0;
            if (level >= 50) return 100000 + (10000 * (level - 50));
            return levelToExperience[level - 1];
        }

        public static int CalculateAvailablePoints(int level)
        {

            // Here's the variable that holds the number of points
            // we are allowed to have.
            var points = 0;


            /*
             * - From Levels 1 to 50, a Pokemon will gain 1 point PER level
             * 
             * - Starting at level 51, Pokemon gain two Added Stats per level gained. 
             *   These two stats may not be put into the same Stat. 
             *   When adding stats, a Pokemon’s Base Relation must still be maintained.
             * 
             * - Starting at level 76, Pokemon gain three Added Stats per level gained. 
             *   These three stats may not be put into the same Stat. 
             *   When adding stats, a Pokemon’s Base Relation must still be maintained.
             * 
             */


            if (level <= 50) return level - 1;

            // subtract 50 points from the current level.
            level -= 50;

            // add 50 points to counter balance the level.
            points += 50;

            // 51 - 50 = 1
            // 76 - 50 = 26
            // Now let's see if we are >= 26
            if (level >= 26)
            {
                // remove 25 and multiply by three.
                points += (level - 25) * 3;
                level -= (level - 25);
            }

            // any extra points are multiplied by 2.
            points += level * 2;

            // all done, subtract 1 because f*ck level 1. :D
            return points - 1;

        }

        public static int CalculateStab(int level)
        {
            return (int)Math.DivRem((long)level, 5, out _);
        }

        public static int CalculateHealth(int level, int hpStat)
        {
            return (hpStat * 3) + level;
        }


        private static string RetrieveImageForType(Pokemon p, string folderType)
        {
            var nationalId = p.Pokedex.National;
            var basePath = Path.Combine(StartupPath, "Content", "Images", folderType);
            string path;

            switch (nationalId)
            {
                case 386: // Deoxys
                    path = Path.Combine(basePath, nationalId.ToString(), $"{nationalId}-{CalculateDeoxysForme(p)}.png");
                    break;
                case 412: // Burmy
                case 413: // Wormadam
                    path = Path.Combine(basePath, nationalId.ToString(), $"{nationalId}-{CalculateBurmyForme(p)}.png");
                    break;
                case 479: // Rotom
                    path = Path.Combine(basePath, nationalId.ToString(), $"{nationalId}{CalculateRotomForme(p)}.png");
                    break;
                case 487: // Giratina
                    path = Path.Combine(basePath, nationalId.ToString(), $"{nationalId}-{CalculateGiratinaForme(p)}.png");
                    break;
                case 492: // Shaymin
                    path = Path.Combine(basePath, nationalId.ToString(), $"{nationalId}-{CalculateShayminForme(p)}.png");
                    break;
                case 585: // Deerling
                case 586: // Sawsbuck
                    path = Path.Combine(basePath, nationalId.ToString(), $"{nationalId}-{CalculateAppropriateSeason()}.png");
                    break;
                case 648: // Meloetta
                    path = Path.Combine(basePath, nationalId.ToString(), $"{nationalId}-{CalculateMeloettaForme(p)}.png");
                    break;
                default:
                    path = Path.Combine(basePath, $"{nationalId}.png");
                    break;
            }
            if (!File.Exists(path)) path = Path.Combine(StartupPath, "Content", "Images", "missing.png");
            return path;
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
            var rawNatureContent = File.ReadAllText(GetNatureFile);
            var rawTypesContent = File.ReadAllText(GetTypesFile);

            var pokemonCollection = JsonConvert.DeserializeObject<PokemonCollection>(rawPokemonContent);
            var moveCollection = JsonConvert.DeserializeObject<MoveCollection>(rawMoveContent);
            var abilityCollection = JsonConvert.DeserializeObject<AbilityCollection>(rawAbilityContent);
            var natureCollection = JsonConvert.DeserializeObject<NatureCollection>(rawNatureContent);
            var typeCollection = JsonConvert.DeserializeObject<TypesCollection>(rawTypesContent);

            // Order the Pokemon Collection
            pokemonCollection.Pokemon = new ObservableCollection<Pokemon>(pokemonCollection.Pokemon.OrderBy(p => p.Pokedex.National));

            Container.RegisterInstance(pokemonCollection);
            Container.RegisterInstance(moveCollection);
            Container.RegisterInstance(abilityCollection);
            Container.RegisterInstance(natureCollection);
            Container.RegisterInstance(typeCollection);

        }

    }

}
