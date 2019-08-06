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
    public partial class DamageCalculator : Form
    {

        public ManagedXml.Element Moves { get; set; }
        private List<ManagedXml.Element> _sortedMoves;

        public DamageCalculator()
        {
            InitializeComponent();
        }

        public string Move { get; set; }
        private string GetImageFromName(string name, string type = "")
        {

            // Default return value.
            string returnValue = "UnknownIC.png";

            // Curse is a special lookup.
            var moveType = Moves.Children.Where(m => m.GetAttributeValue("name") == name);
            if (!string.IsNullOrEmpty(type))
                moveType = moveType.Where(m => m.GetAttributeValue("Type") == type);
            if (moveType != null)
            {
                var move = moveType.FirstOrDefault();
                if (move != null)
                    returnValue = string.Format("{0}IC.gif", move.GetAttributeValue("Type"));
            }
            return returnValue;

        }
        private void DamageCalculator_Load(object sender, EventArgs e)
        {

            // Get all the moves that are actually plausible to be in the move list.
            var sRegex = @"\d{1,}[d]\d{1,}((\+(\d{1,}|[X]))?)";
            var oRegex = new System.Text.RegularExpressions.Regex(sRegex, System.Text.RegularExpressions.RegexOptions.Compiled);
            _sortedMoves = Moves.Children.Where(c => c.GetAttributeValue("Damage").Length > 0).Where(c => oRegex.IsMatch(c.GetAttributeValue("Damage"))).OrderBy(c => c.GetAttributeValue("Type")).ThenBy(c => c.GetAttributeValue("name")).ToList();

            foreach (var item in _sortedMoves)
                icb_moves.Items.Add(new ComboxExtended.ComboBoxItem(item.GetAttributeValue("name"), ilTypes.Images[GetImageFromName(item.GetAttributeValue("name"), item.GetAttributeValue("Type"))]));

            icb_moves.SelectedIndex = 0;
            if (!string.IsNullOrEmpty(Move) && _sortedMoves.Any(m => m.GetAttributeValue("name") == Move)) icb_moves.SelectedIndex = _sortedMoves.IndexOf(_sortedMoves.First(m => m.GetAttributeValue("name") == Move));

        }
        private void icb_moves_SelectedIndexChanged(object sender, EventArgs e)
        {

            // Go find the correct move.
            int nDiceCount = 0; // 1d20+1, the "1"
            int nDiceSize = 0;  // 1d20+1, the "20"
            int nRollMod = 0;   // 1d20+1, the "+1" (minus the +)

            var oMove = _sortedMoves[icb_moves.SelectedIndex];
            var sDamage = oMove.GetAttributeValue("Damage");

            // Now that we have the damage as a string, do some parsing
            nDiceCount = int.Parse(sDamage.Split('d')[0]);
            nDiceSize = int.Parse(sDamage.Split('d')[1].Contains('+') ? sDamage.Split('d')[1].Split('+')[0] : sDamage.Split('d')[1]);
            nRollMod = int.Parse(sDamage.Split('d')[1].Contains('+') ? sDamage.Split('d')[1].Split('+')[1] : "0");

            // Place it in the text boxes.
            tb_diceCount.Text = nDiceCount.ToString();
            tb_dieSize.Text = nDiceSize.ToString();
            tb_dieMod.Text = nRollMod.ToString();

        }

        private void btn_roll_Click(object sender, EventArgs e)
        {

            // All three textboxes have valid integers in them.
            // There are very few moves that will not pass (X is mod)
            // Not going to worry about those right now.
            int nDiceCount, nDiceSize, nRollMod, nTotal, nRoll;
            var oRolls = new List<int>();
            string sResult = string.Empty;
            Random oRandom = new Random();

            // Parse the text to an Integer
            int.TryParse(tb_diceCount.Text, out nDiceCount);
            int.TryParse(tb_dieSize.Text, out nDiceSize);
            int.TryParse(tb_dieMod.Text, out nRollMod);

            // Set defaults
            nTotal = 0;
            nRoll = 0;

            // If critical, loop this twice!
            for (int i = 0; i < (cb_critical.Checked ? 2 : 1); i++)
            {

                // Now, do some looping to simulate the dice rolls.
                for (int j = 0; j < nDiceCount; j++)
                {
                    nRoll += oRandom.Next(1, nDiceSize + 1);
                    oRolls.Add(nRoll);
                    nTotal += nRoll;
                }

                // Add the modifiers
                nTotal += nRollMod;

                // Formatting time for the string.
                foreach (var nDieRoll in oRolls) sResult += string.Format("{0}d + ", nDieRoll);

                // Append the roll mod and stat
                sResult += string.Format("{0}m + ", nRollMod);

                // Clear the rolls
                oRolls.Clear();

            }
            nTotal += (int)nud_stat.Value;
            sResult += string.Format("{0}s = {1} ", nud_stat.Value, nTotal);
            tb_result.Text = sResult;
            tb_dieResult.Text = nTotal.ToString();

        }

    }
}
