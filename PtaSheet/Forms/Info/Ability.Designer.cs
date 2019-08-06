﻿namespace PtaSheet.Forms.Info
{
    partial class Ability
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
            this.lblName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblActivation = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblLimit = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblKeywords = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbEffect = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(75, 15);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(21, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "{0}";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Activation:";
            // 
            // lblActivation
            // 
            this.lblActivation.AutoSize = true;
            this.lblActivation.Location = new System.Drawing.Point(75, 34);
            this.lblActivation.Name = "lblActivation";
            this.lblActivation.Size = new System.Drawing.Size(21, 13);
            this.lblActivation.TabIndex = 3;
            this.lblActivation.Text = "{0}";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Limit:";
            // 
            // lblLimit
            // 
            this.lblLimit.AutoSize = true;
            this.lblLimit.Location = new System.Drawing.Point(75, 53);
            this.lblLimit.Name = "lblLimit";
            this.lblLimit.Size = new System.Drawing.Size(21, 13);
            this.lblLimit.TabIndex = 5;
            this.lblLimit.Text = "{0}";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Keyword:";
            // 
            // lblKeywords
            // 
            this.lblKeywords.AutoSize = true;
            this.lblKeywords.Location = new System.Drawing.Point(75, 72);
            this.lblKeywords.Name = "lblKeywords";
            this.lblKeywords.Size = new System.Drawing.Size(21, 13);
            this.lblKeywords.TabIndex = 7;
            this.lblKeywords.Text = "{0}";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Effect:";
            // 
            // tbEffect
            // 
            this.tbEffect.Location = new System.Drawing.Point(75, 88);
            this.tbEffect.Multiline = true;
            this.tbEffect.Name = "tbEffect";
            this.tbEffect.ReadOnly = true;
            this.tbEffect.Size = new System.Drawing.Size(314, 65);
            this.tbEffect.TabIndex = 9;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(314, 159);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Ability
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 194);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tbEffect);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblKeywords);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblLimit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblActivation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Ability";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Viewing Ability: {0}";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblActivation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblLimit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblKeywords;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbEffect;
        private System.Windows.Forms.Button btnClose;
    }
}