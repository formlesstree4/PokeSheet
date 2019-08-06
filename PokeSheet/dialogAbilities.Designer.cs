namespace PokeSheet
{
    partial class DialogAbilities
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
            this.cbAbilities = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbInitialization = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbLimit = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbEffect = new System.Windows.Forms.TextBox();
            this.tbKeyword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ability:";
            // 
            // cbAbilities
            // 
            this.cbAbilities.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAbilities.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbAbilities.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbAbilities.FormattingEnabled = true;
            this.cbAbilities.Location = new System.Drawing.Point(55, 12);
            this.cbAbilities.Name = "cbAbilities";
            this.cbAbilities.Size = new System.Drawing.Size(217, 21);
            this.cbAbilities.TabIndex = 0;
            this.cbAbilities.SelectedIndexChanged += new System.EventHandler(this.CbAbilitiesSelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Activation:";
            // 
            // tbInitialization
            // 
            this.tbInitialization.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbInitialization.Location = new System.Drawing.Point(122, 39);
            this.tbInitialization.Name = "tbInitialization";
            this.tbInitialization.ReadOnly = true;
            this.tbInitialization.Size = new System.Drawing.Size(150, 20);
            this.tbInitialization.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(85, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Limit:";
            // 
            // tbLimit
            // 
            this.tbLimit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLimit.Location = new System.Drawing.Point(122, 65);
            this.tbLimit.Name = "tbLimit";
            this.tbLimit.ReadOnly = true;
            this.tbLimit.Size = new System.Drawing.Size(150, 20);
            this.tbLimit.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(78, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Effect:";
            // 
            // tbEffect
            // 
            this.tbEffect.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbEffect.Location = new System.Drawing.Point(122, 121);
            this.tbEffect.Multiline = true;
            this.tbEffect.Name = "tbEffect";
            this.tbEffect.ReadOnly = true;
            this.tbEffect.Size = new System.Drawing.Size(150, 49);
            this.tbEffect.TabIndex = 3;
            // 
            // tbKeyword
            // 
            this.tbKeyword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbKeyword.Location = new System.Drawing.Point(122, 91);
            this.tbKeyword.Name = "tbKeyword";
            this.tbKeyword.ReadOnly = true;
            this.tbKeyword.Size = new System.Drawing.Size(150, 20);
            this.tbKeyword.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(65, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Keyword:";
            // 
            // DialogAbilities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 182);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbEffect);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbKeyword);
            this.Controls.Add(this.tbLimit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbInitialization);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbAbilities);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(290, 210);
            this.Name = "DialogAbilities";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Abilities";
            this.Load += new System.EventHandler(this.DialogAbilitiesLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbAbilities;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbInitialization;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbLimit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbEffect;
        private System.Windows.Forms.TextBox tbKeyword;
        private System.Windows.Forms.Label label5;
    }
}