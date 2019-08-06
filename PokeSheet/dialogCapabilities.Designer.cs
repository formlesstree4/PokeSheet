namespace PokeSheet
{
    partial class DialogCapabilities
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cbCapabilities = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCapabilityType = new System.Windows.Forms.TextBox();
            this.tbCapabilityDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Capability:";
            // 
            // cbCapabilities
            // 
            this.cbCapabilities.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCapabilities.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbCapabilities.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbCapabilities.FormattingEnabled = true;
            this.cbCapabilities.Location = new System.Drawing.Point(81, 12);
            this.cbCapabilities.Name = "cbCapabilities";
            this.cbCapabilities.Size = new System.Drawing.Size(191, 21);
            this.cbCapabilities.TabIndex = 0;
            this.cbCapabilities.SelectedIndexChanged += new System.EventHandler(this.CbCapabilitiesSelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Type:";
            // 
            // tbCapabilityType
            // 
            this.tbCapabilityType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCapabilityType.Location = new System.Drawing.Point(81, 39);
            this.tbCapabilityType.Name = "tbCapabilityType";
            this.tbCapabilityType.ReadOnly = true;
            this.tbCapabilityType.Size = new System.Drawing.Size(191, 20);
            this.tbCapabilityType.TabIndex = 1;
            // 
            // tbCapabilityDescription
            // 
            this.tbCapabilityDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCapabilityDescription.Location = new System.Drawing.Point(81, 65);
            this.tbCapabilityDescription.Multiline = true;
            this.tbCapabilityDescription.Name = "tbCapabilityDescription";
            this.tbCapabilityDescription.ReadOnly = true;
            this.tbCapabilityDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbCapabilityDescription.Size = new System.Drawing.Size(191, 105);
            this.tbCapabilityDescription.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Description:";
            // 
            // DialogCapabilities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 182);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbCapabilityDescription);
            this.Controls.Add(this.tbCapabilityType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbCapabilities);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 220);
            this.Name = "DialogCapabilities";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Capabilities";
            this.Load += new System.EventHandler(this.DialogCapabilitiesLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbCapabilities;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCapabilityType;
        private System.Windows.Forms.TextBox tbCapabilityDescription;
        private System.Windows.Forms.Label label3;
    }
}