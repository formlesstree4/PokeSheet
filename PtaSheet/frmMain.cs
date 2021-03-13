using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PtaSheet
{

    public partial class frmMain : Form
    {

        ManagedXml.Element _pokemon = new ManagedXml.Reader(System.IO.File.ReadAllText("Resources\\XML\\textdex.xml")).Xml;
        ManagedXml.Element _moves = new ManagedXml.Reader(System.IO.File.ReadAllText("Resources\\XML\\movetext.xml")).Xml;
        ManagedXml.Element _abilities = new ManagedXml.Reader(System.IO.File.ReadAllText("Resources\\XML\\abilities.xml")).Xml;

        public frmMain()
        {

            // Initialize the form.
            InitializeComponent();

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Forms.About().ShowDialog();
        }
        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }
        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }
        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void pokedexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new Forms.Sheet { MdiParent = this, PokemonList = _pokemon, MoveList = _moves, AbilityList = _abilities };
            Bind(frm);
            frm.Show();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog { Filter = "Pokémon File|*.xml", Title = "Open Pokémon", Multiselect = true };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < ofd.FileNames.Length; i++)
                {
                    var x = new Forms.Sheet { MdiParent = this, PokemonList = _pokemon, MoveList = _moves, AbilityList = _abilities };
                    Bind(x);
                    x.Show();
                    x.LoadXml(ofd.FileNames[i]);
                }
            }
        }

        private void frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            (sender as Forms.Sheet).TitleChanged -= frm_TitleChanged;
            (sender as Forms.Sheet).FormClosing -= frm_FormClosing;
        }
        private void frm_TitleChanged()
        {
            var activeForm = this.ActiveMdiChild;
            if (activeForm != null)
            {
                this.SuspendLayout();
                this.ActivateMdiChild(null);
                this.ActivateMdiChild(activeForm);
                this.ResumeLayout();
            }
        }

        public void Bind(Forms.Sheet window)
        {
            window.TitleChanged += frm_TitleChanged;
            window.FormClosing += frm_FormClosing;
        }

        private void damageCalculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Forms.DamageCalculator() { MdiParent = this, Moves = _moves }.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
        

    }

}
