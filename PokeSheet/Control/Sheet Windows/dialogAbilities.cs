using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PokeSheet.Control.Sheet_Windows
{
    public partial class DialogAbilities : Form
    {

        public List<string> Abilities { get; set; }
        public string SelectedAbility { get; set; } 

        public DialogAbilities()
        {
            InitializeComponent();
        }

        private void DialogAbilitiesLoad(object sender, EventArgs e)
        {
            foreach (var ability in Abilities)
                lbAbilities.Items.Add(ability);
        }

        private void DialogAbilitiesFormClosing(object sender, FormClosingEventArgs e)
        {
            if(lbAbilities.SelectedIndex > -1)
                SelectedAbility = lbAbilities.SelectedItem.ToString();
        }

        private void LbAbilitiesSelectedIndexChanged(object sender, EventArgs e)
        {
            btnOk.Enabled = lbAbilities.SelectedIndex > -1;
        }

    }
}
