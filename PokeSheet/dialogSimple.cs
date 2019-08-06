using System;
using System.Windows.Forms;
using PokeSheet.Properties;

namespace PokeSheet
{
    public partial class DialogSimple : Form
    {
        public DialogSimple()
        {
            InitializeComponent();
            Icon = Resources.Pokeball16;
        }

        private void BtnGenerateClick(object sender, EventArgs e)
        {

            // have the parent form add the thingy
            ((FrmMain)Owner).AddPage();

            // added, now with the current tab, do magic.
            var sheet = ((FrmMain)Owner).GetActiveSheet();

            // now generate
            sheet.GeneratePokemonSimple(cbSpecies.SelectedIndex, (int) nudLowerLevel.Value, (int) nudUpperLevel.Value,
                                        cboxRandomNature.Checked, cboxRandomGender.Checked, cboxRandomEv.Checked);

        }

        private void DialogSimpleLoad(object sender, EventArgs e)
        {
            foreach (var pokemon in Static.Pokemon)
                cbSpecies.Items.Add(pokemon);
            cbSpecies.SelectedIndex = 0;
        }

        private void BtnResetClick(object sender, EventArgs e)
        {
            cbSpecies.SelectedIndex = 0;
            nudLowerLevel.Value = 1;
            nudUpperLevel.Value = 1;
            cboxRandomNature.Checked = false;
            cboxRandomGender.Checked = false;
            cboxRandomEv.Checked = false;
        }

        private void NudLowerLevelValueChanged(object sender, EventArgs e)
        {
            nudUpperLevel.Minimum = nudLowerLevel.Value;
        }
    }
}
