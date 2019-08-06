using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PokeSheet.Control.Sheet_Windows
{
    public partial class DialogHeld : Form
    {

        public string HeldItem { get; set; }

        public DialogHeld()
        {
            InitializeComponent();
        }

        private void DialogHeldLoad(object sender, EventArgs e)
        {

        }
    }
}
