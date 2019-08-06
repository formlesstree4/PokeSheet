using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PtaSheet.Forms
{

    public partial class Moves : Form
    {

        public ManagedXml.Element MoveElement { get; set; }
        public ManagedXml.Element Pokemon { get; set; }
        public ManagedXml.Element Results { get; set; }

        public IEnumerable<string> KnownMoves { get; set; }
        public IEnumerable<string> KnownTutor { get; set; }
        public IEnumerable<string> KnownTM { get; set; }
        public IEnumerable<string> KnownEgg { get; set; }
        
        public Moves()
        {
            InitializeComponent();
            
            if (KnownMoves == null)
                KnownMoves = new List<string>();
            if (KnownTutor == null)
                KnownTutor = new List<string>();
            if (KnownTM == null)
                KnownTM = new List<string>();
            if (KnownEgg == null)
                KnownEgg = new List<string>();
        }

        private bool IsGhostType()
        {
            var pokeType = Pokemon.GetElement("Types");
            return pokeType.GetAttributeValue("First") == "Ghost" || pokeType.GetAttributeValue("Second") == "Ghost";
        }
        private string GetImageFromName(string name, bool careAboutCurse = false, string type = "")
        {

            // Default return value.
            string returnValue = "UnknownIC.png";

            // Curse is a special lookup.
            if (careAboutCurse && name == "Curse")
                if (IsGhostType())
                    returnValue = "GhostIC.gif";
                else
                    returnValue = "NormalIC.gif";
            else
            {
                var moveType = MoveElement.Children.Where(m => m.GetAttributeValue("name") == name);
                if (!string.IsNullOrEmpty(type))
                    moveType = moveType.Where(m => m.GetAttributeValue("Type") == type);
                if (moveType != null)
                {
                    var move = moveType.FirstOrDefault();
                    if (move != null)
                        returnValue = string.Format("{0}IC.gif", move.GetAttributeValue("Type"));
                }
            }
            return returnValue;
        }
        private void CreateGlobalMoves()
        {
            var moveList = MoveElement.Children.OrderBy(m => m.GetAttributeValue("Type")).ThenBy(m => m.GetAttributeValue("name"));
            foreach (var item in moveList)
                lvAllMoves.Items.Add(new ListViewItem() { 
                        Text = item.GetAttributeValue("name"), 
                        Tag = item, 
                        Group = lvMoves.Groups[0],
                        ImageKey = GetImageFromName(item.GetAttributeValue("name"), false, item.GetAttributeValue("Type"))
                    });
        }
        private void CreateFilteredMoves()
        {
            var moves = Pokemon.GetElement("Moves");
            var levelup = moves.GetElement("Levelup");
            var TMs = moves.GetElement("TMs");
            var eggs = moves.GetElement("Egg");
            var tutor = moves.GetElement("Tutor");

            if (levelup != null)
            {
                foreach (var item in levelup.Children.OrderBy(m => Convert.ToInt32(m.GetAttributeValue("Level"))).Where(m => !KnownMoves.Contains(m.GetAttributeValue("Name"))))
                {
                    var name = item.GetAttributeValue("Name");
                    var level = item.GetAttributeValue("Level");
                    var moveResults = MoveElement.Children.Where(m => m.GetAttributeValue("name") == name);
                    ManagedXml.Element move;

                    try
                    {
                        if (name == "Curse")
                            if (IsGhostType())
                                move = moveResults.First(m => m.GetAttributeValue("Type") == "Ghost");
                            else
                                move = moveResults.First(m => m.GetAttributeValue("Type") != "Ghost");
                        else
                            move = moveResults.First();
                        lvMoves.Items.Add(new ListViewItem()
                        {
                            Text = string.Format("{0} - Level {1}", name, level),
                            Tag = move,
                            Group = lvMoves.Groups[0],
                            ImageKey = GetImageFromName(name, true, move.GetAttributeValue("Type"))
                        });

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Level Move " + name + " is broken.");
                    }
                }
            }

            if (tutor != null)
            {
                if (tutor.Children.Count == 1 && tutor.Children[0].GetAttributeValue("Name") == "*")
                {
                    foreach (var item in MoveElement.Children)
                    {
                        var name = item.GetAttributeValue("name");
                        var move = item;
                        lvMoves.Items.Add(new ListViewItem()
                        {
                            Text = name,
                            Tag = move,
                            Group = lvMoves.Groups[1],
                            ImageKey = GetImageFromName(name, true, move.GetAttributeValue("Type"))
                        });
                    }
                }
                else
                {
                    foreach (var item in tutor.Children.OrderBy(m => m.GetAttributeValue("Name")).Where(m => !KnownTutor.Contains(m.GetAttributeValue("Name"))))
                    {
                        var name = item.GetAttributeValue("Name");
                        var moveResults = MoveElement.Children.Where(m => m.GetAttributeValue("name") == name);
                        ManagedXml.Element move;

                        try
                        {
                            if (name == "Curse")
                                if (IsGhostType())
                                    move = moveResults.First(m => m.GetAttributeValue("Type") == "Ghost");
                                else
                                    move = moveResults.First(m => m.GetAttributeValue("Type") != "Ghost");
                            else
                                move = moveResults.First();
                            lvMoves.Items.Add(new ListViewItem()
                            {
                                Text = name,
                                Tag = move,
                                Group = lvMoves.Groups[1],
                                ImageKey = GetImageFromName(name, true, move.GetAttributeValue("Type"))
                            });

                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Tutor Move " + name + " is broken.");
                        }

                    }
                }
            }
            if (eggs != null)
            {
                foreach (var item in eggs.Children.OrderBy(m => m.GetAttributeValue("Name")).Where(m => !KnownEgg.Contains(m.GetAttributeValue("Name"))))
                {
                    var name = item.GetAttributeValue("Name");
                    var moveResults = MoveElement.Children.Where(m => m.GetAttributeValue("name") == name);
                    ManagedXml.Element move;

                    try
                    {
                        if (name == "Curse")
                            if (IsGhostType())
                                move = moveResults.First(m => m.GetAttributeValue("Type") == "Ghost");
                            else
                                move = moveResults.First(m => m.GetAttributeValue("Type") != "Ghost");
                        else
                            move = moveResults.First();
                        lvMoves.Items.Add(new ListViewItem()
                        {
                            Text = name,
                            Tag = move,
                            Group = lvMoves.Groups[2],
                            ImageKey = GetImageFromName(name, true, move.GetAttributeValue("Type"))
                        });

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Egg Move " + name + " is broken.");
                    }

                }
            }
            if (TMs != null)
            {
                foreach (var item in TMs.Children.OrderBy(m => m.Value).Where(m => !KnownTM.Contains(m.GetAttributeValue("Name"))))
                {
                    var name = item.Value;

                    lvMoves.Items.Add(new ListViewItem()
                    {
                        Text = name,
                        Tag = item,
                        Group = lvMoves.Groups[3],
                        ImageKey = GetImageFromName(name)
                    });

                }
            }
        }

        private void Moves_Load(object sender, EventArgs e)
        {

            // Load the moves.
            CreateGlobalMoves();
            lvAllMoves.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            // Check for a POKEY~
            if (Pokemon == null)
            {
                MessageBox.Show("The Pokemon field was left null or blank!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnOkay.Enabled = false;
            }
            else
                CreateFilteredMoves();

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Moves_FormClosing(object sender, FormClosingEventArgs e)
        {

            // Okay, time to build our results list.
            Results = ManagedXml.Element.Create("Moves");

            // Get all the selected items.
            var all = ManagedXml.Element.Create("General");
            var lvl = ManagedXml.Element.Create("Levelup");
            var tut = ManagedXml.Element.Create("Tutor");
            var egg = ManagedXml.Element.Create("Egg");
            var TMs = ManagedXml.Element.Create("TMs");

            // Loop
            foreach (var item in lvAllMoves.SelectedItems)
                all.Children.Add((item as ListViewItem).Tag as ManagedXml.Element);

            // Loop through the rest.
            foreach (var item in lvMoves.SelectedItems)
            {
                var lvi = item as ListViewItem;
                switch (lvi.Group.Name)
                {
                    case "lvgLevel":
                        lvl.Children.Add(lvi.Tag as ManagedXml.Element);
                        break;
                    case "lvgTutor":
                        tut.Children.Add(lvi.Tag as ManagedXml.Element);
                        break;
                    case "lvgEgg":
                        egg.Children.Add(lvi.Tag as ManagedXml.Element);
                        break;
                    case "lvgTm":
                        TMs.Children.Add(lvi.Tag as ManagedXml.Element);
                        break;
                }
            }

            // Add to Results.
            Results.Children.Add(all);
            Results.Children.Add(lvl);
            Results.Children.Add(tut);
            Results.Children.Add(egg);
            Results.Children.Add(TMs);
            Results.Encoding = Encoding.UTF8;

        }

        private void btnOkay_Click(object sender, EventArgs e)
        {

        }
        
    }

}