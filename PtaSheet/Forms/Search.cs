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
    public partial class Search : Form
    {

        public ManagedXml.Element Pokemon { get; set; }
        public ManagedXml.Element Result { get; set; }

        public Search()
        {
            InitializeComponent();
        }

        private void Search_Load(object sender, EventArgs e)
        {
            cbSearchOptions.SelectedIndex = 0;
            (tbParameters as Control).Select();
            tbParameters.Focus();
        }

        private void tbParameters_TextChanged(object sender, EventArgs e)
        {
            /*
             * 
             * By Name
             * By (National) Number
             * By (PTA) Number
             * By Type
             * By Biome
             * By Egg Group
             * By Diet
             * By Capability
             * 
             * */
            lvResults.Items.Clear();
            if (tbParameters.Text.Trim().Length == 0) return;
            var resultList = new List<ManagedXml.Element>();

            switch (cbSearchOptions.SelectedIndex)
            {
                case 0: // Name
                    foreach (var item in Pokemon.Children)
                    {
                        var name = item.GetAttributeValue("Name");
                        if (name.ToLower().Contains(tbParameters.Text.ToLower()))
                            resultList.Add(item);
                    }
                    break;

                case 1: // National Number
                    foreach (var item in Pokemon.Children)
                    {
                        var pokedex = item.GetElement("Pokedex");
                        if (pokedex.GetAttributeValue("National") == tbParameters.Text)
                            resultList.Add(item);
                    }
                    break;

                case 2: // PTA Number
                    foreach (var item in Pokemon.Children)
                    {
                        var pokedex = item.GetElement("Pokedex");
                        if(pokedex != null)
                            if (pokedex.GetAttributeValue("PTA") == tbParameters.Text)
                                resultList.Add(item);
                    }
                    break;

                case 3: // Type
                    foreach (var item in Pokemon.Children)
                    {
                        var types = item.GetElement("Types");
                        if(types != null)
                            if (types.GetAttributeValue("First").ToLower() == tbParameters.Text.ToLower() ||
                                types.GetAttributeValue("Second").ToLower() == tbParameters.Text.ToLower())
                                resultList.Add(item);
                    }
                    break;

                case 4: // Biome
                    
                    foreach (var item in Pokemon.Children)
                    {
                        var habitats = item.GetElement("Habitats");
                        if (habitats != null)
                            foreach (var child in habitats.Children)
                                if (child.Value.ToLower() == tbParameters.Text.ToLower())
                                    resultList.Add(item);
                    }
                    
                    break;
                case 5: // Egg Group
                    foreach (var item in Pokemon.Children)
                    {
                        var eggs = item.GetElement("Eggs");
                        if (eggs != null)
                        {
                            var groups = eggs.GetElement("Groups");
                            if (groups != null)
                                foreach (var child in groups.Children)
                                    if (child.Value.ToLower() == tbParameters.Text.ToLower())
                                        resultList.Add(item);
                        }
                    }
                    break;

                case 6: // Diet
                    foreach (var item in Pokemon.Children)
                    {
                        var diet = item.GetElement("Eggs");
                        if (diet != null)
                        {
                            foreach (var child in diet.Children)
                                if (child.Value.ToLower() == tbParameters.Text.ToLower())
                                    resultList.Add(item);
                        }
                    }
                    break;

                case 7: // Capability
                    foreach (var item in Pokemon.Children)
                    {
                        var capabilities = item.GetElement("Capabilities");
                        if (capabilities != null)
                            foreach (var child in capabilities.Children)
                                if (child.Value.ToLower() == tbParameters.Text.ToLower())
                                    resultList.Add(child);
                    }
                    break;

            }

            // Loop and add
            foreach (var item in resultList)
            {
                var lvi = new ListViewItem { Text = item.GetAttributeValue("Name"), Tag = item, Group = lvResults.Groups[0] };
                lvResults.Items.Add(lvi);
            }

            // Now check
            if (lvResults.Items.Count == 1)
            {
                lvResults.Items[0].Selected = true;
                lvResults.Select();
            }

        }

        private void cbSearchOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbParameters.Clear();
            tbParameters.Focus();
        }

        private void lvResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSelect.Enabled = lvResults.SelectedItems.Count == 1;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            Result = lvResults.SelectedItems[0].Tag as ManagedXml.Element;
        }
    }
}
