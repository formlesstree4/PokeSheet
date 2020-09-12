using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace PtaSheet.Forms
{

    public partial class Sheet : Form
    {

        private const int MaxLevel = 500;

        public ManagedXml.Element PokemonList { get; set; }
        public ManagedXml.Element MoveList { get; set; }
        public ManagedXml.Element AbilityList { get; set; }

        private ManagedXml.Element _currentPokemon { get; set; }
        private OnTitleChange tc = null;
        private string _location { get; set; }
        private Random _rng = new Random();
        private string[] _experience = System.IO.File.ReadAllLines("Resources\\XML\\exp.txt");
        private Classes.CombatStages _combatStages = new Classes.CombatStages();

        public delegate void OnTitleChange();
        public event OnTitleChange TitleChanged;

        public Sheet()
        {

            // Initialize.
            InitializeComponent();

        }
        
        private void PopulateGenderBox(bool male, bool female)
        {

            icbGender.Items.Clear();
            if (!male && !female) icbGender.Items.Add(new ComboxExtended.ComboBoxItem("Genderless", Properties.Resources.Sex_Male_Female_icon));
            if (male) icbGender.Items.Add(new ComboxExtended.ComboBoxItem("Male", Properties.Resources.Male_icon));
            if (female) icbGender.Items.Add(new ComboxExtended.ComboBoxItem("Female", Properties.Resources.Female_icon));
            icbGender.SelectedIndex = 0;
            
        }
        private void PopulateImagedComboBoxes()
        {
            icbTypeOne.SuspendLayout();
            icbTypeTwo.SuspendLayout();
            icbPokemon.SuspendLayout();

            icbTypeOne.Items.Add(new ComboxExtended.ComboBoxItem("Bug", ImgResources.Types.BugIC));
            icbTypeOne.Items.Add(new ComboxExtended.ComboBoxItem("Dark", ImgResources.Types.DarkIC));
            icbTypeOne.Items.Add(new ComboxExtended.ComboBoxItem("Dragon", ImgResources.Types.DragonIC));
            icbTypeOne.Items.Add(new ComboxExtended.ComboBoxItem("Electric", ImgResources.Types.ElectricIC));
            icbTypeOne.Items.Add(new ComboxExtended.ComboBoxItem("Fighting", ImgResources.Types.FightingIC));
            icbTypeOne.Items.Add(new ComboxExtended.ComboBoxItem("Fire", ImgResources.Types.FireIC));
            icbTypeOne.Items.Add(new ComboxExtended.ComboBoxItem("Flying", ImgResources.Types.FlyingIC));
            icbTypeOne.Items.Add(new ComboxExtended.ComboBoxItem("Ghost", ImgResources.Types.GhostIC));
            icbTypeOne.Items.Add(new ComboxExtended.ComboBoxItem("Grass", ImgResources.Types.GrassIC));
            icbTypeOne.Items.Add(new ComboxExtended.ComboBoxItem("Ground", ImgResources.Types.GroundIC));
            icbTypeOne.Items.Add(new ComboxExtended.ComboBoxItem("Ice", ImgResources.Types.IceIC));
            icbTypeOne.Items.Add(new ComboxExtended.ComboBoxItem("Normal", ImgResources.Types.NormalIC));
            icbTypeOne.Items.Add(new ComboxExtended.ComboBoxItem("Poison", ImgResources.Types.PoisonIC));
            icbTypeOne.Items.Add(new ComboxExtended.ComboBoxItem("Psychic", ImgResources.Types.PsychicIC));
            icbTypeOne.Items.Add(new ComboxExtended.ComboBoxItem("Rock", ImgResources.Types.RockIC));
            icbTypeOne.Items.Add(new ComboxExtended.ComboBoxItem("Steel", ImgResources.Types.SteelIC));
            icbTypeOne.Items.Add(new ComboxExtended.ComboBoxItem("Water", ImgResources.Types.WaterIC));

            icbTypeTwo.Items.Add(new ComboxExtended.ComboBoxItem("None", ImgResources.Types.UnknownIC));
            icbTypeTwo.Items.Add(new ComboxExtended.ComboBoxItem("Bug", ImgResources.Types.BugIC));
            icbTypeTwo.Items.Add(new ComboxExtended.ComboBoxItem("Dark", ImgResources.Types.DarkIC));
            icbTypeTwo.Items.Add(new ComboxExtended.ComboBoxItem("Dragon", ImgResources.Types.DragonIC));
            icbTypeTwo.Items.Add(new ComboxExtended.ComboBoxItem("Electric", ImgResources.Types.ElectricIC));
            icbTypeTwo.Items.Add(new ComboxExtended.ComboBoxItem("Fighting", ImgResources.Types.FightingIC));
            icbTypeTwo.Items.Add(new ComboxExtended.ComboBoxItem("Fire", ImgResources.Types.FireIC));
            icbTypeTwo.Items.Add(new ComboxExtended.ComboBoxItem("Flying", ImgResources.Types.FlyingIC));
            icbTypeTwo.Items.Add(new ComboxExtended.ComboBoxItem("Ghost", ImgResources.Types.GhostIC));
            icbTypeTwo.Items.Add(new ComboxExtended.ComboBoxItem("Grass", ImgResources.Types.GrassIC));
            icbTypeTwo.Items.Add(new ComboxExtended.ComboBoxItem("Ground", ImgResources.Types.GroundIC));
            icbTypeTwo.Items.Add(new ComboxExtended.ComboBoxItem("Ice", ImgResources.Types.IceIC));
            icbTypeTwo.Items.Add(new ComboxExtended.ComboBoxItem("Normal", ImgResources.Types.NormalIC));
            icbTypeTwo.Items.Add(new ComboxExtended.ComboBoxItem("Poison", ImgResources.Types.PoisonIC));
            icbTypeTwo.Items.Add(new ComboxExtended.ComboBoxItem("Psychic", ImgResources.Types.PsychicIC));
            icbTypeTwo.Items.Add(new ComboxExtended.ComboBoxItem("Rock", ImgResources.Types.RockIC));
            icbTypeTwo.Items.Add(new ComboxExtended.ComboBoxItem("Steel", ImgResources.Types.SteelIC));
            icbTypeTwo.Items.Add(new ComboxExtended.ComboBoxItem("Water", ImgResources.Types.WaterIC));
            
            // Pokedex.
            var list = PokemonList.Children.OrderBy(c => Convert.ToInt32((c.GetElement("Pokedex").GetAttributeValue("National")))).ToList();

            // now begin loading
            foreach (var element in list)
            {

                // Get basic values
                var name = string.Format("#{0}: {1}", element.GetElement("Pokedex").GetAttributeValue("National").PadLeft(3, '0'), element.GetAttributeValue("Name"));
                var nameLower = name.ToLowerInvariant();
                var number = element.GetElement("Pokedex").GetAttributeValue("National");
                var cb = new ComboxExtended.ComboBoxItem();

                switch (number)
                {
                    case "386":
                        if (nameLower.Contains("attack"))
                            number = "386a";
                        if (nameLower.Contains("defense"))
                            number = "386d";
                        if (nameLower.Contains("speed"))
                            number = "386s";
                        break;
                    case "413":
                        if (nameLower.Contains("sandy"))
                            number = "413s";
                        if (nameLower.Contains("trash"))
                            number = "413t";
                        break;
                    case "487":
                        if (nameLower.Contains("origin"))
                            number = "487o";
                        break;
                    case "492":
                        if (nameLower.Contains("sky"))
                            number = "492s";
                        break;
                    case "648":
                        if (nameLower.Contains("step"))
                            number = "648s";
                        break;
                }

                // Add to combo box
                cb.Value = name;
                cb.Image = Classes.Runtime.GetImage("_" + number, Classes.Runtime.ResourceTypes.Icons);
                
                icbPokemon.Items.Add(cb);
            }

            icbTypeOne.ResumeLayout();
            icbTypeTwo.ResumeLayout();
            icbPokemon.ResumeLayout();
        }
        public void SaveXml(string location)
        {
            var XmlBuilder = ManagedXml.Element.Create("Pokemon");
            XmlBuilder.Encoding = Encoding.UTF8;

            var General = ManagedXml.Element.Create("General");
            var Stats = ManagedXml.Element.Create("Stats");

            var Moves = ManagedXml.Element.Create("Moves");
            var GeneralMoves = ManagedXml.Element.Create("General");
            var EggMoves = ManagedXml.Element.Create("Eggs");
            var TutorMoves = ManagedXml.Element.Create("Tutor");
            var TMs = ManagedXml.Element.Create("TM");

            var Abilities = ManagedXml.Element.Create("Abilities");

            General.Attributes.Add(ManagedXml.Attribute.Create("Name", icbPokemon.SelectedIndex.ToString()));
            General.Attributes.Add(ManagedXml.Attribute.Create("Gender", icbGender.SelectedIndex.ToString()));
            General.Attributes.Add(ManagedXml.Attribute.Create("Nickname", tbNickname.Text));
            General.Attributes.Add(ManagedXml.Attribute.Create("EXP", nudExperience.Value.ToString()));
            General.Attributes.Add(ManagedXml.Attribute.Create("Held", tbHeldItem.Text));
            General.Attributes.Add(ManagedXml.Attribute.Create("Notes", tbNotes.Text));
            General.Attributes.Add(ManagedXml.Attribute.Create("TypeOne", icbTypeOne.SelectedIndex.ToString()));
            General.Attributes.Add(ManagedXml.Attribute.Create("TypeTwo", icbTypeTwo.SelectedIndex.ToString()));

            Stats.Attributes.Add(ManagedXml.Attribute.Create("AddedHP", nudAddedHp.Value.ToString()));
            Stats.Attributes.Add(ManagedXml.Attribute.Create("AddedAtk", nudAddedAtk.Value.ToString()));
            Stats.Attributes.Add(ManagedXml.Attribute.Create("AddedDef", nudAddedDef.Value.ToString()));
            Stats.Attributes.Add(ManagedXml.Attribute.Create("AddedSpAtk", nudAddedSpAtk.Value.ToString()));
            Stats.Attributes.Add(ManagedXml.Attribute.Create("AddedSpDef", nudAddedSpDef.Value.ToString()));
            Stats.Attributes.Add(ManagedXml.Attribute.Create("AddedSpeed", nudAddedSpeed.Value.ToString()));
            Stats.Attributes.Add(ManagedXml.Attribute.Create("Nature", cbNatures.SelectedIndex.ToString()));
            Stats.Attributes.Add(ManagedXml.Attribute.Create("Health", nudCurrentHealth.Value.ToString()));
            
            Stats.Attributes.Add(ManagedXml.Attribute.Create("HPCS", _combatStages.HP.ToString()));
            Stats.Attributes.Add(ManagedXml.Attribute.Create("ATKCS", _combatStages.Attack.ToString()));
            Stats.Attributes.Add(ManagedXml.Attribute.Create("DEFCS", _combatStages.Defense.ToString()));
            Stats.Attributes.Add(ManagedXml.Attribute.Create("SPATKCS", _combatStages.SpAtk.ToString()));
            Stats.Attributes.Add(ManagedXml.Attribute.Create("SPDEFCS", _combatStages.SpDef.ToString()));
            Stats.Attributes.Add(ManagedXml.Attribute.Create("SPEEDCS", _combatStages.Speed.ToString()));

            foreach (var item in lvMoves.Items)
            {
                switch ((item as ListViewItem).Group.Name)
                {
                    case "lvgMoves":
                        GeneralMoves.Children.Add(ManagedXml.Element.Create("Move", (item as ListViewItem).Text));
                        break;

                    case "lvgTutor":
                        TutorMoves.Children.Add(ManagedXml.Element.Create("Move", (item as ListViewItem).Text));
                        break;

                    case "lvgTM":
                        TMs.Children.Add(ManagedXml.Element.Create("Move", (item as ListViewItem).Text));
                        break;

                    case "lvgEgg":
                        EggMoves.Children.Add(ManagedXml.Element.Create("Move", (item as ListViewItem).Text));
                        break;
                }
            }

            Moves.Children.Add(GeneralMoves);
            Moves.Children.Add(TutorMoves);
            Moves.Children.Add(TMs);
            Moves.Children.Add(EggMoves);

            foreach (var item in lvAbilities.Items)
            {
                switch ((item as ListViewItem).Group.Name)
                {
                    case "lvgNormal":
                        Abilities.Children.Add(ManagedXml.Element.Create("Basic", (item as ListViewItem).Text));
                        break;

                    case "lvgHigh":
                        Abilities.Children.Add(ManagedXml.Element.Create("High", (item as ListViewItem).Text));
                        break;
                }
            }

            XmlBuilder.Children.Add(General);
            XmlBuilder.Children.Add(Stats);
            XmlBuilder.Children.Add(Moves);
            XmlBuilder.Children.Add(Abilities);

            var sw = new System.IO.StreamWriter(location);
            sw.Write(XmlBuilder.ToString());
            sw.Close();

        }
        public void LoadXml(string location)
        {

            var root = new ManagedXml.Reader(System.IO.File.ReadAllText(location)).Xml;
            _location = location;

            var general = root.GetElement("General");
            var stats = root.GetElement("Stats");
            var moves = root.GetElement("Moves");

            var generalMoves = moves.GetElement("General");
            var tutor = moves.GetElement("Tutor");
            var TM = moves.GetElement("TM");
            var eggs = moves.GetElement("Eggs");

            var abilities = root.GetElement("Abilities");

            // General tab first.
            icbPokemon.SelectedIndex = Convert.ToInt32(general.GetAttributeValue("Name"));
            icbGender.SelectedIndex = Convert.ToInt32(general.GetAttributeValue("Gender"));
            tbNickname.Text = general.GetAttributeValue("Nickname");

            if (nudExperience.ReadOnly)
            {
                nudExperience.ReadOnly = false;
                pbLock.BackgroundImage = Properties.Resources.Actions_dialog_ok_apply_icon;

            }
            nudExperience.Value = Convert.ToDecimal(general.GetAttributeValue("EXP"));
            tbHeldItem.Text = general.GetAttributeValue("Held");
            tbNotes.Text = general.GetAttributeValue("Notes");
            icbTypeOne.SelectedIndex = Convert.ToInt32(general.GetAttributeValue("TypeOne"));
            icbTypeTwo.SelectedIndex = Convert.ToInt32(general.GetAttributeValue("TypeTwo"));
            
            // Now stats. Do Combat stages first so they will get applied.
            _combatStages.HP = Convert.ToInt32(stats.GetAttributeValue("HPCS", "0"));
            _combatStages.Attack = Convert.ToInt32(stats.GetAttributeValue("ATKCS", "0"));
            _combatStages.Defense = Convert.ToInt32(stats.GetAttributeValue("DEFCS", "0"));
            _combatStages.SpAtk = Convert.ToInt32(stats.GetAttributeValue("SPATKCS", "0"));
            _combatStages.SpDef = Convert.ToInt32(stats.GetAttributeValue("SPDEFCS", "0"));
            _combatStages.Speed = Convert.ToInt32(stats.GetAttributeValue("SPEEDCS", "0"));

            // Okay, now stats.
            nudAddedHp.Value = Convert.ToDecimal(stats.GetAttributeValue("AddedHP"));
            nudAddedAtk.Value = Convert.ToDecimal(stats.GetAttributeValue("AddedAtk"));
            nudAddedDef.Value = Convert.ToDecimal(stats.GetAttributeValue("AddedDef"));
            nudAddedSpAtk.Value = Convert.ToDecimal(stats.GetAttributeValue("AddedSpAtk"));
            nudAddedSpDef.Value = Convert.ToDecimal(stats.GetAttributeValue("AddedSpDef"));
            nudAddedSpeed.Value = Convert.ToDecimal(stats.GetAttributeValue("AddedSpeed"));

            cbNatures.SelectedIndex = Convert.ToInt32(stats.GetAttributeValue("Nature"));
            nudCurrentHealth.Value = Convert.ToDecimal(stats.GetAttributeValue("Health"));

            

            // Moves now.
            foreach (var item in generalMoves.Children)
            {
                lvMoves.Items.Add(
                    new ListViewItem
                    {
                        Text = item.Value,
                        Tag = MoveList.Children.First(
                            m => m.GetAttributeValue("name") == item.Value),
                        Group = lvMoves.Groups[0]
                    });
            }
            foreach (var item in tutor.Children)
            {
                lvMoves.Items.Add(
                    new ListViewItem
                    {
                        Text = item.Value,
                        Tag = MoveList.Children.First(
                            m => m.GetAttributeValue("name") == item.Value),
                        Group = lvMoves.Groups[1]
                    });
            }
            foreach (var item in TM.Children)
            {
                lvMoves.Items.Add(
                    new ListViewItem
                    {
                        Text = item.Value,
                        Group = lvMoves.Groups[2]
                    });
            }
            foreach (var item in eggs.Children)
            {
                lvMoves.Items.Add(
                    new ListViewItem
                    {
                        Text = item.Value,
                        Tag = MoveList.Children.First(
                            m => m.GetAttributeValue("name") == item.Value),
                        Group = lvMoves.Groups[3]
                    });
            }

            // Lastly, abilities.
            foreach (var item in abilities.Children)
                if (item.Name == "Basic")
                    lvAbilities.Items.Add(new ListViewItem { Text = item.Value, Group = lvAbilities.Groups[item.Name == "Basic" ? 0: 1]});

            // stats shoudl be all loaded
            UpdateCSButtons();
            UpdateTotalStats();

        }

        private double GetExperience(int level)
        {
            if (level >= 50) return 100000 + (10000 * (level - 50));
            return Convert.ToDouble(_experience[level - 1]);
        }
        private int GetLevel(double experience)
        {
            var returnValue = 1;
            for (var i = 1; i <= MaxLevel + 1; i++)
            {
                if (experience < GetExperience(i))
                    return i - 1;
            }
            return returnValue;
        }


        private void Sheet_Load(object sender, EventArgs e)
        {

            nudLevel.Maximum = MaxLevel;
            PopulateImagedComboBoxes();

            UpdateStab();
            UpdateBonusPoints();

            icbPokemon.SelectedIndex = 0;
            cbNatures.SelectedIndex = 0;

        }


        private void tsbNew_Click(object sender, EventArgs e)
        {
            allToolStripMenuItem.PerformClick();
            nudAddedHp.Value = 0;
            nudAddedAtk.Value = 0;
            nudAddedDef.Value = 0;
            nudAddedSpAtk.Value = 0;
            nudAddedSpDef.Value = 0;
            nudAddedSpeed.Value = 0;
            cbNatures.SelectedIndex = 0;
            nudLevel.Value = 1;
            icbPokemon.SelectedIndex = 0;
            icbGender.SelectedIndex = 0;
            tbNickname.Clear();
            tbNotes.Clear();
            tbHeldItem.Clear();
            lvMoves.Items.Clear();
            lvAbilities.Items.Clear();
            _location = string.Empty;
            UpdateCustomCapabilities();
        }
        private void tsbOpen_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog { Filter = "Pokémon File|*.xml", Title = "Open Pokémon", Multiselect = true };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < ofd.FileNames.Length; i++)
                {
                    if (i == 0)
                        LoadXml(ofd.FileNames[i]);
                    else
                    {
                        var x = new Sheet { MdiParent = this.MdiParent, PokemonList = this.PokemonList, MoveList = this.MoveList };
                        (MdiParent as frmMain).Bind(x);
                        x.Show();
                        x.LoadXml(ofd.FileNames[i]);
                    }
                }
            }
        }
        private void tsbSave_Click(object sender, EventArgs e)
        {

            // Create this dialog just in case.
            var sfd = new SaveFileDialog { Filter = "Pokémon File|*.xml", Title = "Save Pokémon" };

            // Get a location if we need to.
            if (string.IsNullOrEmpty(_location))
                if (sfd.ShowDialog() == DialogResult.OK)
                    _location = sfd.FileName;
                else
                    return;

            // We can save. Hurrah.
            SaveXml(_location);

        }
        private void tsbSaveAs_Click(object sender, EventArgs e)
        {

            // Create this dialog just in case.
            var sfd = new SaveFileDialog { Filter = "Pokémon File|*.xml", Title = "Save Pokémon" };
            var oldPath = _location;

            // Get a location if we need to.
            if (sfd.ShowDialog() == DialogResult.OK)
                _location = sfd.FileName;
            else
                return;

            // We can save. Hurrah.
            SaveXml(_location);

        }
        private void tsbClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void tsbAddMove_Click(object sender, EventArgs e)
        {
            var moves = new Moves() { Pokemon = _currentPokemon, MoveElement = MoveList };
            var moveArr = new List<ListViewItem>();

            foreach (var item in lvMoves.Items)
                moveArr.Add(item as ListViewItem);

            if (lvMoves.Groups[0].Items.Count > 0)
                moves.KnownMoves = moveArr.Where(m => m.Group == lvMoves.Groups[0]).Select(m => m.Text);

            if (lvMoves.Groups[1].Items.Count > 0)
                moves.KnownTutor = moveArr.Where(m => m.Group == lvMoves.Groups[1]).Select(m => m.Text);

            if (lvMoves.Groups[2].Items.Count > 0)
                moves.KnownTM = moveArr.Where(m => m.Group == lvMoves.Groups[2]).Select(m => m.Text);

            if (lvMoves.Groups[3].Items.Count > 0)
                moves.KnownEgg = moveArr.Where(m => m.Group == lvMoves.Groups[3]).Select(m => m.Text);

            if (moves.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var newMoves = moves.Results;

                var all = newMoves.GetElement("General");
                var levelup = newMoves.GetElement("Levelup");
                var tutor = newMoves.GetElement("Tutor");
                var egg = newMoves.GetElement("Egg");
                var TMs = newMoves.GetElement("TMs");

                foreach (var item in all.Children)
                {
                    var lvi = new ListViewItem();
                    lvi.Text = item.GetAttributeValue("name");
                    lvi.Tag = item;
                    lvi.Group = lvMoves.Groups[0];
                    lvMoves.Items.Add(lvi);
                }

                foreach (var item in levelup.Children)
                {
                    var lvi = new ListViewItem();
                    lvi.Text = item.GetAttributeValue("name");
                    lvi.Tag = item;
                    lvi.Group = lvMoves.Groups[0];
                    lvMoves.Items.Add(lvi);
                }

                foreach (var item in tutor.Children)
                {
                    var lvi = new ListViewItem();
                    lvi.Text = item.GetAttributeValue("name");
                    lvi.Tag = item;
                    lvi.Group = lvMoves.Groups[1];
                    lvMoves.Items.Add(lvi);
                }

                foreach (var item in TMs.Children)
                {
                    var lvi = new ListViewItem();
                    lvi.Text = item.Value;
                    lvi.Tag = item;
                    lvi.Group = lvMoves.Groups[2];
                    lvMoves.Items.Add(lvi);
                }

                foreach (var item in egg.Children)
                {
                    var lvi = new ListViewItem();
                    lvi.Text = item.GetAttributeValue("name");
                    lvi.Tag = item;
                    lvi.Group = lvMoves.Groups[3];
                    lvMoves.Items.Add(lvi);
                }

            }

            UpdateCustomCapabilities();

        }
        private void tsbRemoveMove_Click(object sender, EventArgs e)
        {
            var lviArray = new ListViewItem[lvMoves.SelectedItems.Count];
            lvMoves.SelectedItems.CopyTo(lviArray, 0);
            foreach (var item in lviArray)
                lvMoves.Items.Remove(item);
            UpdateCustomCapabilities();
        }
        private void tsbAddAbility_Click(object sender, EventArgs e)
        {
            var abilities = _currentPokemon.GetElement("Abilities");
            var caArray = new ListViewItem[lvAbilities.Items.Count]; lvAbilities.Items.CopyTo(caArray, 0);
            var currentAbilities = caArray.Select(m => m.Text).ToList();
            var basics = abilities.GetElement("Basic").Children.Select(m => m.Value).Where(m => !currentAbilities.Contains(m)).ToList();
            var high = abilities.GetElement("High").Children.Select(m => m.Value).Where(m => !currentAbilities.Contains(m)).ToList();

            var abilityWindow = new Abilities();
            abilityWindow.Level = (int)nudLevel.Value;
            abilityWindow.High = high;
            abilityWindow.Ability = basics;

            if (abilityWindow.ShowDialog() == DialogResult.OK)
                lvAbilities.Items.Add(new ListViewItem { 
                    Text = abilityWindow.NewAbility, 
                    Group = abilityWindow.IsHigh ? 
                    lvAbilities.Groups[1] : lvAbilities.Groups[0],
                    Tag = AbilityList.Children.FirstOrDefault(m => m.GetAttributeValue("Name") == abilityWindow.NewAbility)
                });
            UpdateAddAbility();
        }
        private void tsbRemoveAbility_Click(object sender, EventArgs e)
        {
            var lviArray = new ListViewItem[lvAbilities.SelectedItems.Count];
            lvAbilities.SelectedItems.CopyTo(lviArray, 0);
            foreach (var item in lviArray)
                lvAbilities.Items.Remove(item);
            UpdateAddAbility();
        }
        private void tsbAbilityInformation_Click(object sender, EventArgs e)
        {
            var lvi = lvAbilities.SelectedItems[0];
            var tag = lvi.Tag as ManagedXml.Element;
            new Info.Ability(tag).ShowDialog();
        }
        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var search = new Search { Pokemon = PokemonList };
            if (search.ShowDialog() == DialogResult.OK)
            {
                var searchResult = search.Result;
                for (int i = 0; i < icbPokemon.Items.Count(); i++)
                {
                    if(icbPokemon.Items[i].Value.ToString().Remove(0, 6) == (searchResult.GetAttributeValue("Name")))
                    {
                        icbPokemon.SelectedIndex = i;
                        return;
                    }
                }
            }
        }
        private void pbLock_Click(object sender, EventArgs e)
        {
            nudExperience.ReadOnly = !nudExperience.ReadOnly;
            pbLock.BackgroundImage = nudExperience.ReadOnly ? Properties.Resources.delete_icon : Properties.Resources.Actions_dialog_ok_apply_icon;
            if (nudExperience.ReadOnly)
            {
                nudExperience.Minimum = nudExperience.Value;
                nudExperience.Maximum = nudExperience.Minimum;
            }
            else
            {
                nudExperience.Minimum = 0;
                nudExperience.Maximum = (decimal)GetExperience(MaxLevel);
            }
        }


        private void icbPokemon_SelectedIndexChanged(object sender, EventArgs e)
        {

            // Get the current pokemon
            _currentPokemon = PokemonList.Children.First(f => 
                f.GetAttributeValue("Name") == icbPokemon.Text.Remove(0, 6));
            
            // Set the title
            Text = string.Format("Pokémon Sheet - {0}", icbPokemon.Text);
            
            // Call update procedures.
            UpdateImages();
            UpdateBaseStats();
            UpdateTotalStats();
            UpdateTypes();
            UpdateGender();
            UpdateBasicCapabilities();
            

            // Force a repaint
            tc = new OnTitleChange(TitleChanged);
            tc.Invoke();

        }
        private void cbNatures_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = cbNatures.SelectedIndex;

            nudNatureAtk.Minimum = 0;
            nudNatureAtk.Maximum = 0;
            nudNatureDef.Minimum = 0;
            nudNatureDef.Maximum = 0;
            nudNatureSpAtk.Minimum = 0;
            nudNatureSpAtk.Maximum = 0;
            nudNatureSpDef.Minimum = 0;
            nudNatureSpDef.Maximum = 0;
            nudNatureSpeed.Minimum = 0;
            nudNatureSpeed.Maximum = 0;
            nudNatureHP.Minimum = 0;
            nudNatureHP.Maximum = 0;

            switch (index)
            {

                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                    #region +hp
                    tbLike.Text = "None";
                    nudNatureHP.Minimum = 1;
                    nudNatureHP.Maximum = 1;
                    // Hardy, Docile, Proud, Quirky, Lazy
                    if (index == 0) { nudNatureAtk.Minimum = -2; nudNatureAtk.Maximum = -2; tbDislike.Text = "Spicy"; }
                    if (index == 1) { nudNatureDef.Minimum = -2; nudNatureDef.Maximum = -2; tbDislike.Text = "Sour"; }
                    if (index == 2) { nudNatureSpAtk.Minimum = -2; nudNatureSpAtk.Maximum = -2; tbDislike.Text = "Dry"; }
                    if (index == 3) { nudNatureSpDef.Minimum = -2; nudNatureSpDef.Maximum = -2; tbDislike.Text = "Bitter"; }
                    if (index == 4) { nudNatureSpeed.Minimum = -2; nudNatureSpeed.Maximum = -2; tbDislike.Text = "Sweet"; }
                    break;
                    #endregion
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                    #region +atk
                    tbLike.Text = "Spicy";
                    nudNatureAtk.Minimum = 2;
                    nudNatureAtk.Maximum = 2;
                    // Desperate, Lonely, Adamant, Naughty, Brave
                    if (index == 5) { nudNatureHP.Minimum = -1; nudNatureHP.Maximum = -1; tbDislike.Text = "None"; }
                    if (index == 6) { nudNatureDef.Minimum = -2; nudNatureDef.Maximum = -2; tbDislike.Text = "Sour"; }
                    if (index == 7) { nudNatureSpAtk.Minimum = -2; nudNatureSpAtk.Maximum = -2; tbDislike.Text = "Dry"; }
                    if (index == 8) { nudNatureSpDef.Minimum = -2; nudNatureSpDef.Maximum = -2; tbDislike.Text = "Bitter"; }
                    if (index == 9) { nudNatureSpeed.Minimum = -2; nudNatureSpeed.Maximum = -2; tbDislike.Text = "Sweet"; }
                    break;
                    #endregion
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                    #region +def
                    tbLike.Text = "Sour";
                    nudNatureDef.Minimum = 2;
                    nudNatureDef.Maximum = 2;
                    // Stark, Bold, Impish, Lax, Relaxed
                    if (index == 10) { nudNatureHP.Minimum = -1; nudNatureHP.Maximum = -1; tbDislike.Text = "None"; }
                    if (index == 11) { nudNatureAtk.Minimum = -2; nudNatureAtk.Maximum = -2; tbDislike.Text = "Spicy"; }
                    if (index == 12) { nudNatureSpAtk.Minimum = -2; nudNatureSpAtk.Maximum = -2; tbDislike.Text = "Dry"; }
                    if (index == 13) { nudNatureSpDef.Minimum = -2; nudNatureSpDef.Maximum = -2; tbDislike.Text = "Bitter"; }
                    if (index == 14) { nudNatureSpeed.Minimum = -2; nudNatureSpeed.Maximum = -2; tbDislike.Text = "Sweet"; }
                    break;
                    #endregion
                case 15:
                case 16:
                case 17:
                case 18:
                case 19:
                    #region +spatk
                    tbLike.Text = "Dry";
                    nudNatureSpAtk.Minimum = 2;
                    nudNatureSpAtk.Maximum = 2;
                    // Bashful, Modest, Mild, Rash, Quiet
                    if (index == 15) { nudNatureHP.Minimum = -1; nudNatureHP.Maximum = -1; tbDislike.Text = "None"; }
                    if (index == 16) { nudNatureAtk.Minimum = -2; nudNatureAtk.Maximum = -2; tbDislike.Text = "Spicy"; }
                    if (index == 17) { nudNatureDef.Minimum = -2; nudNatureDef.Maximum = -2; tbDislike.Text = "Sour"; }
                    if (index == 18) { nudNatureSpDef.Minimum = -2; nudNatureSpDef.Maximum = -2; tbDislike.Text = "Bitter"; }
                    if (index == 19) { nudNatureSpeed.Minimum = -2; nudNatureSpeed.Maximum = -2; tbDislike.Text = "Sweet"; }
                    #endregion
                    break;
                case 20:
                case 21:
                case 22:
                case 23:
                case 24:
                    #region +spdef
                    tbLike.Text = "Bitter";
                    nudNatureSpDef.Minimum = 2;
                    nudNatureSpDef.Maximum = 2;
                    // Sickly, Calm, Gentle, Careful, Sassy
                    if (index == 20) { nudNatureHP.Minimum = -1; nudNatureHP.Maximum = -1; tbDislike.Text = "None"; }
                    if (index == 21) { nudNatureAtk.Minimum = -2; nudNatureAtk.Maximum = -2; tbDislike.Text = "Spicy"; }
                    if (index == 22) { nudNatureDef.Minimum = -2; nudNatureDef.Maximum = -2; tbDislike.Text = "Sour"; }
                    if (index == 23) { nudNatureSpAtk.Minimum = -2; nudNatureSpAtk.Maximum = -2; tbDislike.Text = "Dry"; }
                    if (index == 24) { nudNatureSpeed.Minimum = -2; nudNatureSpeed.Maximum = -2; tbDislike.Text = "Sweet"; }
                    #endregion
                    break;
                case 25:
                case 26:
                case 27:
                case 28:
                case 29:
                    #region +speed
                    tbLike.Text = "Sweet";
                    nudNatureSpeed.Minimum = 2;
                    nudNatureSpeed.Maximum = 2;
                    // Serious, Timid, Hasty, Jolly, Naive
                    if (index == 25) { nudNatureHP.Minimum = -1; nudNatureHP.Maximum = -1; tbDislike.Text = "None"; }
                    if (index == 26) { nudNatureAtk.Minimum = -2; nudNatureAtk.Maximum = -2; tbDislike.Text = "Spicy"; }
                    if (index == 27) { nudNatureDef.Minimum = -2; nudNatureDef.Maximum = -2; tbDislike.Text = "Sour"; }
                    if (index == 28) { nudNatureSpAtk.Minimum = -2; nudNatureSpAtk.Maximum = -2; tbDislike.Text = "Dry"; }
                    if (index == 29) { nudNatureSpDef.Minimum = -2; nudNatureSpDef.Maximum = -2; tbDislike.Text = "Bitter"; }
                    #endregion
                    break;
                case 30:
                case 31:
                case 32:
                case 33:
                case 34:
                    #region +nothing
                    tbLike.Text = "None";
                    tbDislike.Text = "None";
                    // Composed, Dull, Patient, Poised, Stoic
                    #endregion
                    break;

            }
            UpdateTotalStats();
        }
        private void lvMoves_SelectedIndexChanged(object sender, EventArgs e)
        {
            tsbRemoveMove.Enabled = lvMoves.SelectedItems.Count > 0;
            // tsbMoveInformation.Enabled = lvMoves.SelectedItems.Count == 1;
            if (lvMoves.SelectedItems.Count == 1 && lvMoves.SelectedItems[0].Group != lvMoves.Groups[2])
            {

                // We can get some useful move information.
                // Damage, class (physical or special)
                // Range
                // Frequency
                // Special (what it grants)
                // Description
                var lvi = lvMoves.SelectedItems[0];
                var tag = lvi.Tag as ManagedXml.Element;

                // Get the information.
                tbMoveDiceRoll.Text = tag.GetAttributeValue("Damage");
                tbMoveAC.Text = tag.GetAttributeValue("AC");
                tbMoveClass.Text = tag.GetAttributeValue("Class");
                tbMoveRange.Text = tag.GetAttributeValue("Range");
                tbMoveFrequency.Text = tag.GetAttributeValue("Frequency");
                tbMoveType.Text = tag.GetAttributeValue("Type");
                tbMoveSpecial.Text = tag.GetAttributeValue("Special");
                tbDescription.Text = tag.GetElement("Effect").Value;
                tbMoveTarget.Text = tag.GetElement("Target").Value;

            }
            else
            {
                tbMoveDiceRoll.Text = "";
                tbMoveAC.Text = "";
                tbMoveClass.Text = "";
                tbMoveRange.Text = "";
                tbMoveFrequency.Text = "";
                tbMoveType.Text = "";
                tbMoveSpecial.Text = "";
                tbMoveTarget.Text = "";
                tbDescription.Text = lvMoves.SelectedItems.Count > 0 && lvMoves.SelectedItems[0].Group == lvMoves.Groups[2] ? "TM's are not implemented yet." : "";
            }
        }
        private void lvAbilities_SelectedIndexChanged(object sender, EventArgs e)
        {
            tsbRemoveAbility.Enabled = lvAbilities.SelectedItems.Count > 0;
            tsbAbilityInformation.Enabled = lvAbilities.SelectedItems.Count == 1;
        }


        private void nudLevel_ValueChanged(object sender, EventArgs e)
        {
            UpdateStab();
            UpdateBonusPoints();
            UpdateAddAbility();
            if (nudExperience.ReadOnly)
            {
                nudExperience.Minimum = (decimal)GetExperience((int)nudLevel.Value);
                nudExperience.Maximum = nudExperience.Minimum;
                nudExperience.Value = nudExperience.Minimum;
            }
        }
        private void nudExperience_ValueChanged(object sender, EventArgs e)
        {
            if (!nudExperience.ReadOnly)
                nudLevel.Value = (decimal)GetLevel((double)nudExperience.Value);
        }
        private void nudAdded_Changed(object sender, EventArgs e)
        {
            UpdateBonusPoints();
            UpdateTotalStats();
            CheckStatRelation();
        }


        private void tsmi_rng_stats_Click(object sender, EventArgs e)
        {
            nudAddedAtk.Value = 0;
            nudAddedDef.Value = 0;
            nudAddedHp.Value = 0;
            nudAddedSpAtk.Value = 0;
            nudAddedSpDef.Value = 0;
            nudAddedSpeed.Value = 0;

            var points = CalculatePoints();

            while (points > 0)
            {
                switch (_rng.Next(1, 7))
                {
                    case 1:
                        nudAddedAtk.Value += 1;
                        break;

                    case 2:
                        nudAddedDef.Value += 1;
                        break;

                    case 3:
                        nudAddedHp.Value += 1;
                        break;

                    case 4:
                        nudAddedSpAtk.Value += 1;
                        break;

                    case 5:
                        nudAddedSpDef.Value += 1;
                        break;

                    case 6:
                        nudAddedSpeed.Value += 1;
                        break;
                }
                points -= 1;
            }

        }
        private void tsmi_rng_gender_Click(object sender, EventArgs e)
        {
            icbGender.SelectedIndex = _rng.Next(0, icbGender.Items.Count());
        }
        private void tsmi_rng_nature_Click(object sender, EventArgs e)
        {
            cbNatures.SelectedIndex = _rng.Next(0, cbNatures.Items.Count);
        }
        
        #region routines that run when an index/stat is changed

        private void UpdateImages()
        {
            var number = _currentPokemon.GetElement("Pokedex").GetAttributeValue("National");
            switch (number)
            {
                case "386":
                    if (icbPokemon.Text.ToLower().Contains("attack"))
                        number = "386a";
                    if (icbPokemon.Text.ToLower().Contains("defense"))
                        number = "386d";
                    if (icbPokemon.Text.ToLower().Contains("speed"))
                        number = "386s";
                    break;
                case "413":
                    if (icbPokemon.Text.ToLower().Contains("sandy"))
                        number = "413s";
                    if (icbPokemon.Text.ToLower().Contains("trash"))
                        number = "413t";
                    break;
                case "487":
                    if (icbPokemon.Text.ToLower().Contains("origin"))
                        number = "487o";
                    break;
                case "492":
                    if (icbPokemon.Text.ToLower().Contains("sky"))
                        number = "492s";
                    break;
                case "648":
                    if (icbPokemon.Text.ToLower().Contains("step"))
                        number = "648s";
                    break;
            }
            pbImage.BackgroundImage = ImgResources.Sprites.ResourceManager.GetObject("_" + number) as System.Drawing.Bitmap;
            Icon = Icon.FromHandle((ImgResources.Icons.ResourceManager.GetObject("_" + number) as System.Drawing.Bitmap).GetHicon());
        }
        private void UpdateBaseStats()
        {
            var stats = _currentPokemon.GetElement("Stats");

            nudBaseHP.Minimum = Convert.ToDecimal(stats.GetAttributeValue("Health"));
            nudBaseHP.Maximum = Convert.ToDecimal(stats.GetAttributeValue("Health"));

            nudBaseAtk.Minimum = Convert.ToDecimal(stats.GetAttributeValue("Attack"));
            nudBaseAtk.Maximum = Convert.ToDecimal(stats.GetAttributeValue("Attack"));

            nudBaseDef.Minimum = Convert.ToDecimal(stats.GetAttributeValue("Defense"));
            nudBaseDef.Maximum = Convert.ToDecimal(stats.GetAttributeValue("Defense"));

            nudBaseSpAtk.Minimum = Convert.ToDecimal(stats.GetAttributeValue("SpecialAttack"));
            nudBaseSpAtk.Maximum = Convert.ToDecimal(stats.GetAttributeValue("SpecialAttack"));

            nudBaseSpDef.Minimum = Convert.ToDecimal(stats.GetAttributeValue("SpecialDefense"));
            nudBaseSpDef.Maximum = Convert.ToDecimal(stats.GetAttributeValue("SpecialDefense"));

            nudBaseSpeed.Minimum = Convert.ToDecimal(stats.GetAttributeValue("Speed"));
            nudBaseSpeed.Maximum = Convert.ToDecimal(stats.GetAttributeValue("Speed"));

            UpdateTotalStats();

        }
        private bool UpdateBonusPoints()
        {
            var points = CalculatePoints();
            points -= (int)nudAddedHp.Value;
            points -= (int)nudAddedAtk.Value;
            points -= (int)nudAddedDef.Value;
            points -= (int)nudAddedSpAtk.Value;
            points -= (int)nudAddedSpDef.Value;
            points -= (int)nudAddedSpeed.Value;
            gbStats.Text = string.Format(
                "Stats - {0}{1}{2} points remaining", 
                points < 0 ? "(" : "", 
                points.ToString(), 
                points < 0 ? ")" : "");
            
            if (points < 0) lbErrors.Items.Add("Negative stat points");

            nudAddedHp.Maximum = points <= 0 ? nudAddedHp.Value : 10000;
            nudAddedAtk.Maximum = points <= 0 ? nudAddedAtk.Value : 10000;
            nudAddedDef.Maximum = points <= 0 ? nudAddedDef.Value : 10000;
            nudAddedSpAtk.Maximum = points <= 0 ? nudAddedSpAtk.Value : 10000;
            nudAddedSpDef.Maximum = points <= 0 ? nudAddedSpDef.Value : 10000;
            nudAddedSpeed.Maximum = points <= 0 ? nudAddedSpeed.Value : 10000;

            return (points < 0);

        }
        private void UpdateTotalStats()
        {

            var finalHP = (Math.Max((nudBaseHP.Value + nudNatureHP.Value), 1) + nudAddedHp.Value);
            var finalAtk = (Math.Max((nudBaseAtk.Value + nudNatureAtk.Value), 1) + nudAddedAtk.Value);
            var finalDef = (Math.Max((nudBaseDef.Value + nudNatureDef.Value), 1) + nudAddedDef.Value);
            var finalSpAtk = (Math.Max((nudBaseSpAtk.Value + nudNatureSpAtk.Value), 1) + nudAddedSpAtk.Value);
            var finalSpDef = (Math.Max((nudBaseSpDef.Value + nudNatureSpDef.Value), 1) + nudAddedSpDef.Value);
            var finalSpeed = (Math.Max((nudBaseSpeed.Value + nudNatureSpeed.Value), 1) + nudAddedSpeed.Value);

            finalHP = (_combatStages.Calculate(Classes.CombatStages.Types.HP, finalHP));
            finalAtk =(_combatStages.Calculate(Classes.CombatStages.Types.Attack, finalAtk));
            finalDef = (_combatStages.Calculate(Classes.CombatStages.Types.Defense, finalDef));
            finalSpAtk = (_combatStages.Calculate(Classes.CombatStages.Types.SpAtk, finalSpAtk));
            finalSpDef = (_combatStages.Calculate(Classes.CombatStages.Types.SpDef, finalSpDef));
            finalSpeed = (_combatStages.Calculate(Classes.CombatStages.Types.Speed, finalSpeed));

            tbFinalHP.Text = finalHP.ToString();
            tbFinalAtk.Text = finalAtk.ToString();
            tbFinalDef.Text = finalDef.ToString();
            tbFinalSpAtk.Text = finalSpAtk.ToString();
            tbFinalSpDef.Text = finalSpDef.ToString();
            tbFinalSpeed.Text = finalSpeed.ToString();

            nudMaxHealth.Maximum = finalHP * 3 + nudLevel.Value;
            nudMaxHealth.Minimum = nudMaxHealth.Maximum;

            nudCurrentHealth.Maximum = nudMaxHealth.Maximum;
            nudCurrentHealth.Minimum = -1 * nudMaxHealth.Maximum;

            UpdateEvasions();
            UpdateStatErrors();

        }
        private void UpdateTypes()
        {
            var typeOne = _currentPokemon.GetElement("Types").GetAttributeValue("First");
            var typeTwo = _currentPokemon.GetElement("Types").GetAttributeValue("Second");
            if (typeTwo.Trim() == string.Empty) typeTwo = "None";

            icbTypeOne.Text = typeOne;
            icbTypeTwo.Text = typeTwo;
        }
        private void UpdateGender()
        {
            var gender = _currentPokemon.GetElement("Gender");
            PopulateGenderBox(Convert.ToDouble(gender.GetAttributeValue("Male")) > 0,
                Convert.ToDouble(gender.GetAttributeValue("Female")) > 0);
        }
        private void UpdateStab()
        {
            tbStab.Text = CalculateStab().ToString();
        }
        private void UpdateEvasions()
        {
            tbPhysicalBonus.Text = CalculateEvasion("physical").ToString();
            tbSpecialBonus.Text = CalculateEvasion("special").ToString();
            tbSpeedBonus.Text = CalculateEvasion("both").ToString();
        }
        private void UpdateBasicCapabilities()
        {
            var capabilities = _currentPokemon.GetElement("Capabilities");
            var overland = capabilities.GetAttributeValue("Overland");
            var surface = capabilities.GetAttributeValue("Surface");
            var underwater = capabilities.GetAttributeValue("Underwater");
            var sky = capabilities.GetAttributeValue("Sky");
            var burrow = capabilities.GetAttributeValue("Burrow");
            var jump = capabilities.GetAttributeValue("Jump");
            var power = capabilities.GetAttributeValue("Power");
            var intelligence = capabilities.GetAttributeValue("Intelligence");

            lbBasicCapabilities.Items.Clear();

            if (overland == "") overland = "0";
            if (surface == "") surface = "0";
            if (underwater == "") underwater = "0";
            if (sky == "") sky = "0";
            if (burrow == "") burrow = "0";
            if (jump == "") jump = "0";
            if (power == "") power = "0";
            if (intelligence == "") intelligence = "0";

            lbBasicCapabilities.Items.Add(string.Format("Overland: {0}", overland));
            lbBasicCapabilities.Items.Add(string.Format("Surface: {0}", surface));
            lbBasicCapabilities.Items.Add(string.Format("Underwater: {0}", underwater));
            lbBasicCapabilities.Items.Add(string.Format("Sky: {0}", sky));
            lbBasicCapabilities.Items.Add(string.Format("Burrow: {0}", burrow));
            lbBasicCapabilities.Items.Add(string.Format("Jump: {0}", jump));
            lbBasicCapabilities.Items.Add(string.Format("Power: {0}", power));
            lbBasicCapabilities.Items.Add(string.Format("Intelligence: {0}", intelligence));
            UpdateCustomCapabilities();
            

        }
        private void UpdateCustomCapabilities()
        {

            // Declare my capabilities
            var capabilities = _currentPokemon.GetElement("Capabilities");
            var lviArray = new ListViewItem[lvMoves.Items.Count];

            // Clear and add.
            lbCapabilities.Items.Clear();
            foreach (var item in capabilities.Children) lbCapabilities.Items.Add(item.Value);

            // Copy over
            lvMoves.Items.CopyTo(lviArray, 0);

            // Loop through all the items in the moves.
            foreach (var item in lviArray.Where(
                m => m.Tag != null && 
                    (m.Tag as ManagedXml.Element).GetAttributeValue("Special").Length > 0)
                    .Select(m => (m.Tag as ManagedXml.Element).GetAttributeValue("Special")).Distinct())
                    if(!lbCapabilities.Items.Contains(item.Trim()))
                        lbCapabilities.Items.Add(item);


        }
        private void UpdateAddAbility()
        {
            if (lvAbilities.Items.Count == 0) tsbAddAbility.Enabled = true;
            if (lvAbilities.Items.Count == 1) tsbAddAbility.Enabled = nudLevel.Value >= 40;
            if (lvAbilities.Items.Count == 3) tsbAddAbility.Enabled = false;
        }
        private bool CheckStatRelation()
        {

            var properGrouping = new Dictionary<string, decimal>()
            {
                {"HP", nudBaseHP.Value + nudNatureHP.Value}, 
                {"ATK", nudBaseAtk.Value + nudNatureAtk.Value},
                {"DEF", nudBaseDef.Value + nudNatureDef.Value},
                {"SPATK", nudBaseSpAtk.Value + nudNatureSpAtk.Value},
                {"SPDEF", nudBaseSpDef.Value + nudNatureSpDef.Value},
                {"SPEED", nudBaseSpeed.Value + nudNatureSpeed.Value}
            };

            var secondGrouping = new Dictionary<string, decimal>()
            {
                {"HP", nudBaseHP.Value + nudNatureHP.Value + nudAddedHp.Value}, 
                {"ATK", nudBaseAtk.Value + nudNatureAtk.Value + nudAddedAtk.Value},
                {"DEF", nudBaseDef.Value + nudNatureDef.Value + nudAddedDef.Value},
                {"SPATK", nudBaseSpAtk.Value + nudNatureSpAtk.Value + nudAddedSpAtk.Value},
                {"SPDEF", nudBaseSpDef.Value + nudNatureSpDef.Value + nudAddedSpDef.Value},
                {"SPEED", nudBaseSpeed.Value + nudNatureSpeed.Value + nudAddedSpeed.Value}
            };

            var properGroups = properGrouping.GroupBy(o => o.Value).ToList();


            var isProperRelation = true;

            //for (int i = 0; i < newProper.Count; i++)
            //    if (isProperRelation) isProperRelation = newProper[i] == newResult[i];

            return isProperRelation;

        }
        private void UpdateStatErrors()
        {
            lbErrors.Items.Clear();
            if (UpdateBonusPoints()) lbErrors.Items.Add("Negative Stat Points");
            if (!CheckStatRelation()) lbErrors.Items.Add("Bad Stat Relations");
        }

        private int CalculateStab()
        {
            return (Convert.ToInt32(nudLevel.Value)) / 5;
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
             * - Starting at level 51, Pokemon gain two Added Stats per level gained. 
             * 
             * - Starting at level 76, Pokemon gain three Added Stats per level gained. 
             */

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
        private int CalculateEvasion(string type)
        {
            var retVal = 0;
            if (type.ToLowerInvariant() == "physical")
                retVal = Convert.ToInt32(tbFinalDef.Text) / 5;
            if (type.ToLowerInvariant() == "special")
                retVal = Convert.ToInt32(tbFinalSpDef.Text) / 5;
            if (type.ToLowerInvariant() == "both")
                retVal = Convert.ToInt32(tbFinalSpeed.Text) / 10;
            return Math.Min(retVal, 6);
        }

        #endregion

        private void btnAddCS(object sender, EventArgs e)
        {
            var btn = sender as ToolStripDropDownItem;
            switch (btn.Name)
            {
                case "hPToolStripMenuItem": _combatStages.HP = Math.Min(_combatStages.HP + 1, 6); break;
                case "attackToolStripMenuItem": _combatStages.Attack = Math.Min(_combatStages.Attack + 1, 6); break;
                case "defenseToolStripMenuItem": _combatStages.Defense = Math.Min(_combatStages.Defense + 1, 6); break;
                case "specialAttackToolStripMenuItem": _combatStages.SpAtk = Math.Min(_combatStages.SpAtk + 1, 6); break;
                case "specialDefenseToolStripMenuItem": _combatStages.SpDef = Math.Min(_combatStages.SpDef + 1, 6); break;
                case "speedToolStripMenuItem": _combatStages.Speed = Math.Min(_combatStages.Speed + 1, 6); break;
            }
            UpdateCSButtons();
            UpdateTotalStats();
        }
        private void btnRemoveCS(object sender, EventArgs e)
        {
            var btn = sender as ToolStripDropDownItem;
            switch (btn.Name)
            {
                case "hPToolStripMenuItem1": _combatStages.HP = Math.Max(_combatStages.HP - 1, -6); break;
                case "attackToolStripMenuItem1": _combatStages.Attack = Math.Max(_combatStages.Attack - 1, -6); break;
                case "defenseToolStripMenuItem1": _combatStages.Defense = Math.Max(_combatStages.Defense - 1, -6); break;
                case "specialAttackToolStripMenuItem1": _combatStages.SpAtk = Math.Max(_combatStages.SpAtk - 1, -6); break;
                case "specialDefenseToolStripMenuItem1": _combatStages.SpDef = Math.Max(_combatStages.SpDef - 1, -6); break;
                case "speedToolStripMenuItem1": _combatStages.Speed = Math.Max(_combatStages.Speed - 1, -6); break;
            }
            UpdateCSButtons();
            UpdateTotalStats();
        }
        private void btnClearCS(object sender, EventArgs e)
        {
            var btn = sender as ToolStripDropDownItem;
            switch (btn.Name)
            {
                case "hPToolStripMenuItem2": _combatStages.HP = 0; break;
                case "attackToolStripMenuItem2": _combatStages.Attack = 0; break;
                case "defenseToolStripMenuItem2": _combatStages.Defense = 0; break;
                case "specialAttackToolStripMenuItem2": _combatStages.SpAtk = 0; break;
                case "specialDefenseToolStripMenuItem2": _combatStages.SpDef = 0; break;
                case "speedToolStripMenuItem2": _combatStages.Speed = 0; break;
                case "allToolStripMenuItem":
                    _combatStages.HP = 0;
                    _combatStages.Attack = 0;
                    _combatStages.Defense = 0;
                    _combatStages.SpAtk = 0;
                    _combatStages.SpDef = 0;
                    _combatStages.Speed = 0;
                    break;
            }
            UpdateCSButtons();
            UpdateTotalStats();
        }
        private void UpdateCSButtons()
        {

            var hpText = "";
            var atkText = "";
            var defText = "";
            var spAtkText = "";
            var spDefText = "";
            var speedText = "";

            if (_combatStages.HP == 0) hpText = "HP"; else hpText = string.Format("HP ({0}{1})", _combatStages.HP > 0 ? "+" : "", _combatStages.HP);
            if (_combatStages.Attack == 0) atkText = "Attack"; else atkText = string.Format("Attack ({0}{1})", _combatStages.Attack > 0 ? "+" : "", _combatStages.Attack);
            if (_combatStages.Defense == 0) defText = "Defense"; else defText = string.Format("Defense ({0}{1})", _combatStages.Defense > 0 ? "+" : "", _combatStages.Defense);
            if (_combatStages.SpAtk == 0) spAtkText = "SpAtk"; else spAtkText = string.Format("SpAtk ({0}{1})", _combatStages.SpAtk > 0 ? "+" : "", _combatStages.SpAtk);
            if (_combatStages.SpDef == 0) spDefText = "SpDef"; else spDefText = string.Format("SpDef ({0}{1})", _combatStages.SpDef > 0 ? "+" : "", _combatStages.SpDef);
            if (_combatStages.Speed == 0) speedText = "Speed"; else speedText = string.Format("Speed ({0}{1})", _combatStages.Speed > 0 ? "+" : "", _combatStages.Speed);

            hPToolStripMenuItem.Text = hpText;
            hPToolStripMenuItem1.Text = hpText;
            hPToolStripMenuItem2.Text = hpText;

            attackToolStripMenuItem.Text = atkText;
            attackToolStripMenuItem1.Text = atkText;
            attackToolStripMenuItem2.Text = atkText;

            defenseToolStripMenuItem.Text = defText;
            defenseToolStripMenuItem1.Text = defText;
            defenseToolStripMenuItem2.Text = defText;

            specialAttackToolStripMenuItem.Text = spAtkText;
            specialAttackToolStripMenuItem1.Text = spAtkText;
            specialAttackToolStripMenuItem2.Text = spAtkText;

            specialDefenseToolStripMenuItem.Text = spDefText;
            specialDefenseToolStripMenuItem1.Text = spDefText;
            specialDefenseToolStripMenuItem2.Text = spDefText;

            speedToolStripMenuItem.Text = speedText;
            speedToolStripMenuItem1.Text = speedText;
            speedToolStripMenuItem2.Text = speedText;

        }

    }

}