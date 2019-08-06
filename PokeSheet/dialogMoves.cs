using System;
using System.Linq;
using System.Windows.Forms;
using Parser.Types;
using PokeSheet.Properties;

namespace PokeSheet
{
    public partial class DialogMoves : Form
    {
        public DialogMoves()
        {
            InitializeComponent();
            Icon = Resources.Pokeball16;
        }

        public void SelectMove(string name)
        {
            cbMoves.SelectedItem = cbMoves.Items.Cast<object>().First(item => ((Move) item).Name.Equals(name));
        }
        private void DialogMovesLoad(object sender, EventArgs e)
        {
            var moveList = Static.Moves;
            moveList.Sort((m1, m2) => String.CompareOrdinal(m1.Name, m2.Name));

            foreach (var move in moveList)
                cbMoves.Items.Add(move);
            cbMoves.SelectedIndex = 0;
        }
        private void CbMovesSelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbMoves.SelectedIndex > -1)
            {
                var currentMove = (Move)cbMoves.SelectedItem;
                tbType.Text = currentMove.Type;
                tbFrequency.Text = currentMove.Frequency;
                tbRange.Text = currentMove.Range;
                tbAccuracy.Text = currentMove.Accuracy;
                tbDamage.Text = currentMove.Damage;
                tbClass.Text = currentMove.Class;
                tbTarget.Text = currentMove.Targets;
                tbSpecial.Text = currentMove.Special;
                tbEffect.Text = currentMove.Effect;

                tbConEffect.Text = currentMove.ContestEffect;
                tbConAppeal.Text = currentMove.Appeal;
                tbConType.Text = currentMove.ContestType;
            }
            else
            {
                tbType.Clear();
                tbFrequency.Clear();
                tbRange.Clear();
                tbAccuracy.Clear();
                tbDamage.Clear();
                tbClass.Clear();
                tbTarget.Clear();
                tbSpecial.Clear();
                tbEffect.Clear();
                tbConEffect.Clear();
                tbConAppeal.Clear();
                tbConType.Clear();
            }
        }

        private void LlKeyWordsLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new DialogKeywords().Show();
        }

    }
}
