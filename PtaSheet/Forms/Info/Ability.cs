using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PtaSheet.Forms.Info
{
    public partial class Ability : Form
    {
        public Ability()
        {
            InitializeComponent();
        }
        public Ability(ManagedXml.Element ability)
        {
            InitializeComponent();

            this.Text = string.Format(this.Text, ability.GetAttributeValue("Name"));

            lblName.Text = string.Format(lblName.Text, ability.GetAttributeValue("Name"));
            lblActivation.Text = string.Format(lblActivation.Text, ability.GetAttributeValue("Activation"));
            lblLimit.Text = string.Format(lblLimit.Text, ability.GetAttributeValue("Limit"));
            lblKeywords.Text = string.Format(lblKeywords.Text, ability.GetAttributeValue("Keyword"));
            tbEffect.Text = ability.GetAttributeValue("Effect");

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
