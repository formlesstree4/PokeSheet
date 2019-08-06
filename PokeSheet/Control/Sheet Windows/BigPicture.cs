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
    public partial class BigPicture : Form
    {
        public BigPicture()
        {
            InitializeComponent();
        }

        private void BigPictureClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
