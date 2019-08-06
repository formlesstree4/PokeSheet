namespace PtaSheet.Forms
{
    partial class DamageCalculator
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DamageCalculator));
            this.label1 = new System.Windows.Forms.Label();
            this.ilTypes = new System.Windows.Forms.ImageList(this.components);
            this.cb_critical = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_diceCount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_dieSize = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nud_stat = new System.Windows.Forms.NumericUpDown();
            this.btn_roll = new System.Windows.Forms.Button();
            this.tb_result = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_dieMod = new System.Windows.Forms.TextBox();
            this.icb_moves = new ComboxExtended.ImagedComboBox();
            this.tb_dieResult = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nud_stat)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Move:";
            // 
            // ilTypes
            // 
            this.ilTypes.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTypes.ImageStream")));
            this.ilTypes.TransparentColor = System.Drawing.Color.Transparent;
            this.ilTypes.Images.SetKeyName(0, "BugIC.gif");
            this.ilTypes.Images.SetKeyName(1, "DarkIC.gif");
            this.ilTypes.Images.SetKeyName(2, "DragonIC.gif");
            this.ilTypes.Images.SetKeyName(3, "ElectricIC.gif");
            this.ilTypes.Images.SetKeyName(4, "FightingIC.gif");
            this.ilTypes.Images.SetKeyName(5, "FireIC.gif");
            this.ilTypes.Images.SetKeyName(6, "FlyingIC.gif");
            this.ilTypes.Images.SetKeyName(7, "GhostIC.gif");
            this.ilTypes.Images.SetKeyName(8, "GrassIC.gif");
            this.ilTypes.Images.SetKeyName(9, "GroundIC.gif");
            this.ilTypes.Images.SetKeyName(10, "IceIC.gif");
            this.ilTypes.Images.SetKeyName(11, "NormalIC.gif");
            this.ilTypes.Images.SetKeyName(12, "PoisonIC.gif");
            this.ilTypes.Images.SetKeyName(13, "PsychicIC.gif");
            this.ilTypes.Images.SetKeyName(14, "RockIC.gif");
            this.ilTypes.Images.SetKeyName(15, "SteelIC.gif");
            this.ilTypes.Images.SetKeyName(16, "WaterIC.gif");
            this.ilTypes.Images.SetKeyName(17, "UnknownIC.png");
            // 
            // cb_critical
            // 
            this.cb_critical.AutoSize = true;
            this.cb_critical.Location = new System.Drawing.Point(218, 14);
            this.cb_critical.Name = "cb_critical";
            this.cb_critical.Size = new System.Drawing.Size(73, 17);
            this.cb_critical.TabIndex = 0;
            this.cb_critical.Text = "Critical Hit";
            this.cb_critical.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Dice Count:";
            // 
            // tb_diceCount
            // 
            this.tb_diceCount.Location = new System.Drawing.Point(87, 39);
            this.tb_diceCount.Name = "tb_diceCount";
            this.tb_diceCount.ReadOnly = true;
            this.tb_diceCount.Size = new System.Drawing.Size(35, 20);
            this.tb_diceCount.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(128, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Die Size:";
            // 
            // tb_dieSize
            // 
            this.tb_dieSize.Location = new System.Drawing.Point(183, 39);
            this.tb_dieSize.Name = "tb_dieSize";
            this.tb_dieSize.ReadOnly = true;
            this.tb_dieSize.Size = new System.Drawing.Size(35, 20);
            this.tb_dieSize.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Stat Modifier:";
            // 
            // nud_stat
            // 
            this.nud_stat.Location = new System.Drawing.Point(87, 65);
            this.nud_stat.Name = "nud_stat";
            this.nud_stat.Size = new System.Drawing.Size(67, 20);
            this.nud_stat.TabIndex = 8;
            // 
            // btn_roll
            // 
            this.btn_roll.Location = new System.Drawing.Point(160, 65);
            this.btn_roll.Name = "btn_roll";
            this.btn_roll.Size = new System.Drawing.Size(131, 23);
            this.btn_roll.TabIndex = 9;
            this.btn_roll.Text = "Roll";
            this.btn_roll.UseVisualStyleBackColor = true;
            this.btn_roll.Click += new System.EventHandler(this.btn_roll_Click);
            // 
            // tb_result
            // 
            this.tb_result.Location = new System.Drawing.Point(87, 94);
            this.tb_result.Name = "tb_result";
            this.tb_result.ReadOnly = true;
            this.tb_result.Size = new System.Drawing.Size(168, 20);
            this.tb_result.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Results:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(224, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Mod:";
            // 
            // tb_dieMod
            // 
            this.tb_dieMod.Location = new System.Drawing.Point(261, 39);
            this.tb_dieMod.Name = "tb_dieMod";
            this.tb_dieMod.ReadOnly = true;
            this.tb_dieMod.Size = new System.Drawing.Size(30, 20);
            this.tb_dieMod.TabIndex = 13;
            // 
            // icb_moves
            // 
            this.icb_moves.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.icb_moves.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.icb_moves.FormattingEnabled = true;
            this.icb_moves.Location = new System.Drawing.Point(87, 12);
            this.icb_moves.MaxDropDownItems = 14;
            this.icb_moves.Name = "icb_moves";
            this.icb_moves.Size = new System.Drawing.Size(125, 21);
            this.icb_moves.TabIndex = 1;
            this.icb_moves.SelectedIndexChanged += new System.EventHandler(this.icb_moves_SelectedIndexChanged);
            // 
            // tb_dieResult
            // 
            this.tb_dieResult.Location = new System.Drawing.Point(261, 94);
            this.tb_dieResult.Name = "tb_dieResult";
            this.tb_dieResult.ReadOnly = true;
            this.tb_dieResult.Size = new System.Drawing.Size(30, 20);
            this.tb_dieResult.TabIndex = 14;
            // 
            // DamageCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 125);
            this.Controls.Add(this.tb_dieResult);
            this.Controls.Add(this.tb_dieMod);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_result);
            this.Controls.Add(this.btn_roll);
            this.Controls.Add(this.nud_stat);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cb_critical);
            this.Controls.Add(this.tb_dieSize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_diceCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.icb_moves);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DamageCalculator";
            this.Text = "Damage Calculation";
            this.Load += new System.EventHandler(this.DamageCalculator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nud_stat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ComboxExtended.ImagedComboBox icb_moves;
        private System.Windows.Forms.ImageList ilTypes;
        private System.Windows.Forms.CheckBox cb_critical;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_diceCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_dieSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nud_stat;
        private System.Windows.Forms.Button btn_roll;
        private System.Windows.Forms.TextBox tb_result;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_dieMod;
        private System.Windows.Forms.TextBox tb_dieResult;
    }
}