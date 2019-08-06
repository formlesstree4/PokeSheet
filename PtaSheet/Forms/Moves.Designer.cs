namespace PtaSheet.Forms
{
    partial class Moves
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Moves));
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("By Level", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("By Tutor", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("By Egg", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("By TM", System.Windows.Forms.HorizontalAlignment.Left);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvAllMoves = new System.Windows.Forms.ListView();
            this.ch_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ilTypes = new System.Windows.Forms.ImageList(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lvMoves = new System.Windows.Forms.ListView();
            this.btnOkay = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvAllMoves);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(242, 308);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "All Moves";
            // 
            // lvAllMoves
            // 
            this.lvAllMoves.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_name});
            this.lvAllMoves.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvAllMoves.FullRowSelect = true;
            this.lvAllMoves.Location = new System.Drawing.Point(3, 16);
            this.lvAllMoves.Name = "lvAllMoves";
            this.lvAllMoves.Size = new System.Drawing.Size(236, 289);
            this.lvAllMoves.SmallImageList = this.ilTypes;
            this.lvAllMoves.TabIndex = 0;
            this.lvAllMoves.UseCompatibleStateImageBehavior = false;
            this.lvAllMoves.View = System.Windows.Forms.View.Details;
            // 
            // ch_name
            // 
            this.ch_name.Text = "Name";
            this.ch_name.Width = 230;
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lvMoves);
            this.groupBox2.Location = new System.Drawing.Point(260, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(360, 279);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtered Moves";
            // 
            // lvMoves
            // 
            this.lvMoves.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvMoves.FullRowSelect = true;
            this.lvMoves.GridLines = true;
            listViewGroup1.Header = "By Level";
            listViewGroup1.Name = "lvgLevel";
            listViewGroup2.Header = "By Tutor";
            listViewGroup2.Name = "lvgTutor";
            listViewGroup3.Header = "By Egg";
            listViewGroup3.Name = "lvgEgg";
            listViewGroup4.Header = "By TM";
            listViewGroup4.Name = "lvgTm";
            this.lvMoves.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3,
            listViewGroup4});
            this.lvMoves.LargeImageList = this.ilTypes;
            this.lvMoves.Location = new System.Drawing.Point(3, 16);
            this.lvMoves.Name = "lvMoves";
            this.lvMoves.Size = new System.Drawing.Size(354, 260);
            this.lvMoves.SmallImageList = this.ilTypes;
            this.lvMoves.TabIndex = 0;
            this.lvMoves.TileSize = new System.Drawing.Size(235, 18);
            this.lvMoves.UseCompatibleStateImageBehavior = false;
            this.lvMoves.View = System.Windows.Forms.View.Tile;
            // 
            // btnOkay
            // 
            this.btnOkay.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOkay.Location = new System.Drawing.Point(464, 297);
            this.btnOkay.Name = "btnOkay";
            this.btnOkay.Size = new System.Drawing.Size(75, 23);
            this.btnOkay.TabIndex = 2;
            this.btnOkay.Text = "&OK";
            this.btnOkay.UseVisualStyleBackColor = true;
            this.btnOkay.Click += new System.EventHandler(this.btnOkay_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(545, 297);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "C&ancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // Moves
            // 
            this.AcceptButton = this.btnOkay;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 332);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOkay);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Moves";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Moves";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Moves_FormClosing);
            this.Load += new System.EventHandler(this.Moves_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnOkay;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListView lvMoves;
        private System.Windows.Forms.ImageList ilTypes;
        private System.Windows.Forms.ListView lvAllMoves;
        private System.Windows.Forms.ColumnHeader ch_name;
    }
}