using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PokeSheet
{
    public partial class DialogRecent : Form
    {

        public List<TabPage> RecentlyClosed { get; set; }
        public List<TabPage> SelectedTabs { get; set; } 

        public DialogRecent()
        {
            InitializeComponent();
            RecentlyClosed = new List<TabPage>();
            SelectedTabs = new List<TabPage>();
        }

        private void BtnLoadClick(object sender, EventArgs e)
        {
            if(lbTabPages.SelectedItems.Count > 0)
            {
                foreach (var selectedItem in lbTabPages.SelectedItems)
                    SelectedTabs.Add(RecentlyClosed.First(f => f.Text.Equals(selectedItem.ToString())));
            }
        }

        private void DialogRecentLoad(object sender, EventArgs e)
        {
            foreach (var tabPage in RecentlyClosed)
                lbTabPages.Items.Add(tabPage.Text);
        }
    }
}
