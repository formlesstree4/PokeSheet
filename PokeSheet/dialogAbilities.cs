using System;
using System.Linq;
using System.Windows.Forms;
using Parser.Types;
using PokeSheet.Properties;

namespace PokeSheet
{
    public partial class DialogAbilities : Form
    {
        public DialogAbilities()
        {
            InitializeComponent();
            Icon = Resources.Pokeball16;
        }
        public void SelectMove(string name)
        {
            cbAbilities.SelectedItem = cbAbilities.Items.Cast<object>().First(item => ((Ability)item).Name.Equals(name));
        }

        private void DialogAbilitiesLoad(object sender, EventArgs e)
        {
            foreach (var ability in Static.Abilities)
                cbAbilities.Items.Add(ability);
            cbAbilities.SelectedIndex = 0;
        }
        private void CbAbilitiesSelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbAbilities.SelectedIndex > -1)
            {
                var currentAbility = (Ability) cbAbilities.SelectedItem;
                tbInitialization.Text = currentAbility.Activation;
                tbLimit.Text = currentAbility.Limit;
                tbEffect.Text = currentAbility.Effect;
                tbKeyword.Text = currentAbility.Keywords;
            }
            else
            {
                tbInitialization.Clear();
                tbLimit.Clear();
                tbEffect.Clear();
                tbKeyword.Clear();
            }
        }
    }
}
