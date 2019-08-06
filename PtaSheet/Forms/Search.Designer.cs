namespace PtaSheet.Forms
{
    partial class Search
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Results", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Search));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbSearchOptions = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lvResults = new System.Windows.Forms.ListView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbParameters = new System.Windows.Forms.TextBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbSearchOptions);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 54);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Options";
            this.groupBox1.UseCompatibleTextRendering = true;
            // 
            // cbSearchOptions
            // 
            this.cbSearchOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSearchOptions.FormattingEnabled = true;
            this.cbSearchOptions.Items.AddRange(new object[] {
            "By Name",
            "By (National) Number",
            "By (PTA) Number",
            "By Type",
            "By Biome",
            "By Egg Group",
            "By Diet",
            "By Capability"});
            this.cbSearchOptions.Location = new System.Drawing.Point(6, 19);
            this.cbSearchOptions.Name = "cbSearchOptions";
            this.cbSearchOptions.Size = new System.Drawing.Size(188, 21);
            this.cbSearchOptions.TabIndex = 2;
            this.cbSearchOptions.SelectedIndexChanged += new System.EventHandler(this.cbSearchOptions_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lvResults);
            this.groupBox2.Location = new System.Drawing.Point(218, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(237, 207);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Results";
            // 
            // lvResults
            // 
            this.lvResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvResults.FullRowSelect = true;
            listViewGroup1.Header = "Results";
            listViewGroup1.Name = "lvgResults";
            this.lvResults.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
            this.lvResults.Location = new System.Drawing.Point(3, 16);
            this.lvResults.MultiSelect = false;
            this.lvResults.Name = "lvResults";
            this.lvResults.Size = new System.Drawing.Size(231, 188);
            this.lvResults.TabIndex = 3;
            this.lvResults.TileSize = new System.Drawing.Size(168, 18);
            this.lvResults.UseCompatibleStateImageBehavior = false;
            this.lvResults.View = System.Windows.Forms.View.Tile;
            this.lvResults.SelectedIndexChanged += new System.EventHandler(this.lvResults_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbParameters);
            this.groupBox3.Location = new System.Drawing.Point(12, 72);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 46);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Search Parameter";
            // 
            // tbParameters
            // 
            this.tbParameters.Location = new System.Drawing.Point(6, 19);
            this.tbParameters.Name = "tbParameters";
            this.tbParameters.Size = new System.Drawing.Size(188, 20);
            this.tbParameters.TabIndex = 1;
            this.tbParameters.TextChanged += new System.EventHandler(this.tbParameters_TextChanged);
            // 
            // btnSelect
            // 
            this.btnSelect.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSelect.Enabled = false;
            this.btnSelect.Location = new System.Drawing.Point(12, 196);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(200, 23);
            this.btnSelect.TabIndex = 4;
            this.btnSelect.Text = "&Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // Search
            // 
            this.AcceptButton = this.btnSelect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 231);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Search";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search";
            this.Load += new System.EventHandler(this.Search_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbSearchOptions;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbParameters;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.ListView lvResults;
    }
}