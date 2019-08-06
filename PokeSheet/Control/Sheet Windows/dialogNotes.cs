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
    public partial class DialogNotes : Form
    {

        public string Notes { get; set; }

        public DialogNotes()
        {
            InitializeComponent();
        }

        private void DialogNotesLoad(object sender, EventArgs e)
        {
            rtbNotes.Text = Notes;
        }

        private void DialogNotesFormClosing(object sender, FormClosingEventArgs e)
        {
            Notes = rtbNotes.Text;
        }
    }
}
