using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using IniLibrary;
using Parser.Types;
using PokeSheet.Control.Sheet_Windows;
using PokeSheet.Properties;

namespace PokeSheet.Control
{
    public partial class Sheet : UserControl
    {

        private const int Max = 500;
        private string _notes;
        private string _held;
        private readonly Random _rnd = new Random();

        #region Events

        public event OnPokemonNameChange NameChanged = delegate { }; 
        public delegate void OnPokemonNameChange(object sender, PokemonNameChangeEventArgs e);

        #endregion

        public void SaveINI(string path = "")
        {
            if(string.IsNullOrEmpty(path))
            {
                var sfd = new SaveFileDialog {Title = Resources.SavePokemonToFile, Filter = Resources.IniFilter, FileName = string.Format("{0}.ini", Pokemon)};
                if (sfd.ShowDialog().Equals(DialogResult.OK))
                    path = sfd.FileName;
                else
                    return;
            }

            // okay, now we can save
            var ini = new INI();

            // add section, this pokemon
            ini.Add(Pokemon);

            // begin adding keys of necessary data.
            ini.Add(Pokemon, "nickname", tbNickname.Text);
            ini.Add(Pokemon, "level", nudLevel.Value);
            ini.Add(Pokemon, "experience", nudExperience.Value);
            ini.Add(Pokemon, "species", GetCurrentPokemon().ToString());
            ini.Add(Pokemon, "gender", cbGender.SelectedIndex);
            ini.Add(Pokemon, "nature", cbNature.SelectedIndex);
            ini.Add(Pokemon, "currentHp", nudCurrentHealth.Value);

            // stats
            ini.Add(Pokemon, "hp", nudAddedHp.Value);
            ini.Add(Pokemon, "atk", nudAddedAtk.Value);
            ini.Add(Pokemon, "def", nudAddedDef.Value);
            ini.Add(Pokemon, "spAtk", nudAddedSpAtk.Value);
            ini.Add(Pokemon, "spDef", nudAddedSpDef.Value);
            ini.Add(Pokemon, "speed", nudAddedSpeed.Value);

            // types
            ini.Add(Pokemon, "type1", cbTypeOne.SelectedIndex);
            ini.Add(Pokemon, "type2", cbTypeTwo.SelectedIndex);

            // Abilities
            if (lvAbilities.Items.Count > 0)
                ini.Add(Pokemon, "abilityOne", lvAbilities.Items[0].Text + "|" + lvAbilities.Items[0].Group.Name);
            if (lvAbilities.Items.Count > 1)
                ini.Add(Pokemon, "abilityTwo", lvAbilities.Items[1].Text + "|" + lvAbilities.Items[1].Group.Name);

            // add moves
            ini.Add(Pokemon, "moveCount", lvMoves.Items.Count);
            for (var i = 0; i < lvMoves.Items.Count; i++)
                ini.Add(Pokemon, string.Format("move{0}", i), string.Format("{0}:{1}", lvMoves.Items[i].Text.ToString(CultureInfo.InvariantCulture), lvMoves.Items[i].Group.Name));

            // Lastly, notes
            ini.Add(Pokemon, "notes", _notes);
            ini.Add(Pokemon, "held", _held);

            // And save!
            ini.Save(path, INI.Type.INI);

        }
        public void LoadINI(string path = "")
        {
            if(string.IsNullOrEmpty(path))
            {
                var ofd = new OpenFileDialog {Title = Resources.OpenPokemonFile, Filter = Resources.IniFilter};
                if (ofd.ShowDialog().Equals(DialogResult.OK))
                    path = ofd.FileName;
                else
                    return;
            }
            
            var ini = new INI();
            ini.Load(path, INI.Type.INI);

            // this is our section!
            var sectionName = ini.Sections.ToList()[0];

            // do this first just to be sure.
            tbNickname.Text = ini.GetKeyValue(sectionName, "nickname", string.Empty);

            // get the species
            var species = ini.GetKeyValue(sectionName, "species", "Bulbasaur");
            int speciesIndex;
            
            // perform a little check; backwards compatibility ftw.
            if (int.TryParse(species, out speciesIndex))
                cbSpecies.SelectedIndex = speciesIndex;
            else
                cbSpecies.SelectedItem = species;

            // do the rest.
            cbGender.SelectedIndex = ini.GetKeyValue(sectionName, "gender", 0);
            cbNature.SelectedIndex = ini.GetKeyValue(sectionName, "nature", 0);

            // now level, experience, and stats.
            nudLevel.Value = ini.GetKeyValue(sectionName, "level", (decimal) 1);
            nudExperience.Value = ini.GetKeyValue(sectionName, "experience", (decimal) 0);
            nudAddedHp.Value = Math.Min(ini.GetKeyValue(sectionName, "hp", (decimal) 0), nudAddedHp.Maximum);
            nudAddedAtk.Value = Math.Min(ini.GetKeyValue(sectionName, "atk", (decimal) 0), nudAddedAtk.Maximum);
            nudAddedDef.Value = Math.Min(ini.GetKeyValue(sectionName, "def", (decimal) 0), nudAddedDef.Maximum);
            nudAddedSpAtk.Value = Math.Min(ini.GetKeyValue(sectionName, "spAtk", (decimal) 0), nudAddedSpAtk.Maximum);
            nudAddedSpDef.Value = Math.Min(ini.GetKeyValue(sectionName, "spDef", (decimal) 0), nudAddedSpDef.Maximum);
            nudAddedSpeed.Value = Math.Min(ini.GetKeyValue(sectionName, "speed", (decimal) 0), nudAddedSpeed.Maximum);

            // default data.
            nudCurrentHealth.Value = Math.Min(ini.GetKeyValue(sectionName, "currentHp", (decimal) 1), nudCurrentHealth.Maximum);

            // hurr types
            cbTypeOne.SelectedIndex = ini.GetKeyValue(sectionName, "type1", cbTypeOne.Items.Count - 1);
            cbTypeTwo.SelectedIndex = ini.GetKeyValue(sectionName, "type2", cbTypeTwo.Items.Count - 1);

            // moves
            for (var i = 0; i < ini.GetKeyValue(sectionName, "moveCount", 0); i++)
            {

                // get the move name.
                var moveInfo = ini.GetKeyValue(sectionName, string.Format("move{0}", i), string.Empty);
                var moveName = moveInfo.Split(':')[0];
                var moveGroup = moveInfo.Split(':')[1];
                
                // check this
                if (!Static.Moves.Exists(m => m.Name.ToLowerInvariant().Equals(moveName.ToLowerInvariant()))) continue;

                // load the move data
                var moveData = Static.Moves.First(m => m.Name.ToLowerInvariant().Equals(moveName.ToLowerInvariant()));

                // we have the move data, now process
                var lvi = new ListViewItem
                              {
                                  Text = moveName,
                                  Group = lvMoves.Groups[moveGroup],
                                  ToolTipText = moveData.Effect,
                                  Tag = moveData
                              };

                // add it
                lvMoves.Items.Add(lvi);

            }

            // abilities
            if(ini.Contains(sectionName, "abilityOne"))
            {

                // grab and split
                var abilityInformation = ini.GetKeyValue(sectionName, "abilityOne", "|").Split('|');
                var ability =
                    Static.Abilities.First(
                        a => a.Name.ToLowerInvariant().Equals(abilityInformation[0].ToLowerInvariant()));
                var lvi = new ListViewItem
                              {
                                  Text = ability.Name,
                                  Group = lvAbilities.Groups[abilityInformation[1]],
                                  ToolTipText =
                                      string.Format("Activation: {0}\nLimit: {1}\nKeywords: {2}\nEffect: {3}",
                                                    ability.Activation, ability.Limit,
                                                    ability.Keywords, ability.Effect)
                              };
                lvAbilities.Items.Add(lvi);
            }

            if(ini.Contains(sectionName, "abilityTwo"))
            {
                // grab and split
                var abilityInformation = ini.GetKeyValue(sectionName, "abilityTwo", "|").Split('|');
                var ability =
                    Static.Abilities.First(
                        a => a.Name.ToLowerInvariant().Equals(abilityInformation[0].ToLowerInvariant()));
                var lvi = new ListViewItem
                {
                    Text = ability.Name,
                    Group = lvAbilities.Groups[abilityInformation[1]],
                    ToolTipText =
                        string.Format("Activation: {0}\nLimit: {1}\nKeywords: {2}\nEffect: {3}",
                                                    ability.Activation, ability.Limit,
                                                    ability.Keywords, ability.Effect)
                };
                lvAbilities.Items.Add(lvi);
            }

            // notes
            _notes = ini.GetKeyValue(sectionName, "notes", string.Empty);
            _held = ini.GetKeyValue(sectionName, "held", string.Empty);
            CalculateCustomCapabilities();

        }
        public Sheet()
        {
            InitializeComponent();
            nudLevel.Maximum = Max;
        }

        public string Pokemon { get; set; }
        public void LoadPokemon(object[] pokemon)
        {
            cbSpecies.Items.Clear();
            cbSpecies.Items.AddRange(pokemon.Where(p => p != null).ToArray());
            cbSpecies.SelectedIndex = 0;
        }
        public void GeneratePokemonSimple(int pkm, int lowLevel, int highLevel, bool randomNature, bool randomGender, bool randomEv)
        {
            
            // just select the appropriate location
            cbSpecies.SelectedIndex = pkm;

            // generate the proper level.
            nudLevel.Value = _rnd.Next(lowLevel, highLevel + 1);

            // generate random nature if applicable
            if (randomNature)
                cbNature.SelectedIndex = _rnd.Next(0, cbNature.Items.Count);

            // same with gender.
            if (randomGender && cbGender.Enabled)
                cbGender.SelectedIndex = _rnd.Next(0, cbGender.Items.Count);

            // and lastly, ev's
            if (randomEv)
                CalculateRandomEffortValues();

        }
        public void InitializeSheet()
        {
            nudExperience.Maximum = CalculateExperience(Max);
            cbNature.SelectedIndex = 0;
            CalculateEvasion();
            CalculateMaxPoints();
            lvCapabilities.TileSize = new Size(lvCapabilities.Width - 4, lvCapabilities.Font.Height + 2);
            lvAbilities.TileSize = new Size(lvAbilities.Width - 30, lvAbilities.Font.Height + 2);
            lvMoves.TileSize = new Size(lvMoves.Width - 4, lvMoves.Font.Height + 2);
            lvCapabilities.ListViewItemSorter = new LvSort();
            lblStab.Text = CalculateStab((double)nudLevel.Value).ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Calculates the current season using approximate dates.
        /// </summary>
        /// <returns>A string that contains the season</returns>
        private static string CalculateSeason()
        {
            // winter - 0
            // spring - 1
            // summer - 2
            // fall - 3
            var doy = DateTime.Now.DayOfYear - Convert.ToInt32((DateTime.IsLeapYear(DateTime.Now.Year)) && DateTime.Now.DayOfYear > 59);
            return ((doy < 80 || doy >= 355) ? "winter" : ((doy >= 80 && doy < 172) ? "spring" : ((doy >= 172 && doy < 266) ? "summer" : "fall")));
        }

        private string CalculateDeoxys()
        {
            var species = GetCurrentPokemon().Name.ToLowerInvariant();
            if (species.Contains("attack")) return "attack";
            if (species.Contains("defense")) return "defense";
            if (species.Contains("speed")) return "speed";
            return "normal";
        }
        private string CalculateWormadam()
        {
            var species = GetCurrentPokemon().Name.ToLowerInvariant();
            if (species.Contains("plant")) return "plant";
            if (species.Contains("sandy")) return "sandy";
            return "trash";
        }
        private string CalculateShaymin()
        {
            return GetCurrentPokemon().Name.ToLowerInvariant().Contains("sky") ? "sky" : "land";
        }
        private string CalculateMeloetta()
        {
            return GetCurrentPokemon().Name.ToLowerInvariant().Contains("step") ? "step" : "aria";
        }
        private string CalculateGiratina()
        {
            return GetCurrentPokemon().Name.ToLowerInvariant().Contains("origin") ? "origin" : "altered";
        }

        private int CalculatePoints()
        {
            
            // Here's the variable that holds the number of points
            // we are allowed to have.
            var points = 0;

            // get the current value of the level.
            var level = (int)nudLevel.Value;

            // check
            if (level <= 50)
                return level - 1;

            // subtract 50 points from the current level.
            level -= 50;

            // add 50 points to counter balance the level.
            points += 50;

            /*
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

            // 51 - 50 = 1
            // 76 - 50 = 26
            // Now let's see if we are >= 26
            if(level >= 26)
            {
                // remove 25 and multiply by three.
                points += (level - 25)*3;
                level -= (level - 25);
            }

            // any extra points are multiplied by 2.
            points += level*2;

            // all done, subtract 1 because f*ck level 1. :D
            return points - 1;

        }
        private static int CalculateExperience(int level)
        {
            var levelArr = new[]
                               {
                                   0, 10, 20, 65, 125, 215, 345, 510, 730, 1000, 1330,
                                   1730, 2200, 2745, 3475, 4100, 4915, 5830, 6860, 8000, 
                                   9260, 10650, 12200, 13800, 15650, 17600, 19700, 21800, 
                                   23500, 25500, 26500, 28500, 29800, 31000, 34000, 37000, 
                                   40000, 43000, 47000, 51000, 55000, 59000, 63000, 68000, 
                                   72000, 77000, 83000, 88000, 93000, 100000
                               };
            if (level <= 50 && level > 0) return levelArr[level - 1];
            if (level > 50) return 100000 + (10000*(level - 50));
            return 1;
        }
        private static int CalculateStab(double level)
        {
            long divRem;
            return (int)Math.DivRem((long) level, 5, out divRem);
        }
        private static int CalculateLevel(int experience)
        {
            for (var i = 1; i <= Max + 1; i++)
            {
                if (experience < CalculateExperience(i))
                    return i - 1;
            }
            return 1;
        }
        private static int CalculateHP(int hpCount, int level)
        {
            return (hpCount*3) + level;
        }
        private void CalculateColor(int nature)
        {
            lblHP.ForeColor = Color.Black;
            lblAtk.ForeColor = Color.Black;
            lblDef.ForeColor = Color.Black;
            lblSpAtk.ForeColor = Color.Black;
            lblSpDef.ForeColor = Color.Black;
            lblSpeed.ForeColor = Color.Black;

            switch(nature)
            {

                #region HP
                case 0:
                    lblHP.ForeColor = Color.LightSkyBlue;
                    lblAtk.ForeColor = Color.PaleVioletRed;
                    break;
                case 1:
                    lblHP.ForeColor = Color.LightSkyBlue;
                    lblDef.ForeColor = Color.PaleVioletRed;
                    break;
                case 2:
                    lblHP.ForeColor = Color.LightSkyBlue;
                    lblSpAtk.ForeColor = Color.PaleVioletRed;
                    break;
                case 3:
                    lblHP.ForeColor = Color.LightSkyBlue;
                    lblSpDef.ForeColor = Color.PaleVioletRed;
                    break;
                case 4:
                    lblHP.ForeColor = Color.LightSkyBlue;
                    lblSpeed.ForeColor = Color.PaleVioletRed;
                    break;
                #endregion

                #region Attack
                case 5:
                    lblAtk.ForeColor = Color.LightSkyBlue;
                    lblHP.ForeColor = Color.PaleVioletRed;
                    break;
                case 6:
                    lblAtk.ForeColor = Color.LightSkyBlue;
                    lblDef.ForeColor = Color.PaleVioletRed;
                    break;
                case 7:
                    lblAtk.ForeColor = Color.LightSkyBlue;
                    lblSpAtk.ForeColor = Color.PaleVioletRed;
                    break;
                case 8:
                    lblAtk.ForeColor = Color.LightSkyBlue;
                    lblSpDef.ForeColor = Color.PaleVioletRed;
                    break;
                case 9:
                    lblAtk.ForeColor = Color.LightSkyBlue;
                    lblSpeed.ForeColor = Color.PaleVioletRed;
                    break;
                #endregion

                #region Defense
                case 10:
                    lblDef.ForeColor = Color.LightSkyBlue;
                    lblHP.ForeColor = Color.PaleVioletRed;
                    break;
                case 11:
                    lblDef.ForeColor = Color.LightSkyBlue;
                    lblAtk.ForeColor = Color.PaleVioletRed;
                    break;
                case 12:
                    lblDef.ForeColor = Color.LightSkyBlue;
                    lblSpAtk.ForeColor = Color.PaleVioletRed;
                    break;
                case 13:
                    lblDef.ForeColor = Color.LightSkyBlue;
                    lblSpDef.ForeColor = Color.PaleVioletRed;
                    break;
                case 14:
                    lblDef.ForeColor = Color.LightSkyBlue;
                    lblSpeed.ForeColor = Color.PaleVioletRed;
                    break;
                #endregion

                #region Special Attack
                case 15:
                    lblSpAtk.ForeColor = Color.LightSkyBlue;
                    lblHP.ForeColor = Color.PaleVioletRed;
                    break;
                case 16:
                    lblSpAtk.ForeColor = Color.LightSkyBlue;
                    lblAtk.ForeColor = Color.PaleVioletRed;
                    break;
                case 17:
                    lblSpAtk.ForeColor = Color.LightSkyBlue;
                    lblDef.ForeColor = Color.PaleVioletRed;
                    break;
                case 18:
                    lblSpAtk.ForeColor = Color.LightSkyBlue;
                    lblSpDef.ForeColor = Color.PaleVioletRed;
                    break;
                case 19:
                    lblSpAtk.ForeColor = Color.LightSkyBlue;
                    lblHP.ForeColor = Color.PaleVioletRed;
                    break;
                #endregion

                #region Special Defense
                case 20:
                    lblSpDef.ForeColor = Color.LightSkyBlue;
                    lblHP.ForeColor = Color.PaleVioletRed;
                    break;
                case 21:
                    lblSpDef.ForeColor = Color.LightSkyBlue;
                    lblAtk.ForeColor = Color.PaleVioletRed;
                    break;
                case 22:
                    lblSpDef.ForeColor = Color.LightSkyBlue;
                    lblDef.ForeColor = Color.PaleVioletRed;
                    break;
                case 23:
                    lblSpDef.ForeColor = Color.LightSkyBlue;
                    lblSpAtk.ForeColor = Color.PaleVioletRed;
                    break;
                case 24:
                    lblSpDef.ForeColor = Color.LightSkyBlue;
                    lblSpeed.ForeColor = Color.PaleVioletRed;
                    break;

                #endregion

                #region Speed
                case 25:
                    lblSpeed.ForeColor = Color.LightSkyBlue;
                    lblHP.ForeColor = Color.PaleVioletRed;
                    break;
                case 26:
                    lblSpeed.ForeColor = Color.LightSkyBlue;
                    lblAtk.ForeColor = Color.PaleVioletRed;
                    break;
                case 27:
                    lblSpeed.ForeColor = Color.LightSkyBlue;
                    lblDef.ForeColor = Color.PaleVioletRed;
                    break;
                case 28:
                    lblSpeed.ForeColor = Color.LightSkyBlue;
                    lblSpAtk.ForeColor = Color.PaleVioletRed;
                    break;
                case 29:
                    lblSpeed.ForeColor = Color.LightSkyBlue;
                    lblSpDef.ForeColor = Color.PaleVioletRed;
                    break;
                #endregion

            }
        }
        private static int CalculateNature(int nature, int stat)
        {
            // figure out the stat first
            switch(stat)
            {
                case 0: // hp.
                    switch (nature)
                    {
                        case 0: case 1: case 2: case 3: case 4:
                            return 1;
                        case 5: case 10: case 15: case 20: case 25:
                            return -1;
                    }
                    break;

                case 1: // atk.
                    switch (nature)
                    {
                        case 5: case 6: case 7: case 8: case 9:
                            return 2;
                        case 0: case 11: case 16: case 21: case 26:
                            return -2;
                    }
                    break;

                case 2: // def.
                    switch (nature)
                    {
                        case 10: case 11: case 12: case 13:case 14:
                            return 2;
                        case 1: case 6: case 17: case 22: case 27:
                            return -2;
                    }
                    break;

                case 3: // sp atk.
                    switch (nature)
                    {
                        case 15: case 16: case 17: case 18: case 19:
                            return 2;
                        case 2: case 7: case 12: case 23: case 28:
                            return -2;
                    }
                    break;

                case 4: // sp def.
                    switch (nature)
                    {
                        case 20: case 21: case 22: case 23: case 24:
                            return 2;
                        case 3: case 8: case 13: case 18: case 29:
                            return -2;
                    }
                    break;

                case 5: // speed.
                    switch (nature)
                    {
                        case 25: case 26: case 27: case 28: case 29:
                            return 2;
                        case 4: case 9: case 14: case 19: case 24:
                            return -2;
                    }
                    break;
                default:
                    return 0;
            }
            return 0;
        }
        private void CalculateEvasion()
        {
            tbPhysicalBonus.Text = (Convert.ToInt32(tbFinalDef.Text)/5).ToString(CultureInfo.InvariantCulture);
            tbSpecialBonus.Text = (Convert.ToInt32(tbFinalSpDef.Text)/5).ToString(CultureInfo.InvariantCulture);
            tbSpeedBonus.Text = (Convert.ToInt32(tbFinalSpeed.Text)/10).ToString(CultureInfo.InvariantCulture);
        }
        private int CalculateIncreaseAllowed()
        {
            return Math.Max(CalculatePoints() - (int)(nudAddedAtk.Value + nudAddedDef.Value + nudAddedHp.Value + nudAddedSpAtk.Value + nudAddedSpDef.Value +
                    nudAddedSpeed.Value), 0);
        }
        private void CalculateMaxPoints()
        {
            var increase = CalculateIncreaseAllowed();
            nudAddedHp.Maximum = nudAddedHp.Value + increase;
            nudAddedAtk.Maximum = nudAddedAtk.Value + increase;
            nudAddedDef.Maximum = nudAddedDef.Value + increase;
            nudAddedSpAtk.Maximum = nudAddedSpAtk.Value + increase;
            nudAddedSpDef.Maximum = nudAddedSpDef.Value + increase;
            nudAddedSpeed.Maximum = nudAddedSpeed.Value + increase;
            nudLevel.Minimum = increase == 0 ? nudLevel.Value : 1;
            gbStats.Text = string.Format("Stats - {0} {1} remaining", increase, increase.Equals(1) ? "point" : "points");
        }
        private void CalculateHealthLimits()
        {
            nudCurrentHealth.Maximum = Convert.ToInt32(tbMaxHealth.Text);
            nudCurrentHealth.Minimum = -1 * (2 *Convert.ToInt32(tbMaxHealth.Text));
        }
        private void CalculateCapabilities()
        {

            // who's the current pokemon
            var currentPkm = GetCurrentPokemon();

            // capabilities
            lvCapabilities.Items.Clear();

            // add the basic capabilities
            var cap = currentPkm.Capabilities;

            // add individual
            lvCapabilities.Items.Add(new ListViewItem
            {
                Group = lvCapabilities.Groups[0],
                Text = string.Format("Burrow: {0}", cap.Burrow),
                Tag = cap.Burrow,
                ToolTipText = ExtraInformation.Burrow(cap.Burrow)

            });
            lvCapabilities.Items.Add(new ListViewItem
            {
                Group = lvCapabilities.Groups[0],
                Text = string.Format("Intelligence: {0}", cap.Intelligence),
                Tag = cap.Intelligence,
                ToolTipText = ExtraInformation.Intelligence(cap.Intelligence)
            });
            lvCapabilities.Items.Add(new ListViewItem
            {
                Group = lvCapabilities.Groups[0],
                Text = string.Format("Jump: {0}", cap.Jump),
                Tag = cap.Jump,
                ToolTipText = ExtraInformation.Jump(cap.Jump)
            });
            lvCapabilities.Items.Add(new ListViewItem
            {
                Group = lvCapabilities.Groups[0],
                Text = string.Format("Overland: {0}", cap.Overland),
                Tag = cap.Overland,
                ToolTipText = ExtraInformation.Overland(cap.Overland)
            });
            lvCapabilities.Items.Add(new ListViewItem
            {
                Group = lvCapabilities.Groups[0],
                Text = string.Format("Power: {0}", cap.Power),
                Tag = cap.Power,
                ToolTipText = ExtraInformation.Power(cap.Power)
            });
            lvCapabilities.Items.Add(new ListViewItem
            {
                Group = lvCapabilities.Groups[0],
                Text = string.Format("Sky: {0}", cap.Sky),
                Tag = cap.Sky,
                ToolTipText = ExtraInformation.Sky(cap.Sky)
            });
            lvCapabilities.Items.Add(new ListViewItem
            {
                Group = lvCapabilities.Groups[0],
                Text = string.Format("Surface: {0}", cap.Surface),
                Tag = cap.Surface,
                ToolTipText = ExtraInformation.Surface(cap.Surface)
            });
            lvCapabilities.Items.Add(new ListViewItem
            {
                Group = lvCapabilities.Groups[0],
                Text = string.Format("Underwater: {0}", cap.Underwater),
                Tag = cap.Underwater,
                ToolTipText = ExtraInformation.Underwater(cap.Underwater)
            });
        }
        private void CalculateCustomCapabilities()
        {

            // Keep track.
            var capabilities = new List<string>();
            
            // Get our moves
            var moveNames = lvMoves.Items.Cast<ListViewItem>().Select(i => i.Text).Where(i => !string.IsNullOrEmpty(i)).ToList();

            // Now, start figuring out what items to add.
            foreach (var move in moveNames.Select(moveName => Static.Moves.First(m => m.Name.ToLowerInvariant() == moveName.ToLowerInvariant())))
            {

                // Brilliant, check to see if the move has any custom capabilities
                if(!string.IsNullOrEmpty(move.Special) && !capabilities.Contains(move.Special))
                {
                    capabilities.Add(move.Special);
                    lvCapabilities.Items.Add(new ListViewItem {Text = move.Special, Group = lvCapabilities.Groups[1], 
                        ToolTipText = Static.Capabilities.Select(s => s.Name.ToLowerInvariant()).Contains(move.Special.ToLowerInvariant()) ? Static.Capabilities.First(f => f.Name.ToLowerInvariant() == move.Special.ToLowerInvariant()).Description : "This capability doesn't exist yet"});
                }

            }          

        }
        private void CalculateRandomEffortValues()
        {
            // set everything to zero.
            nudAddedHp.Value = 0;
            nudAddedAtk.Value = 0;
            nudAddedDef.Value = 0;
            nudAddedSpAtk.Value = 0;
            nudAddedSpDef.Value = 0;
            nudAddedSpeed.Value = 0;

            while (CalculateIncreaseAllowed() > 0)
            {
                switch (_rnd.Next(0, 6))
                {
                    case 0:
                        nudAddedHp.Value += 1;
                        break;

                    case 1:
                        nudAddedAtk.Value += 1;
                        break;

                    case 2:
                        nudAddedDef.Value += 1;
                        break;

                    case 3:
                        nudAddedSpAtk.Value += 1;
                        break;

                    case 4:
                        nudAddedSpDef.Value += 1;
                        break;

                    case 5:
                        nudAddedSpeed.Value += 1;
                        break;
                }
            }
        }
        private void CanAddAbility()
        {

            // check for two or 1 and below 40.
            if (lvAbilities.Items.Count.Equals(2) || (lvAbilities.Items.Count.Equals(1) && nudLevel.Value < 40))
            {

                // can't add
                addAbilityToolStripMenuItem.Enabled = false;

            }
            else
            {

                // we either have no abilities, or we are above 40
                addAbilityToolStripMenuItem.Enabled = true;

            }

        }
        private Image CalculatePokemonImage(int nationalId)
        {

            // build the directory
            var directory = System.IO.Path.Combine(Application.StartupPath, "Resources");
            string imagePath;

            // check a few things
            switch(nationalId)
            {
                case 386:
                    imagePath = System.IO.Path.Combine(directory, nationalId.ToString(CultureInfo.InvariantCulture),
                                                       string.Format("{0}-{1}.png", nationalId, CalculateDeoxys()));
                    break;
                case 412:
                case 413:
                    imagePath = System.IO.Path.Combine(directory, nationalId.ToString(CultureInfo.InvariantCulture),
                                                       string.Format("{0}-{1}.png", nationalId, CalculateWormadam()));
                    break;
                case 479:
                    // TODO: All of Rotom needs to be done
                    //imagePath = System.IO.Path.Combine(directory, nationalId.ToString(CultureInfo.InvariantCulture),
                    //                                   string.Format("{0}-{1}.png", nationalId, CalculateGiratina()));
                    imagePath = System.IO.Path.Combine(directory, nationalId.ToString(CultureInfo.InvariantCulture), $"{nationalId}.png");
                    break;
                case 487:
                    imagePath = System.IO.Path.Combine(directory, nationalId.ToString(CultureInfo.InvariantCulture),
                                                       string.Format("{0}-{1}.png", nationalId, CalculateGiratina()));
                    break;
                case 492:
                    imagePath = System.IO.Path.Combine(directory, nationalId.ToString(CultureInfo.InvariantCulture),
                                                       string.Format("{0}-{1}.png", nationalId, CalculateShaymin()));
                    break;
                case 585:
                case 586:
                    imagePath = System.IO.Path.Combine(directory, nationalId.ToString(CultureInfo.InvariantCulture), 
                                                       string.Format("{0}-{1}.png", nationalId, CalculateSeason()));
                    break;
                case 648:
                    imagePath = System.IO.Path.Combine(directory, nationalId.ToString(CultureInfo.InvariantCulture),
                                                       string.Format("{0}-{1}.png", nationalId, CalculateMeloetta()));
                    break;
                default:
                    imagePath = System.IO.Path.Combine(directory, string.Format("{0}.png", nationalId));
                    break;
            }

            if (System.IO.Directory.Exists(directory) && System.IO.File.Exists(imagePath))
                return Image.FromFile(imagePath);
            return Resources.imgNotFound;

        }
        
        private void CboxExpCheckedChanged(object sender, EventArgs e)
        {
            if (cboxExp.Checked) nudExperience.Value = CalculateExperience((int)nudLevel.Value);
        }
        private void CbSpeciesSelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSpecies.SelectedIndex <= -1 || cbSpecies.SelectedItem is null) return;

            // who's the current pokemon
            var currentPkm = GetCurrentPokemon();

            // grab the current item and cast it
            // as a pokemon, then assign the img to the picture box
            // dispose the current one.
            if(pbPokemon.BackgroundImage != null)
                pbPokemon.BackgroundImage.Dispose();
            pbPokemon.BackgroundImage = CalculatePokemonImage(currentPkm.NationalNumber);

            // hp
            nudBaseHP.Minimum = currentPkm.BaseStats.Health;
            nudBaseHP.Maximum = currentPkm.BaseStats.Health;

            // atk
            nudBaseAtk.Minimum = currentPkm.BaseStats.Attack;
            nudBaseAtk.Maximum = currentPkm.BaseStats.Attack;

            // def
            nudBaseDef.Minimum = currentPkm.BaseStats.Defense;
            nudBaseDef.Maximum = currentPkm.BaseStats.Defense;

            // sp atk
            nudBaseSpAtk.Minimum = currentPkm.BaseStats.SpecialAttack;
            nudBaseSpAtk.Maximum = currentPkm.BaseStats.SpecialAttack;

            // sp def
            nudBaseSpDef.Minimum = currentPkm.BaseStats.SpecialDefense;
            nudBaseSpDef.Maximum = currentPkm.BaseStats.SpecialDefense;

            // speed
            nudBaseSpeed.Minimum = currentPkm.BaseStats.Speed;
            nudBaseSpeed.Maximum = currentPkm.BaseStats.Speed;

            // now gender determination!
            var gen = currentPkm.Gender;

            // female?
            if(gen.Female == 100)
            {
                cbGender.Items.Clear();
                cbGender.Items.Add("Female");
                cbGender.SelectedIndex = 0;
                cbGender.Enabled = false;
            }

            // male?
            if (gen.Male == 100)
            {
                cbGender.Items.Clear();
                cbGender.Items.Add("Male");
                cbGender.SelectedIndex = 0;
                cbGender.Enabled = false;
            }

            // no gender?
            if (gen.Male == 0 && gen.Female == 0)
            {
                cbGender.Items.Clear();
                cbGender.Items.Add("No Gender");
                cbGender.SelectedIndex = 0;
                cbGender.Enabled = false;
            }

            // all genders allowed?
            if (gen.Male > 0 && gen.Male < 100)
            {
                cbGender.Items.Clear();
                cbGender.Items.Add("Male");
                cbGender.Items.Add("Female");
                cbGender.SelectedIndex = 0;
                cbGender.Enabled = true;
            }
            
            CalculateCapabilities();
            CalculateCustomCapabilities();
            lvAbilities.Items.Clear();
            CanAddAbility();

            // set the nickname
            CalculatePokemonTabName();

            // load the types
            cbTypeOne.SelectedItem = currentPkm.Types[0].ToString();
            cbTypeTwo.SelectedItem = currentPkm.Types.Count > 1 ? currentPkm.Types[1].ToString() : "None";

        }
        private void CbNatureSelectedIndexChanged(object sender, EventArgs e)
        {
            tbFinalHP.Text = (nudBaseHP.Value + nudAddedHp.Value + CalculateNature(cbNature.SelectedIndex, 0)).ToString(CultureInfo.InvariantCulture);
            tbMaxHealth.Text = CalculateHP((int)(nudBaseHP.Value + nudAddedHp.Value + CalculateNature(cbNature.SelectedIndex, 0)), (int)nudLevel.Value).ToString(CultureInfo.InvariantCulture);
            tbFinalAtk.Text = (nudBaseAtk.Value + nudAddedAtk.Value + CalculateNature(cbNature.SelectedIndex, 1)).ToString(CultureInfo.InvariantCulture);
            tbFinalDef.Text = (nudBaseDef.Value + nudAddedDef.Value + CalculateNature(cbNature.SelectedIndex, 2)).ToString(CultureInfo.InvariantCulture);
            tbFinalSpAtk.Text = (nudBaseSpAtk.Value + nudAddedSpAtk.Value + CalculateNature(cbNature.SelectedIndex, 3)).ToString(CultureInfo.InvariantCulture);
            tbFinalSpDef.Text = (nudBaseSpDef.Value + nudAddedSpDef.Value + CalculateNature(cbNature.SelectedIndex, 4)).ToString(CultureInfo.InvariantCulture);
            tbFinalSpeed.Text = (nudBaseSpeed.Value + nudAddedSpeed.Value + CalculateNature(cbNature.SelectedIndex, 5)).ToString(CultureInfo.InvariantCulture);
            CalculateColor(cbNature.SelectedIndex);
        }
        
        private void LvAbilitiesSelectedIndexChanged(object sender, EventArgs e)
        {
            removeAbilityToolStripMenuItem.Enabled = lvAbilities.SelectedItems.Count > 0;
        }
        private void LvMovesSelectedIndexChanged(object sender, EventArgs e)
        {
            // hurr durr.
            removeToolStripMenuItem.Enabled = lvMoves.SelectedItems.Count > 0;

            // we'll only allow one item selected for this.
            if(lvMoves.SelectedItems.Count.Equals(1))
            {
                var move = Static.Moves.First(s => s.Name == lvMoves.SelectedItems[0].Text);
                tbMoveType.Text = move.Type;
                tbDmgRoll.Text = move.Damage;
                tbFrequency.Text = move.Frequency;
                tbAccuracyChk.Text = move.Accuracy;
                tbRange.Text = move.Range;
                if (!string.IsNullOrEmpty(move.Special)) 
                    tbSpecial.Text = string.Format("Grants: {0}", move.Special);
                tbEffect.Text = move.Effect;

                lblContestAppeal.Text = move.Appeal;
                lblContestEffect.Text = move.ContestEffect;
                lblContestType.Text = move.ContestType;
            }
            else
            {
                tbMoveType.Text = string.Empty;
                tbDmgRoll.Text = string.Empty;
                tbFrequency.Text = string.Empty;
                tbAccuracyChk.Text = string.Empty;
                tbRange.Text = string.Empty;
                tbSpecial.Text = string.Empty;
                tbEffect.Text = string.Empty;

                lblContestAppeal.Text = string.Empty;
                lblContestEffect.Text = string.Empty;
                lblContestType.Text = string.Empty;
            }
        }

        private void LvCapabilitiesDoubleClick(object sender, EventArgs e)
        {
            if (lvCapabilities.SelectedItems.Count <= 0) return;
            foreach (var item in lvCapabilities.SelectedItems.Cast<ListViewItem>().Where(item => item.Group.Equals(lvCapabilities.Groups[1])))
            {
                var capabilityWindow = new DialogCapabilities();
                capabilityWindow.Show();
                capabilityWindow.SelectCapability(item.Text);
            }
        }
        private void LvMovesDoubleClick(object sender, EventArgs e)
        {
            if (lvMoves.SelectedItems.Count <= 0) return;
            foreach (var selectedItem in lvMoves.SelectedItems)
            {
                var item = (ListViewItem)selectedItem;
                var moveWindow = new DialogMoves();
                moveWindow.Show();
                moveWindow.SelectMove(item.Text);
            }
        }
        private void LvAbilitiesDoubleClick(object sender, EventArgs e)
        {
            if (lvAbilities.SelectedItems.Count <= 0) return;
            foreach (var selectedItem in lvAbilities.SelectedItems)
            {
                var item = (ListViewItem)selectedItem;
                var abilityWindow = new DialogAbilities();
                abilityWindow.Show();
                abilityWindow.SelectMove(item.Text);
            }
        }

        private void SheetLoad(object sender, EventArgs e)
        {
            
        }
        private void TbNicknameTextChanged(object sender, EventArgs e)
        {
            CalculatePokemonTabName();
        }

        private void NudLevelValueChanged(object sender, EventArgs e)
        {
            if(cboxExp.Checked) nudExperience.Value = CalculateExperience((int)nudLevel.Value);
            tbMaxHealth.Text = CalculateHP((int)(nudBaseHP.Value + nudAddedHp.Value + CalculateNature(cbNature.SelectedIndex, 0)), (int)nudLevel.Value).ToString(CultureInfo.InvariantCulture);
            CalculateHealthLimits();
            CalculateMaxPoints();
            CanAddAbility();
            lblStab.Text = CalculateStab((double)nudLevel.Value).ToString(CultureInfo.InvariantCulture);
        }
        private void NudExperienceValueChanged(object sender, EventArgs e)
        {
            try
            {
                var currentLevel = nudLevel.Value;
                if(CalculateIncreaseAllowed() >= 0 && CalculateLevel((int)nudExperience.Value) < currentLevel)
                {
                    nudExperience.Value = CalculateExperience((int)currentLevel);
                }
                else
                {
                    nudLevel.Value = CalculateLevel((int)nudExperience.Value);    
                }
            }
            catch (Exception)
            {
                nudExperience.Value = CalculateExperience((int) nudLevel.Value);
            }
            
        }
        private void NudBaseHPValueChanged(object sender, EventArgs e)
        {
            tbFinalHP.Text = (nudBaseHP.Value + nudAddedHp.Value + CalculateNature(cbNature.SelectedIndex, 0)).ToString(CultureInfo.InvariantCulture);
            tbMaxHealth.Text = CalculateHP((int)(nudBaseHP.Value + nudAddedHp.Value + CalculateNature(cbNature.SelectedIndex, 0)), (int)nudLevel.Value).ToString(CultureInfo.InvariantCulture);
            CalculateHealthLimits();
            CalculateMaxPoints();
        }
        private void NudBaseAtkValueChanged(object sender, EventArgs e)
        {
            tbFinalAtk.Text = (nudBaseAtk.Value + nudAddedAtk.Value + CalculateNature(cbNature.SelectedIndex, 1)).ToString(CultureInfo.InvariantCulture);
            CalculateMaxPoints();
        }
        private void NudBaseDefValueChanged(object sender, EventArgs e)
        {
            tbFinalDef.Text = (nudBaseDef.Value + nudAddedDef.Value + CalculateNature(cbNature.SelectedIndex, 2)).ToString(CultureInfo.InvariantCulture);
            CalculateEvasion();
            CalculateMaxPoints();
        }
        private void NudBaseSpAtkValueChanged(object sender, EventArgs e)
        {
            tbFinalSpAtk.Text = (nudBaseSpAtk.Value + nudAddedSpAtk.Value + CalculateNature(cbNature.SelectedIndex, 3)).ToString(CultureInfo.InvariantCulture);
            CalculateMaxPoints();
        }
        private void NudBaseSpDefValueChanged(object sender, EventArgs e)
        {
            tbFinalSpDef.Text = (nudBaseSpDef.Value + nudAddedSpDef.Value + CalculateNature(cbNature.SelectedIndex, 4)).ToString(CultureInfo.InvariantCulture);
            CalculateEvasion();
            CalculateMaxPoints();
        }
        private void NudBaseSpeedValueChanged(object sender, EventArgs e)
        {
            tbFinalSpeed.Text = (nudBaseSpeed.Value + nudAddedSpeed.Value + CalculateNature(cbNature.SelectedIndex, 5)).ToString(CultureInfo.InvariantCulture);
            CalculateEvasion();
            CalculateMaxPoints();
        }
        
        private void NotesToolStripMenuItemClick(object sender, EventArgs e)
        {
            var notesDlg = new DialogNotes {Notes = _notes};
            if (notesDlg.ShowDialog().Equals(DialogResult.OK))
                _notes = notesDlg.Notes;
        }
        private void HeldItemToolStripMenuItemClick(object sender, EventArgs e)
        {
            var heldDlg = new DialogHeld {HeldItem = _held};
            if (heldDlg.ShowDialog().Equals(DialogResult.OK))
                _held = heldDlg.HeldItem;
        }
        private void RandomizeToolStripMenuItemClick(object sender, EventArgs e)
        {
            CalculateRandomEffortValues();
        }
        private void ResetToolStripMenuItem1Click(object sender, EventArgs e)
        {
            nudAddedHp.Value = 0;
            nudAddedAtk.Value = 0;
            nudAddedDef.Value = 0;
            nudAddedSpAtk.Value = 0;
            nudAddedSpDef.Value = 0;
            nudAddedSpeed.Value = 0;
        }
        private void RandomizeNatureToolStripMenuItemClick(object sender, EventArgs e)
        {
            cbNature.SelectedIndex = _rnd.Next(0, cbNature.Items.Count);
        }
        private void AddMoveToolStripMenuItemClick(object sender, EventArgs e)
        {
            var moves = new Sheet_Windows.DialogMoves
                            {
                                Pokemon = GetCurrentPokemon(),
                                Level = (int)nudLevel.Value, 
                                Learned = lvMoves.Items.Cast<ListViewItem>().Where(s => s.Group == lvMoves.Groups[0]).Select(s => s.Text).ToList(),
                                LearnedEggs = lvMoves.Items.Cast<ListViewItem>().Where(s => s.Group == lvMoves.Groups[1]).Select(s => s.Text).ToList(),
                                LearnedTutor = lvMoves.Items.Cast<ListViewItem>().Where(s => s.Group == lvMoves.Groups[2]).Select(s => s.Text).ToList()
                            };
            if(moves.ShowDialog() == DialogResult.OK)
            {

                // loop and add
                foreach (var selectedMove in moves.SelectedMoves)
                    lvMoves.Items.Add(new ListViewItem(selectedMove, lvMoves.Groups[0]));

                foreach (var selectedEgg in moves.SelectedEgg)
                    lvMoves.Items.Add(new ListViewItem(selectedEgg, lvMoves.Groups[1]));

                foreach (var selectedTutor in moves.SelectedTutor)
                    lvMoves.Items.Add(new ListViewItem(selectedTutor, lvMoves.Groups[2]));

            }

            // capabilities.
            CalculateCapabilities();
            CalculateCustomCapabilities();
            
        }
        private void RemoveToolStripMenuItemClick(object sender, EventArgs e)
        {
            foreach (var selectedItem in lvMoves.SelectedItems.Cast<ListViewItem>())
                lvMoves.Items.RemoveAt(selectedItem.Index);
            CalculateCapabilities();
            CalculateCustomCapabilities();
        }
        private void AddAbilityToolStripMenuItemClick(object sender, EventArgs e)
        {

            // DIALOGASAOFO
            var abilDlg = new Sheet_Windows.DialogAbilities();

            // we need to build a list of abilities, so get current pkm
            var currentPkm = GetCurrentPokemon();

            // get the abilities we currently know.
            var currentAbilities = (from object item in lvAbilities.Items select ((ListViewItem)item).Text).ToList();

            // build our list of all abilities.
            var abilities = new List<string>();
            abilities.AddRange(currentPkm.BasicAbilities);
            if (nudLevel.Value > 39)
                abilities.AddRange(currentPkm.HighAbilities);

            // clear
            foreach (var currentAbility in currentAbilities)
                abilities.Remove(currentAbility);

            // send this to the list
            abilDlg.Abilities = abilities;

            // show
            if (abilDlg.ShowDialog().Equals(DialogResult.OK))
            {
                // get the selected ability
                var ability = abilDlg.SelectedAbility;

                // get the actual ability
                var abilityType =
                    Static.Abilities.First(a => a.Name.ToLowerInvariant().Equals(ability.ToLowerInvariant()));

                // check which group it's in.
                lvAbilities.Items.Add(new ListViewItem
                                          {
                                              Text = ability,
                                              Group =
                                                  currentPkm.BasicAbilities.Contains(ability)
                                                      ? lvAbilities.Groups[0]
                                                      : lvAbilities.Groups[1],
                                              ToolTipText = string.Format("Activation: {0}\nLimit: {1}\nKeywords: {2}\nEffect: {3}",
                                                    abilityType.Activation, abilityType.Limit,
                                                    abilityType.Keywords, abilityType.Effect)
                                          });

            }

            CanAddAbility();

        }
        private void RemoveAbilityToolStripMenuItemClick(object sender, EventArgs e)
        {
            lvAbilities.Items.Remove(lvAbilities.SelectedItems[0]);
            CanAddAbility();
        }
        private void MakeExpMatchToolStripMenuItemClick(object sender, EventArgs e)
        {
            nudExperience.Value = CalculateExperience((int)nudLevel.Value);
        }
        private void SaveToolStripMenuItemClick(object sender, EventArgs e)
        {
            SaveINI();
        }
        private void LoadToolStripMenuItemClick(object sender, EventArgs e)
        {
            LoadINI();
        }
        private void DeleteAllToolStripMenuItemClick(object sender, EventArgs e)
        {
            lvMoves.Items.Clear();
            removeToolStripMenuItem.Enabled = false;
            CalculateCapabilities();
            CalculateCustomCapabilities();
        }

        private void PbPokemonClick(object sender, EventArgs e)
        {
            var bigPic = new BigPicture();
            var img = CalculatePokemonImage(GetCurrentPokemon().NationalNumber);
            bigPic.BackgroundImage = img;
            bigPic.BackgroundImageLayout = ImageLayout.Stretch;
            bigPic.Width = Math.Min(500, img.Width);
            bigPic.Height = Math.Min(500, img.Height);
            Console.WriteLine(Resources.WidthHeightFormat, bigPic.Width, bigPic.Height);
            bigPic.ShowDialog();
            img.Dispose();
        }

        private Pokemon GetCurrentPokemon() => cbSpecies.SelectedItem as Parser.Types.Pokemon;

        private void CalculatePokemonTabName()
        {
            var currentPkm = GetCurrentPokemon();
            Pokemon = string.IsNullOrEmpty(tbNickname.Text)
                          ? currentPkm.Name
                          : string.Format("{0} - ({1})", tbNickname.Text, currentPkm.Name);
            NameChanged(this, new PokemonNameChangeEventArgs { Name = Pokemon });
        }

        private class LvSort : System.Collections.IComparer
        {
            public int Compare(object x, object y)
            {
                if (!(x is ListViewItem) || !(y is ListViewItem))
                    return 0;

                var lv1 = (ListViewItem)x;
                var lv2 = (ListViewItem)y;

                // both the tags should be integers...
                if (!(lv1.Tag is int) || !(lv2.Tag is int))
                    return 0;

                return ((int)lv1.Tag).CompareTo((int)lv2.Tag);

            }
        }

    }

    public class PokemonNameChangeEventArgs : EventArgs
    {
        public string Name { get; set; }
    }
}