using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PtaSheet.Controls.Form
{
    public class CancelFormClose : System.Windows.Forms.Form
    {



        private bool _clsBtn = false;



        [System.ComponentModel.Description("Determines if the Close Button is enabled or disabled")]
        [System.ComponentModel.DefaultValue(false)]
        [System.ComponentModel.Category("Window Style")]
        [System.ComponentModel.BrowsableAttribute(true)]
        public bool CloseButton
        {
            get { return _clsBtn; }
            set { _clsBtn = value; }
        }

        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                if(_clsBtn)
                    myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        } 

        public CancelFormClose()
        {
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // CancelFormClose
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.DoubleBuffered = true;
            this.Name = "CancelFormClose";
            this.ResumeLayout(false);

        }

    }
}
