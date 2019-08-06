using System;
using System.Drawing;
using System.Windows.Forms;
using PokeSheet.Control;
using System.Collections.Generic;
using PokeSheet.Properties;

namespace PokeSheet
{
    public partial class FrmMain : Form
    {

        private List<TabPage> Recent { get; set; } 

        public FrmMain()
        {
            InitializeComponent();
            Icon = Resources.Pokeball16;
        }

        public void EnableParsing()
        {
            parsingToolStripMenuItem.Visible = true;
        }
        private void NameChange(object sender, PokemonNameChangeEventArgs e)
        {
            // get the parent
            var parent = (TabPage)((System.Windows.Forms.Control)sender).Parent;
            parent.Text = e.Name;
        }
        public void AddPage()
        {
            
            var tp = new TabPage {Text = string.Format("Pokemon {0}", tcPkmn.TabCount + 1)};
            var sheet = new Sheet { Name = string.Format("sheet{0}", tcPkmn.TabCount), Location = new Point(3, 3) };
            tcPkmn.TabPages.Add(tp);
            tp.Controls.Add(sheet);
            sheet.NameChanged += NameChange;
            sheet.LoadPokemon(Static.PokemonCollection.ToArray());
            tp.Text = sheet.Pokemon;
            sheet.InitializeSheet();
            closeTabToolStripMenuItem.Enabled = true;
            saveCurrentToolStripMenuItem.Enabled = true;
            tcPkmn.SelectedIndex = tcPkmn.TabCount - 1;

        }
        public Sheet GetActiveSheet()
        {
            return (Sheet)tcPkmn.SelectedTab.Controls[0];
        }
        private void FrmMainLoad(object sender, EventArgs e)
        {
            Recent = new List<TabPage>();
        }

        private void NewTabToolStripMenuItemClick(object sender, EventArgs e)
        {
            AddPage();
        }
        private void CloseTabToolStripMenuItemClick(object sender, EventArgs e)
        {
            var index = tcPkmn.SelectedIndex;
            Recent.Add(tcPkmn.SelectedTab);
            tcPkmn.TabPages.Remove(tcPkmn.SelectedTab);

            // check
            if(tcPkmn.TabCount.Equals(0))
            {
                closeTabToolStripMenuItem.Enabled = false;
                saveCurrentToolStripMenuItem.Enabled = false;
                // saveAllToolStripMenuItem.Enabled = false;
            }
            else
            {
                if (tcPkmn.TabCount <= index)
                    index = index - 1;
                tcPkmn.SelectedIndex = index;
            }

        }
        private void FromFileToolStripMenuItemClick(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog {Filter = Resources.IniFilter, Title = Resources.OpenPokemonFile, Multiselect = true};
            if(ofd.ShowDialog().Equals(DialogResult.OK))
            {
                foreach (var fileName in ofd.FileNames)
                {
                    var tp = new TabPage();
                    var sheet = new Sheet { Name = string.Format("sheet{0}", tcPkmn.TabCount), Location = new Point(3, 3) };
                    tcPkmn.TabPages.Add(tp);
                    tp.Controls.Add(sheet);
                    sheet.NameChanged += NameChange;
                    sheet.LoadPokemon(Static.PokemonCollection.ToArray());
                    tp.Text = sheet.Pokemon;
                    sheet.InitializeSheet();
                    sheet.LoadINI(fileName);
                }
            }

            closeTabToolStripMenuItem.Enabled = tcPkmn.TabCount > 0;
            saveCurrentToolStripMenuItem.Enabled = tcPkmn.TabCount > 0;
        }
        private void SaveCurrentToolStripMenuItemClick(object sender, EventArgs e)
        {
            var sheet = (Sheet) tcPkmn.SelectedTab.Controls[0];
            sheet.SaveINI();
        }
        private void RecentlyClosedToolStripMenuItemClick(object sender, EventArgs e)
        {
            var recentDlg = new DialogRecent {RecentlyClosed = Recent};
            if(recentDlg.ShowDialog().Equals(DialogResult.OK))
                tcPkmn.TabPages.AddRange(recentDlg.SelectedTabs.ToArray());
            closeTabToolStripMenuItem.Enabled = tcPkmn.TabCount > 0;
            saveCurrentToolStripMenuItem.Enabled = tcPkmn.TabCount > 0;
        }
        private void ClearRecentToolStripMenuItemClick(object sender, EventArgs e)
        {
            Recent.Clear();
        }
        private void ExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            Close();
        }

        private void ParseMovesToolStripMenuItemClick(object sender, EventArgs e)
        {

            var ofd = new OpenFileDialog {Title = string.Format(Resources.OfdTitle, "move"), Filter = Resources.TextFileFilter};
            if (ofd.ShowDialog().Equals(DialogResult.OK))
            {
                try
                {
                    Parser.Parsing.Moves(ofd.FileName);
                    Static.Load();
                    MessageBox.Show(Resources.MoveParsed, Resources.Yay, MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Resources.ParseFailed, Resources.ParseFailed, MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    MessageBox.Show(ex.ToString());
                }
                
            }
            
            
        }
        private void ParseAbilitiesToolStripMenuItemClick(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog { Title = string.Format(Resources.OfdTitle, "abilities"), Filter = Resources.TextFileFilter };
            if (ofd.ShowDialog().Equals(DialogResult.OK))
            {
                try
                {
                    Parser.Parsing.Abilities(ofd.FileName);
                    Static.Load();
                    MessageBox.Show(Resources.AbilityParsed, Resources.Yay, MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Resources.ParseFailed, Resources.ParseFailed, MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        private void ParsePokemonToolStripMenuItemClick(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog { Title = string.Format(Resources.OfdTitle, "Pokémon"), Filter = Resources.TextFileFilter };
            if (ofd.ShowDialog().Equals(DialogResult.OK))
            {
                Parser.Parsing.Pokemon(ofd.FileName);
                try
                {
                    
                    Static.Load();
                    MessageBox.Show(Resources.PokemonParsed, Resources.Yay, MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Resources.ParseFailed, Resources.ParseFailed, MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        private void ParseCapabilitiesToolStripMenuItemClick(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog { Title = string.Format(Resources.OfdTitle, "Capabilities"), Filter = Resources.TextFileFilter };
            if (ofd.ShowDialog().Equals(DialogResult.OK))
            {
                try
                {
                    Parser.Parsing.Capabilities(ofd.FileName);
                    Static.Load();
                    MessageBox.Show(Resources.CapabilityParsed, Resources.Yay, MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Resources.ParseFailed, Resources.ParseFailed, MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        private void SimpleGeneratorToolStripMenuItemClick(object sender, EventArgs e)
        {
            new DialogSimple {Owner = this}.Show();
        }
        private void AboutToolStripMenuItemClick(object sender, EventArgs e)
        {
            new DialogAbout().ShowDialog();
        }
        private void ViewMovesToolStripMenuItemClick(object sender, EventArgs e)
        {
            new DialogMoves().Show();
        }
        private void CapabilityListToolStripMenuItemClick(object sender, EventArgs e)
        {
            new DialogCapabilities().Show();
        }
        private void AbilityListToolStripMenuItemClick(object sender, EventArgs e)
        {
            new DialogAbilities().Show();
        }

    }
}
