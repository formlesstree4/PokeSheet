using System;
using System.Linq;
using System.Windows.Forms;
using Parser.Types;
using PokeSheet.Properties;

namespace PokeSheet
{
    public partial class DialogCapabilities : Form
    {
        public DialogCapabilities()
        {
            InitializeComponent();
            Icon = Resources.Pokeball16;
        }

        public void SelectCapability(string name)
        {
            if(Static.Capabilities.Exists(c => c.Name.Equals(name)))
                cbCapabilities.SelectedItem = cbCapabilities.Items.Cast<object>().First(item => ((Capability)item).Name.Equals(name.Trim()));
        }
        private void DialogCapabilitiesLoad(object sender, EventArgs e)
        {
            foreach (var capability in Static.Capabilities)
                cbCapabilities.Items.Add(capability);
            cbCapabilities.SelectedIndex = 0;
        }
        private void CbCapabilitiesSelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbCapabilities.SelectedIndex > - 1)
            {
                var capability = (Capability) cbCapabilities.SelectedItem;
                tbCapabilityType.Text = capability.Type;
                tbCapabilityDescription.Text = capability.Description;
            }
            else
            {
                tbCapabilityType.Clear();
                tbCapabilityDescription.Clear();
            }
        }
    }
}
