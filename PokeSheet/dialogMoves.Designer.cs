namespace PokeSheet
{
    partial class DialogMoves
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
            this.cbMoves = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.tbType = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFrequency = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbAccuracy = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbRange = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbDamage = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbClass = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbTarget = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbEffect = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbConAppeal = new System.Windows.Forms.TextBox();
            this.tbConEffect = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbConType = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbSpecial = new System.Windows.Forms.TextBox();
            this.llKeyWords = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbMoves
            // 
            this.cbMoves.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbMoves.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbMoves.FormattingEnabled = true;
            this.cbMoves.Location = new System.Drawing.Point(86, 12);
            this.cbMoves.Name = "cbMoves";
            this.cbMoves.Size = new System.Drawing.Size(169, 21);
            this.cbMoves.TabIndex = 0;
            this.cbMoves.SelectedIndexChanged += new System.EventHandler(this.CbMovesSelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Move Name:";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(46, 51);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(34, 13);
            this.lblType.TabIndex = 2;
            this.lblType.Text = "Type:";
            // 
            // tbType
            // 
            this.tbType.Location = new System.Drawing.Point(86, 48);
            this.tbType.Name = "tbType";
            this.tbType.ReadOnly = true;
            this.tbType.Size = new System.Drawing.Size(77, 20);
            this.tbType.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Frequency:";
            // 
            // tbFrequency
            // 
            this.tbFrequency.Location = new System.Drawing.Point(239, 48);
            this.tbFrequency.Name = "tbFrequency";
            this.tbFrequency.ReadOnly = true;
            this.tbFrequency.Size = new System.Drawing.Size(77, 20);
            this.tbFrequency.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(178, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Accuracy:";
            // 
            // tbAccuracy
            // 
            this.tbAccuracy.Location = new System.Drawing.Point(239, 74);
            this.tbAccuracy.Name = "tbAccuracy";
            this.tbAccuracy.ReadOnly = true;
            this.tbAccuracy.Size = new System.Drawing.Size(77, 20);
            this.tbAccuracy.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Range:";
            // 
            // tbRange
            // 
            this.tbRange.Location = new System.Drawing.Point(86, 74);
            this.tbRange.Name = "tbRange";
            this.tbRange.ReadOnly = true;
            this.tbRange.Size = new System.Drawing.Size(77, 20);
            this.tbRange.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Damage:";
            // 
            // tbDamage
            // 
            this.tbDamage.Location = new System.Drawing.Point(86, 100);
            this.tbDamage.Name = "tbDamage";
            this.tbDamage.ReadOnly = true;
            this.tbDamage.Size = new System.Drawing.Size(77, 20);
            this.tbDamage.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(168, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Move Class:";
            // 
            // tbClass
            // 
            this.tbClass.Location = new System.Drawing.Point(239, 100);
            this.tbClass.Name = "tbClass";
            this.tbClass.ReadOnly = true;
            this.tbClass.Size = new System.Drawing.Size(77, 20);
            this.tbClass.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Target(s):";
            // 
            // tbTarget
            // 
            this.tbTarget.Location = new System.Drawing.Point(86, 126);
            this.tbTarget.Name = "tbTarget";
            this.tbTarget.ReadOnly = true;
            this.tbTarget.Size = new System.Drawing.Size(77, 20);
            this.tbTarget.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(42, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Effect:";
            // 
            // tbEffect
            // 
            this.tbEffect.Location = new System.Drawing.Point(86, 152);
            this.tbEffect.Name = "tbEffect";
            this.tbEffect.ReadOnly = true;
            this.tbEffect.Size = new System.Drawing.Size(230, 20);
            this.tbEffect.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbConAppeal);
            this.groupBox1.Controls.Add(this.tbConEffect);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.tbConType);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Location = new System.Drawing.Point(12, 178);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 74);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Contest Information";
            // 
            // tbConAppeal
            // 
            this.tbConAppeal.Location = new System.Drawing.Point(221, 15);
            this.tbConAppeal.Name = "tbConAppeal";
            this.tbConAppeal.ReadOnly = true;
            this.tbConAppeal.Size = new System.Drawing.Size(77, 20);
            this.tbConAppeal.TabIndex = 11;
            // 
            // tbConEffect
            // 
            this.tbConEffect.Location = new System.Drawing.Point(74, 41);
            this.tbConEffect.Name = "tbConEffect";
            this.tbConEffect.ReadOnly = true;
            this.tbConEffect.Size = new System.Drawing.Size(224, 20);
            this.tbConEffect.TabIndex = 12;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(30, 44);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Effect:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(172, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Appeal:";
            // 
            // tbConType
            // 
            this.tbConType.Location = new System.Drawing.Point(74, 15);
            this.tbConType.Name = "tbConType";
            this.tbConType.ReadOnly = true;
            this.tbConType.Size = new System.Drawing.Size(77, 20);
            this.tbConType.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(34, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Type:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(188, 129);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Special:";
            // 
            // tbSpecial
            // 
            this.tbSpecial.Location = new System.Drawing.Point(239, 126);
            this.tbSpecial.Name = "tbSpecial";
            this.tbSpecial.ReadOnly = true;
            this.tbSpecial.Size = new System.Drawing.Size(77, 20);
            this.tbSpecial.TabIndex = 8;
            // 
            // llKeyWords
            // 
            this.llKeyWords.AutoSize = true;
            this.llKeyWords.Location = new System.Drawing.Point(261, 15);
            this.llKeyWords.Name = "llKeyWords";
            this.llKeyWords.Size = new System.Drawing.Size(53, 13);
            this.llKeyWords.TabIndex = 10;
            this.llKeyWords.TabStop = true;
            this.llKeyWords.Text = "Keywords";
            this.llKeyWords.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LlKeyWordsLinkClicked);
            // 
            // DialogMoves
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 262);
            this.Controls.Add(this.llKeyWords);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbEffect);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbSpecial);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbClass);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbAccuracy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbFrequency);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbTarget);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbDamage);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbRange);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbType);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbMoves);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DialogMoves";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Moves";
            this.Load += new System.EventHandler(this.DialogMovesLoad);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbMoves;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.TextBox tbType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbFrequency;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbAccuracy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbRange;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbDamage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbClass;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbTarget;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbEffect;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbSpecial;
        private System.Windows.Forms.TextBox tbConAppeal;
        private System.Windows.Forms.TextBox tbConEffect;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbConType;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.LinkLabel llKeyWords;
    }
}