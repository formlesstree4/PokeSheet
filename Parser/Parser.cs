using System.Collections.Generic;
using System.Linq;
using Parser.Types;
using System;

namespace Parser
{


    public static class Parser
    {

        /// <summary>
        /// Parses the big move list.
        /// </summary>
        /// <param name="path">The path to the move list.</param>
        /// <returns></returns>
        public static List<Move> ParseMoves(string path)
        {
            var moveList = new List<Move>();

            // read in the file
            var file = System.IO.File.ReadAllLines(path).Where(s => 
                !string.IsNullOrEmpty(s) && !s.StartsWith("#")).ToList();

            // now we have an array of all the data.
            var currentMove = new Move();

            // Loop
            for (var i = 0; i < file.Count(); i++)
            {
                // Check
                if(file[i].Contains(":"))
                {

                    // item split
                    var split = file[i].Split(':');

                    // clean
                    split[0] = split[0].Trim();
                    split[1] = split[1].Trim();

                    // derp
                    switch(split[0].ToLowerInvariant())
                    {
                        case "move":
                            currentMove.Name = split[1];
                            break;
                        case "type":
                            currentMove.Type = split[1];
                            break;
                        case "frequency":
                            currentMove.Frequency = split[1];
                            break;
                        case "ac":
                            currentMove.Accuracy = split[1];
                            break;
                        case "range":
                            currentMove.Range = split[1];
                            break;
                        case "damage":
                            currentMove.Damage = split[1];
                            break;
                        case "class":
                            currentMove.Class = split[1];
                            break;
                        case "target":
                            currentMove.Targets = split[1];
                            break;
                        case "effect":
                            currentMove.Effect = split[1];
                            break;
                        case "contest_type":
                            currentMove.ContestType = split[1];
                            break;
                        case "appeal":
                            currentMove.Appeal = split[1];
                            break;
                        case "contest_effect":
                            currentMove.ContestEffect = split[1];
                            break;
                        case "special":

                            // okay, remove the first...whatever amount of stuff
                            // Grants <xyz>
                            currentMove.Special = split[1].Remove(0, 7);

                            break;
                    }

                }
                else
                {
                    // Add
                    moveList.Add(currentMove);

                    // create a new move
                    currentMove = new Move();
                }
            }


            return moveList;

        }

        /// <summary>
        /// Parses the big ability list.
        /// </summary>
        /// <param name="path">The path to the ability list.</param>
        /// <returns></returns>
        public static List<Ability> ParseAbilities(string path)
        {
            var abilityList = new List<Ability>();

            // read in the file
            var file = System.IO.File.ReadAllLines(path, System.Text.Encoding.UTF8).Where(s =>
                !string.IsNullOrEmpty(s) && !s.StartsWith("#")).ToList();

            // current ability
            var currentAbility = new Ability();
            var counter = 0;

            // loop
            foreach (var line in file)
            {
                
                // check
                if (line.Contains("&&"))
                {
                    abilityList.Add(currentAbility);
                    currentAbility = new Ability();
                    counter = 0;
                    continue;
                }

                // first line is the name
                switch(counter)
                {
                    case 0:
                        currentAbility.Name = line.Trim();
                        break;

                    case 1:
                        if (line.Contains("-"))
                        {
                            var lineData = line.Split('-').Select(f => f.Trim()).ToArray();
                            currentAbility.Activation = lineData[0];
                            currentAbility.Limit = lineData[1];
                        }
                        else
                        {
                            currentAbility.Activation = line;
                            currentAbility.Limit = "None";
                        }
                        break;

                    case 2:
                        // currentAbility.Keywords = line.Contains("Keyword") ? line.Remove(line.IndexOf(':')).Trim() : "None";
                        if(line.Contains("Keyword"))
                        {
                            currentAbility.Keywords = line.Replace("Keyword:", string.Empty).Trim();
                        }
                        else
                        {
                            currentAbility.Keywords = "None";
                            var effectLine = line;
                            if (effectLine.Contains("Effect:"))
                                effectLine = line.Remove(0, 8).Trim();
                            currentAbility.Effect = currentAbility.Effect + effectLine + " ";
                        }
                        break;

                    default:
                        var currentLine = line;
                        if (currentLine.Contains("Effect:"))
                            currentLine = line.Remove(0, 8).Trim();
                        currentAbility.Effect = currentAbility.Effect + currentLine + " ";
                        break;

                }

                counter++;

            }

            //// loop
            //foreach (var t in file)
            //{
            //    if(!t.Equals("&&"))
            //    {

            //        // check something
            //        if (t.Contains(":"))
            //            counter = 2;

            //        // checker
            //        switch(counter)
            //        {
            //            case 0:
            //                currentAbility.Name = t;
            //                break;
            //            case 1:
            //                currentAbility.Initialization = t;
            //                break;
            //            case 2:
            //                currentAbility.Effect = t.Split(':')[1].Trim();
            //                break;
            //            default:
            //                currentAbility.Details += (t + " ");
            //                break;

            //        }

            //        counter++;

            //    }
            //    else
            //    {
            //        counter = 0;
            //        abilityList.Add(currentAbility);
            //        currentAbility = new Ability();
            //    }
            //}

            return abilityList;
        }

        /// <summary>
        /// Parses the big Pokedex list.
        /// </summary>
        /// <param name="path">The path to the pokemon list.</param>
        /// <returns></returns>
        public static List<Pokemon> ParsePokemon(string path)
        {
            if (path.Trim().Equals(string.Empty))
                return new List<Pokemon>();
            var pkmList = new List<Pokemon>();
            var file = System.IO.File.ReadAllLines(path).Where(s =>
                !string.IsNullOrEmpty(s) && !s.StartsWith("#")).ToList();
            var currentPokemon = new Pokemon();
            for (var i = 0; i < file.Count +1; i++)
            {
                if(i >= file.Count)
                {
                    if (currentPokemon != new Pokemon() || !string.IsNullOrEmpty(currentPokemon.Name))
                    {
                        pkmList.Add(currentPokemon);
                        break;
                    }
                }

                if(!file[i].Contains(":"))
                {
                    if (currentPokemon != new Pokemon() || !string.IsNullOrEmpty(currentPokemon.Name))
                    {
                        pkmList.Add(currentPokemon);
                        currentPokemon = new Pokemon();
                        i++;
                        if (i >= file.Count)
                            break;    
                    }
                }

                var line = file[i];

                // split
                var dataArr = line.Split(':');
                var dataLocation = dataArr[0].ToLowerInvariant();
                var content = dataArr[1].Trim();
                int dummyInt;

                if (int.TryParse(dataLocation, out dummyInt))
                {
                    // moves.

                    // check, because you never know.
                    if(content.Contains(','))
                        foreach (var con in content.Split(',').Select(s => s.Trim()))
                            currentPokemon.Moves.Add(new PokemonMove { Level = dummyInt, Name = con });
                    else
                        currentPokemon.Moves.Add(new PokemonMove {Level = dummyInt, Name = content});
                }
                else
                {
                    switch (dataLocation)
                    {
                        case "name":
                            currentPokemon.Name = content;
                            break;

                        case "jp_name":
                            currentPokemon.JapaneseName = content;
                            break;

                        case "pta_num":
                            currentPokemon.PtaNumber = Convert.ToInt32(content);
                            break;

                        case "nat_num":
                            currentPokemon.NationalNumber = Convert.ToInt32(content);
                            break;

                        case "type_1":
                        case "type_2":
                            currentPokemon.Types.Add((Types.Types)Enum.Parse(typeof(Types.Types), content));
                            break;

                        case "heightus":

                            var height = new UsHeight();
                            var heightData = content.Split(' ');

                            height.Feet = Convert.ToInt32(heightData[0].TrimEnd('\''));
                            height.Inches = Convert.ToInt32(heightData[1].TrimEnd('\"'));

                            currentPokemon.HeightUs = height;
                            break;

                        case "heightsi":
                            currentPokemon.HeightSi = new SiHeight(Convert.ToDouble(content.TrimEnd('m')));
                            break;

                        case "heightclass":
                            currentPokemon.HeightClass = content;
                            break;

                        case "weightus":
                            currentPokemon.WeightUs = new UsWeight(Convert.ToDouble(content.Split(' ')[0].TrimEnd('.')));
                            break;

                        case "weightsi":
                            currentPokemon.WeightSi = new SiWeight(Convert.ToDouble(content.Split('k')[0]));
                            break;

                        case "weightclass":
                            currentPokemon.WeightClass = Convert.ToInt32(content);
                            break;

                        case "classification":
                            currentPokemon.Classification = content;
                            break;

                        case "dex_text":
                            currentPokemon.Description = content;
                            break;

                        case "diet":
                            currentPokemon.Diet = content.Split(',').Select(s => s.Trim()).ToList();
                            break;

                        case "habitat":
                            currentPokemon.Habitat = content.Split(',').Select(s => s.Trim()).ToList();
                            break;

                        case "gender":

                            if(content.ToLowerInvariant().Equals("no gender"))
                                currentPokemon.Gender = new Gender {Female = 0, Male = 0};
                            else
                            {
                                var genderList = content.Split('/').Select(s => s.Trim()).ToList();
                                currentPokemon.Gender = new Gender
                                {
                                    Male = Convert.ToDecimal(genderList[0].Split('%')[0]),
                                    Female = Convert.ToDecimal(genderList[1].Split('%')[0])
                                };    
                            }
                            break;

                        case "egg_group":
                            currentPokemon.EggGroups = content.Split('/').Select(s => s.Trim()).ToList();
                            break;

                        case "hatch_rate":
                            currentPokemon.HatchRate = content;
                            break;

                        case "stage_1":
                            currentPokemon.Stages.Add(new Stage {Requirement = "Hatch", Name = content});
                            break;

                        case "stage_2":
                        case "stage_3":

                            // requirement string.
                            string requirement;
                            string name;

                            // get the first instance of a gap.
                            var firstIndex = content.IndexOf(' ');

                            if(currentPokemon.Name != null && (currentPokemon.Name.ToLowerInvariant().Equals("mr. mime") || 
                                                               currentPokemon.Name.ToLowerInvariant().Equals("mime jr.")))
                            {
                                
                                // special case, get the 2nd index.
                                var secondIndex = content.IndexOf(' ', firstIndex + 1);

                                // remove up to 2nd index
                                requirement = content.Remove(0, secondIndex).Trim();
                                name = content.Substring(0, secondIndex);

                            }
                            else
                            {

                                // just gonna want the first index.
                                requirement = content.Remove(0, firstIndex).Trim();
                                name = content.Substring(0, firstIndex);

                            }

                            currentPokemon.Stages.Add(new Stage { Requirement = requirement, Name = name });
                            break;

                        case "base_stats":

                            var stats = content.Split(',').Select(s => s.Trim()).ToList();
                            currentPokemon.BaseStats = new Stats
                                                           {
                                                               Health = Convert.ToInt32(stats[0]),
                                                               Attack = Convert.ToInt32(stats[1]),
                                                               Defense = Convert.ToInt32(stats[2]),
                                                               SpecialAttack = Convert.ToInt32(stats[3]),
                                                               SpecialDefense = Convert.ToInt32(stats[4]),
                                                               Speed = Convert.ToInt32(stats[5])
                                                           };
                            break;

                        case "capabilities":

                            var capabilities = content.Split(',').Select(s => s.Trim()).ToList();
                            var caps = new Capabilities
                                           {
                                               Burrow = 0,
                                               Intelligence = 0,
                                               Jump = 0,
                                               Overland = 0,
                                               Power = 0,
                                               Sky = 0,
                                               Surface = 0,
                                               Underwater = 0
                                           };
                            foreach (var capability in capabilities)
                            {
                                if (capability.StartsWith("Burrow"))
                                {
                                    caps.Burrow = Convert.ToInt32(capability.Split(' ')[1]);
                                    continue;
                                }

                                if (capability.StartsWith("Intelligence"))
                                {
                                    caps.Intelligence = Convert.ToInt32(capability.Split(' ')[1]);
                                    continue;
                                }

                                if (capability.StartsWith("Jump"))
                                {
                                    caps.Jump = Convert.ToInt32(capability.Split(' ')[1]);
                                    continue;
                                }

                                if (capability.StartsWith("Overland"))
                                {
                                    caps.Overland = Convert.ToInt32(capability.Split(' ')[1]);
                                    continue;
                                }

                                if (capability.StartsWith("Power"))
                                {
                                    caps.Power = Convert.ToInt32(capability.Split(' ')[1]);
                                    continue;
                                }
                                int intTest;
                                if (capability.StartsWith("Sky") && Int32.TryParse(capability.Split(' ')[1], out intTest))
                                {
                                    caps.Sky = Convert.ToInt32(capability.Split(' ')[1]);
                                    continue;
                                }

                                if (capability.StartsWith("Surface"))
                                {
                                    caps.Surface = Convert.ToInt32(capability.Split(' ')[1]);
                                    continue;
                                }

                                if (capability.StartsWith("Underwater"))
                                {
                                    caps.Underwater = Convert.ToInt32(capability.Split(' ')[1]);
                                    continue;
                                }
                                if(caps.CustomCapabilities == null)
                                    caps.CustomCapabilities = new List<string>();
                                caps.CustomCapabilities.Add(capability);
                                    
                            }
                            currentPokemon.Capabilities = caps;

                            break;

                        case "basic_abilities":
                            currentPokemon.BasicAbilities = content.Contains("/")
                                                                ? content.Split('/').Select(s => s.Trim()).ToList()
                                                                : new List<string> {content};
                            
                            break;

                        case "high_abilities":
                            currentPokemon.HighAbilities = content.Contains("/")
                                                               ? content.Split('/').Select(s => s.Trim()).ToList()
                                                               : new List<string> {content};
                            break;

                        case "moves":

                            if(content.Contains(","))
                                foreach (var move in content.Split(',').Select(s => s.Trim()))
                                    currentPokemon.Moves.Add(new PokemonMove { Level = 0, Name = move });
                            else
                                currentPokemon.Moves.Add(new PokemonMove { Level = 0, Name = content });
                            
                            break;

                        case "tm_list":
                            currentPokemon.TM = content.Split(',').Select(s => s.Trim()).ToList();
                            break;

                        case "egg_moves":
                            currentPokemon.EggMoves = content.Split(',').Select(s => s.Trim()).ToList();
                            break;

                        case "tutor_moves":
                            currentPokemon.TutorMoves = content.Split(',').Select(s => s.Trim()).ToList();
                            break;

                    }
                }
            }

            return pkmList;

        }

        /// <summary>
        /// Parses the capabilities list.
        /// </summary>
        /// <param name="path">The path to the capabilities list.</param>
        /// <returns></returns>
        public static List<Capability> ParseCapabilities (string path)
        {
            var capabilityList = new List<Capability>();

            // read in the file
            var file = System.IO.File.ReadAllLines(path, System.Text.Encoding.UTF8).Where(s =>
                !string.IsNullOrEmpty(s) && !s.StartsWith("#")).Select(s => s.Replace("\r\n", string.Empty)).ToList();

            var currentCapability = new Capability();
            var inDescription = false;

            // begin looping.
            foreach (var line in file)
            {
                Console.WriteLine(line);
                if(line.Contains("&&"))
                {
                    capabilityList.Add(currentCapability);
                    currentCapability = new Capability();
                    inDescription = false;
                    continue;
                }
                if(!inDescription)
                {
                    if(line.Contains("-"))
                    {
                        // split
                        var lineData = line.Split('-').Select(s => s.Trim()).ToArray();
                        currentCapability.Name = lineData[0];
                        currentCapability.Type = lineData[1];
                    }
                    else
                    {
                        currentCapability.Name = line.Trim();
                        currentCapability.Type = "None";
                    }
                    inDescription = true;
                }
                else
                {
                    currentCapability.Description += line.Trim();
                }
            }

            return capabilityList;
        }

    }

    
    public class Parsing
    {

        private static int Menu()
        {

            Console.Clear();
            Console.WriteLine("Menu");
            Console.WriteLine("1) Moves");
            Console.WriteLine("2) Abilities");
            Console.WriteLine("3) Pokedex");
            Console.WriteLine("4) Capabilities");
            Console.WriteLine("5) Exit");
            Console.WriteLine();
            Console.WriteLine("Press 1 - 5 to continue");

            do
            {
                var key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        return 1;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        return 2;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        return 3;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        return 4;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        return 5;
                }
            } while (true);

        }

        public static void Capabilities(string location = "")
        {
            if (location == "")
            {
                Console.WriteLine("Drag and drop the move file and press enter...");
                location = Console.ReadLine();
            }
            var capabilityList = Parser.ParseCapabilities(location);

            // sort
            capabilityList.Sort((m1, m2) => String.CompareOrdinal(m1.Name, m2.Name));

            // write out
            foreach (var capability in capabilityList)
                Console.WriteLine(capability.Name);

            Console.WriteLine("There are {0} capabilities...", capabilityList.Count);
            Console.WriteLine("Saving...");

            var xml = new System.Xml.Serialization.XmlSerializer(typeof (List<Capability>));
            var path = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Files", "capabilities.xml");

            // serialize
            var stream = new System.IO.StreamWriter(path);
            xml.Serialize(stream, capabilityList);
            stream.Flush();
            stream.Close();
            Console.WriteLine("Done");
            Console.WriteLine("Output at {0}", path);

        }

        public static void Moves(string location = "")
        {
            if (location == "")
            {
                Console.WriteLine("Drag and drop the move file and press enter...");
                location = Console.ReadLine();
            }

            var moveList = Parser.ParseMoves(location);

            // sort
            moveList.Sort((m1, m2) => String.CompareOrdinal(m1.Type, m2.Type));

            foreach (var move in moveList)
                Console.WriteLine(move.Name);

            Console.WriteLine(string.Format("There are {0} moves in this list!", moveList.Count));
            Console.WriteLine("Saving to XML");

            var xml = new System.Xml.Serialization.XmlSerializer(typeof(List<Move>));
            var path = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Files", "move.xml");

            // serialize
            var stream = new System.IO.StreamWriter(path);
            xml.Serialize(stream, moveList);
            stream.Flush();
            stream.Close();
            Console.WriteLine("Done");
            Console.WriteLine("Output at {0}", path);

        }

        public static void Abilities(string location = "")
        {
            if (location == "")
            {
                Console.WriteLine("Drag and drop the abilities file and press enter...");
                location = Console.ReadLine();
            }
            var abilitiesList = Parser.ParseAbilities(location);

            abilitiesList.Sort((m1, m2) => String.CompareOrdinal(m1.Name, m2.Name));

            foreach (var move in abilitiesList)
                Console.WriteLine(move.Name);

            Console.WriteLine(string.Format("There are {0} abilities in this list!", abilitiesList.Count));
            Console.WriteLine("Saving to XML");

            var xml = new System.Xml.Serialization.XmlSerializer(typeof(List<Ability>));
            var path = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Files", "abilities.xml");

            var stream = new System.IO.StreamWriter(path);
            xml.Serialize(stream, abilitiesList);
            stream.Flush();
            stream.Close();
            Console.WriteLine("Done");
            Console.WriteLine("Output at {0}", path);

        }

        public static void Pokemon(string location = "")
        {
            if (location == "")
            {
                Console.WriteLine("Drag and drop the Pokemon file and press enter...");
                location = Console.ReadLine();
            }
            var pokemonList = Parser.ParsePokemon(location);

            pokemonList.Sort((m1, m2) => m1.NationalNumber.CompareTo(m2.NationalNumber));
            foreach (var pokemon in pokemonList)
                Console.WriteLine(pokemon.Name);

            Console.WriteLine(string.Format("There are {0} Pokemon in this list!", pokemonList.Count));
            Console.WriteLine("Saving to XML");

            var xml = new System.Xml.Serialization.XmlSerializer(typeof(List<Pokemon>));
            var path = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Files", "pokemon.xml");

            var stream = new System.IO.StreamWriter(path);
            xml.Serialize(stream, pokemonList);
            stream.Flush();
            stream.Close();
            Console.WriteLine("Done");
            Console.WriteLine("Output at {0}", path);

        }
       
        public static void Main(string[] args)
        {
            var exit = false;
            do
            {
                var menuResult = Menu();
                Console.Clear();

                switch (menuResult)
                {
                    case 1:
                        Moves();
                        break;

                    case 2:
                        Abilities();
                        break;

                    case 3:
                        Pokemon();
                        break;

                    case 4:
                        Capabilities();
                        break;
                    case 5:
                        exit = true;
                        break;

                }

            } while (!exit);

        }

    }

}