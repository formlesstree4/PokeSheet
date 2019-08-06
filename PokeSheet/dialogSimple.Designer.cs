namespace PokeSheet
{
    partial class DialogSimple
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
            this.cbSpecies = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nudLowerLevel = new System.Windows.Forms.NumericUpDown();
            this.nudUpperLevel = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.cboxRandomNature = new System.Windows.Forms.CheckBox();
            this.cboxRandomGender = new System.Windows.Forms.CheckBox();
            this.cboxRandomEv = new System.Windows.Forms.CheckBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudLowerLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUpperLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Pokémon:";
            // 
            // cbSpecies
            // 
            this.cbSpecies.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbSpecies.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbSpecies.FormattingEnabled = true;
            this.cbSpecies.Location = new System.Drawing.Point(106, 12);
            this.cbSpecies.Name = "cbSpecies";
            this.cbSpecies.Size = new System.Drawing.Size(120, 21);
            this.cbSpecies.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Minimum Level:";
            // 
            // nudLowerLevel
            // 
            this.nudLowerLevel.Location = new System.Drawing.Point(106, 39);
            this.nudLowerLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLowerLevel.Name = "nudLowerLevel";
            this.nudLowerLevel.Size = new System.Drawing.Size(120, 20);
            this.nudLowerLevel.TabIndex = 1;
            this.nudLowerLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLowerLevel.ValueChanged += new System.EventHandler(this.NudLowerLevelValueChanged);
            // 
            // nudUpperLevel
            // 
            this.nudUpperLevel.Location = new System.Drawing.Point(106, 65);
            this.nudUpperLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudUpperLevel.Name = "nudUpperLevel";
            this.nudUpperLevel.Size = new System.Drawing.Size(120, 20);
            this.nudUpperLevel.TabIndex = 2;
            this.nudUpperLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Maximum Level:";
            // 
            // cboxRandomNature
            // 
            this.cboxRandomNature.AutoSize = true;
            this.cboxRandomNature.Location = new System.Drawing.Point(106, 91);
            this.cboxRandomNature.Name = "cboxRandomNature";
            this.cboxRandomNature.Size = new System.Drawing.Size(114, 17);
            this.cboxRandomNature.TabIndex = 3;
            this.cboxRandomNature.Text = "Randomize Nature";
            this.cboxRandomNature.UseVisualStyleBackColor = true;
            // 
            // cboxRandomGender
            // 
            this.cboxRandomGender.AutoSize = true;
            this.cboxRandomGender.Location = new System.Drawing.Point(106, 114);
            this.cboxRandomGender.Name = "cboxRandomGender";
            this.cboxRandomGender.Size = new System.Drawing.Size(117, 17);
            this.cboxRandomGender.TabIndex = 4;
            this.cboxRandomGender.Text = "Randomize Gender";
            this.cboxRandomGender.UseVisualStyleBackColor = true;
            // 
            // cboxRandomEv
            // 
            this.cboxRandomEv.AutoSize = true;
            this.cboxRandomEv.Location = new System.Drawing.Point(106, 137);
            this.cboxRandomEv.Name = "cboxRandomEv";
            this.cboxRandomEv.Size = new System.Drawing.Size(103, 17);
            this.cboxRandomEv.TabIndex = 5;
            this.cboxRandomEv.Text = "Randomize EV\'s";
            this.cboxRandomEv.UseVisualStyleBackColor = true;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(52, 160);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(85, 23);
            this.btnGenerate.TabIndex = 6;
            this.btnGenerate.Text = "G&enerate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.BtnGenerateClick);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(143, 160);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(85, 23);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "Re&set";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.BtnResetClick);
            // 
            // DialogSimple
            // 
            this.AcceptButton = this.btnGenerate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 195);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.cboxRandomEv);
            this.Controls.Add(this.cboxRandomGender);
            this.Controls.Add(this.cboxRandomNature);
            this.Controls.Add(this.nudUpperLevel);
            this.Controls.Add(this.nudLowerLevel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbSpecies);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogSimple";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simple Pokémon Generator";
            this.Load += new System.EventHandler(this.DialogSimpleLoad);
            ((System.ComponentModel.ISupportInitialize)(this.nudLowerLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUpperLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbSpecies;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudLowerLevel;
        private System.Windows.Forms.NumericUpDown nudUpperLevel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cboxRandomNature;
        private System.Windows.Forms.CheckBox cboxRandomGender;
        private System.Windows.Forms.CheckBox cboxRandomEv;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnReset;
    }
}