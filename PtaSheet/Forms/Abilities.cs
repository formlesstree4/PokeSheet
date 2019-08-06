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
    public partial class Abilities : Form
    {

        public List<string> Ability { get; set; }
        public List<string> High { get; set; }
        public int Level { get; set; }

        public string NewAbility { get; private set; }
        public bool IsHigh { get; private set; }

        public Abilities()
        {
            InitializeComponent();
        }

        private void Abilities_Load(object sender, EventArgs e)
        {
            foreach (var item in Ability) lvAbilities.Items.Add(new ListViewItem { Group = lvAbilities.Groups[0], Text = item });
            if(Level >= 40) foreach (var item in High) lvAbilities.Items.Add(new ListViewItem { Group = lvAbilities.Groups[1], Text = item });
            NewAbility = "";
            IsHigh = false;
            
        }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            NewAbility = lvAbilities.SelectedItems[0].Text;
            IsHigh = lvAbilities.SelectedItems[0].Group == lvAbilities.Groups[1];
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }



    }
}
