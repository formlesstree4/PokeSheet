namespace PokeSheet
{
    partial class FrmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveCurrentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recentlyClosedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMovesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.capabilityListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simpleGeneratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.complexGeneratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parsingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parseMovesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parseAbilitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parsePokemonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parseCapabilitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tcPkmn = new System.Windows.Forms.TabControl();
            this.clearRecentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abilityListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.generatorToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.parsingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(545, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newTabToolStripMenuItem,
            this.closeTabToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveCurrentToolStripMenuItem,
            this.saveAllToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newTabToolStripMenuItem
            // 
            this.newTabToolStripMenuItem.Name = "newTabToolStripMenuItem";
            this.newTabToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newTabToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.newTabToolStripMenuItem.Text = "&New Tab";
            this.newTabToolStripMenuItem.Click += new System.EventHandler(this.NewTabToolStripMenuItemClick);
            // 
            // closeTabToolStripMenuItem
            // 
            this.closeTabToolStripMenuItem.Enabled = false;
            this.closeTabToolStripMenuItem.Name = "closeTabToolStripMenuItem";
            this.closeTabToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.closeTabToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.closeTabToolStripMenuItem.Text = "&Close Tab";
            this.closeTabToolStripMenuItem.Click += new System.EventHandler(this.CloseTabToolStripMenuItemClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(184, 6);
            // 
            // saveCurrentToolStripMenuItem
            // 
            this.saveCurrentToolStripMenuItem.Enabled = false;
            this.saveCurrentToolStripMenuItem.Name = "saveCurrentToolStripMenuItem";
            this.saveCurrentToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveCurrentToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.saveCurrentToolStripMenuItem.Text = "&Save Current";
            this.saveCurrentToolStripMenuItem.Click += new System.EventHandler(this.SaveCurrentToolStripMenuItemClick);
            // 
            // saveAllToolStripMenuItem
            // 
            this.saveAllToolStripMenuItem.Enabled = false;
            this.saveAllToolStripMenuItem.Name = "saveAllToolStripMenuItem";
            this.saveAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAllToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.saveAllToolStripMenuItem.Text = "S&ave All";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fromFileToolStripMenuItem,
            this.recentlyClosedToolStripMenuItem});
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.loadToolStripMenuItem.Text = "&Load";
            // 
            // fromFileToolStripMenuItem
            // 
            this.fromFileToolStripMenuItem.Name = "fromFileToolStripMenuItem";
            this.fromFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.fromFileToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.fromFileToolStripMenuItem.Text = "&From File";
            this.fromFileToolStripMenuItem.Click += new System.EventHandler(this.FromFileToolStripMenuItemClick);
            // 
            // recentlyClosedToolStripMenuItem
            // 
            this.recentlyClosedToolStripMenuItem.Name = "recentlyClosedToolStripMenuItem";
            this.recentlyClosedToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.O)));
            this.recentlyClosedToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.recentlyClosedToolStripMenuItem.Text = "&Recently Closed";
            this.recentlyClosedToolStripMenuItem.Click += new System.EventHandler(this.RecentlyClosedToolStripMenuItemClick);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(184, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abilityListToolStripMenuItem,
            this.capabilityListToolStripMenuItem,
            this.viewMovesToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // viewMovesToolStripMenuItem
            // 
            this.viewMovesToolStripMenuItem.Name = "viewMovesToolStripMenuItem";
            this.viewMovesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.viewMovesToolStripMenuItem.Text = "&Move List";
            this.viewMovesToolStripMenuItem.Click += new System.EventHandler(this.ViewMovesToolStripMenuItemClick);
            // 
            // capabilityListToolStripMenuItem
            // 
            this.capabilityListToolStripMenuItem.Name = "capabilityListToolStripMenuItem";
            this.capabilityListToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.capabilityListToolStripMenuItem.Text = "&Capability List";
            this.capabilityListToolStripMenuItem.Click += new System.EventHandler(this.CapabilityListToolStripMenuItemClick);
            // 
            // generatorToolStripMenuItem
            // 
            this.generatorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.simpleGeneratorToolStripMenuItem,
            this.complexGeneratorToolStripMenuItem});
            this.generatorToolStripMenuItem.Name = "generatorToolStripMenuItem";
            this.generatorToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.generatorToolStripMenuItem.Text = "&Generator";
            // 
            // simpleGeneratorToolStripMenuItem
            // 
            this.simpleGeneratorToolStripMenuItem.Name = "simpleGeneratorToolStripMenuItem";
            this.simpleGeneratorToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.simpleGeneratorToolStripMenuItem.Text = "&Simple Generator";
            this.simpleGeneratorToolStripMenuItem.Click += new System.EventHandler(this.SimpleGeneratorToolStripMenuItemClick);
            // 
            // complexGeneratorToolStripMenuItem
            // 
            this.complexGeneratorToolStripMenuItem.Enabled = false;
            this.complexGeneratorToolStripMenuItem.Name = "complexGeneratorToolStripMenuItem";
            this.complexGeneratorToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.complexGeneratorToolStripMenuItem.Text = "&Complex Generator";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItemClick);
            // 
            // parsingToolStripMenuItem
            // 
            this.parsingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.parseMovesToolStripMenuItem,
            this.parseAbilitiesToolStripMenuItem,
            this.parsePokemonToolStripMenuItem,
            this.parseCapabilitiesToolStripMenuItem});
            this.parsingToolStripMenuItem.Name = "parsingToolStripMenuItem";
            this.parsingToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.parsingToolStripMenuItem.Text = "Parsing...";
            this.parsingToolStripMenuItem.Visible = false;
            // 
            // parseMovesToolStripMenuItem
            // 
            this.parseMovesToolStripMenuItem.Name = "parseMovesToolStripMenuItem";
            this.parseMovesToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.parseMovesToolStripMenuItem.Text = "Parse Moves";
            this.parseMovesToolStripMenuItem.Click += new System.EventHandler(this.ParseMovesToolStripMenuItemClick);
            // 
            // parseAbilitiesToolStripMenuItem
            // 
            this.parseAbilitiesToolStripMenuItem.Name = "parseAbilitiesToolStripMenuItem";
            this.parseAbilitiesToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.parseAbilitiesToolStripMenuItem.Text = "Parse Abilities";
            this.parseAbilitiesToolStripMenuItem.Click += new System.EventHandler(this.ParseAbilitiesToolStripMenuItemClick);
            // 
            // parsePokemonToolStripMenuItem
            // 
            this.parsePokemonToolStripMenuItem.Name = "parsePokemonToolStripMenuItem";
            this.parsePokemonToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.parsePokemonToolStripMenuItem.Text = "Parse Pokemon";
            this.parsePokemonToolStripMenuItem.Click += new System.EventHandler(this.ParsePokemonToolStripMenuItemClick);
            // 
            // parseCapabilitiesToolStripMenuItem
            // 
            this.parseCapabilitiesToolStripMenuItem.Name = "parseCapabilitiesToolStripMenuItem";
            this.parseCapabilitiesToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.parseCapabilitiesToolStripMenuItem.Text = "Parse Capabilities";
            this.parseCapabilitiesToolStripMenuItem.Click += new System.EventHandler(this.ParseCapabilitiesToolStripMenuItemClick);
            // 
            // tcPkmn
            // 
            this.tcPkmn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcPkmn.Location = new System.Drawing.Point(0, 24);
            this.tcPkmn.Name = "tcPkmn";
            this.tcPkmn.SelectedIndex = 0;
            this.tcPkmn.Size = new System.Drawing.Size(545, 657);
            this.tcPkmn.TabIndex = 1;
            // 
            // clearRecentToolStripMenuItem
            // 
            this.clearRecentToolStripMenuItem.Name = "clearRecentToolStripMenuItem";
            this.clearRecentToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.clearRecentToolStripMenuItem.Text = "C&lear Recent...";
            this.clearRecentToolStripMenuItem.Click += new System.EventHandler(this.ClearRecentToolStripMenuItemClick);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearRecentToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // abilityListToolStripMenuItem
            // 
            this.abilityListToolStripMenuItem.Name = "abilityListToolStripMenuItem";
            this.abilityListToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.abilityListToolStripMenuItem.Text = "&Ability List";
            this.abilityListToolStripMenuItem.Click += new System.EventHandler(this.AbilityListToolStripMenuItemClick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 681);
            this.Controls.Add(this.tcPkmn);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pokémon Character Sheet";
            this.Load += new System.EventHandler(this.FrmMainLoad);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newTabToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem saveCurrentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TabControl tcPkmn;
        private System.Windows.Forms.ToolStripMenuItem closeTabToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fromFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recentlyClosedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parsingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parseMovesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parseAbilitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parsePokemonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parseCapabilitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simpleGeneratorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem complexGeneratorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewMovesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem capabilityListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearRecentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abilityListToolStripMenuItem;



    }
}

