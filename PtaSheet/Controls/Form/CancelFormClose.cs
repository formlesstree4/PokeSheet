using System.Windows.Forms;

namespace PtaSheet.Controls.Form
{
    public class CancelFormClose : System.Windows.Forms.Form
    {
        [System.ComponentModel.Description("Determines if the Close Button is enabled or disabled")]
        [System.ComponentModel.DefaultValue(false)]
        [System.ComponentModel.Category("Window Style")]
        [System.ComponentModel.Browsable(true)]
        public bool CloseButton { get; set; } = false;

        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                if(CloseButton) myCp.ClassStyle |= CP_NOCLOSE_BUTTON;
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
