namespace PtaSheet
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.niMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pokemonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editPokedexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editMoveListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editAbilitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editCapabilitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.damageCalculatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ms_main = new System.Windows.Forms.MenuStrip();
            this.windowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ms_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // niMain
            // 
            this.niMain.Icon = ((System.Drawing.Icon)(resources.GetObject("niMain.Icon")));
            this.niMain.Text = "Pokémon Tabletop Manager";
            this.niMain.Visible = true;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("fileToolStripMenuItem.Image")));
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = global::PtaSheet.Properties.Resources.Actions_document_new_icon;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.newToolStripMenuItem.Text = "&New...";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::PtaSheet.Properties.Resources.Actions_document_open_icon;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // pokemonToolStripMenuItem
            // 
            this.pokemonToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editPokedexToolStripMenuItem,
            this.editMoveListToolStripMenuItem,
            this.editAbilitiesToolStripMenuItem,
            this.editCapabilitiesToolStripMenuItem,
            this.toolStripSeparator1,
            this.damageCalculatorToolStripMenuItem});
            this.pokemonToolStripMenuItem.Image = global::PtaSheet.Properties.Resources.PokeBall_icon;
            this.pokemonToolStripMenuItem.Name = "pokemonToolStripMenuItem";
            this.pokemonToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.pokemonToolStripMenuItem.Text = "&Pokémon";
            // 
            // editPokedexToolStripMenuItem
            // 
            this.editPokedexToolStripMenuItem.Enabled = false;
            this.editPokedexToolStripMenuItem.Name = "editPokedexToolStripMenuItem";
            this.editPokedexToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.editPokedexToolStripMenuItem.Text = "Edit Pokédex";
            // 
            // editMoveListToolStripMenuItem
            // 
            this.editMoveListToolStripMenuItem.Enabled = false;
            this.editMoveListToolStripMenuItem.Name = "editMoveListToolStripMenuItem";
            this.editMoveListToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.editMoveListToolStripMenuItem.Text = "Edit Move List";
            // 
            // editAbilitiesToolStripMenuItem
            // 
            this.editAbilitiesToolStripMenuItem.Enabled = false;
            this.editAbilitiesToolStripMenuItem.Name = "editAbilitiesToolStripMenuItem";
            this.editAbilitiesToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.editAbilitiesToolStripMenuItem.Text = "Edit Abilities";
            // 
            // editCapabilitiesToolStripMenuItem
            // 
            this.editCapabilitiesToolStripMenuItem.Enabled = false;
            this.editCapabilitiesToolStripMenuItem.Name = "editCapabilitiesToolStripMenuItem";
            this.editCapabilitiesToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.editCapabilitiesToolStripMenuItem.Text = "Edit Capabilities";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(172, 6);
            // 
            // damageCalculatorToolStripMenuItem
            // 
            this.damageCalculatorToolStripMenuItem.Name = "damageCalculatorToolStripMenuItem";
            this.damageCalculatorToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.damageCalculatorToolStripMenuItem.Text = "&Damage Calculator";
            this.damageCalculatorToolStripMenuItem.Click += new System.EventHandler(this.damageCalculatorToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripMenuItem.Image")));
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aboutToolStripMenuItem.Image")));
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // ms_main
            // 
            this.ms_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.pokemonToolStripMenuItem,
            this.windowsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.ms_main.Location = new System.Drawing.Point(0, 0);
            this.ms_main.MdiWindowListItem = this.windowsToolStripMenuItem;
            this.ms_main.Name = "ms_main";
            this.ms_main.Size = new System.Drawing.Size(784, 24);
            this.ms_main.TabIndex = 1;
            this.ms_main.Text = "Main Menu Strip";
            // 
            // windowsToolStripMenuItem
            // 
            this.windowsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cascadeToolStripMenuItem,
            this.horizontalToolStripMenuItem,
            this.verticalToolStripMenuItem});
            this.windowsToolStripMenuItem.Image = global::PtaSheet.Properties.Resources.Actions_dashboard_show_icon;
            this.windowsToolStripMenuItem.Name = "windowsToolStripMenuItem";
            this.windowsToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.windowsToolStripMenuItem.Text = "&Windows";
            // 
            // cascadeToolStripMenuItem
            // 
            this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.cascadeToolStripMenuItem.Text = "&Cascade Windows";
            this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.cascadeToolStripMenuItem_Click);
            // 
            // horizontalToolStripMenuItem
            // 
            this.horizontalToolStripMenuItem.Name = "horizontalToolStripMenuItem";
            this.horizontalToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.horizontalToolStripMenuItem.Text = "Tile Horizontally";
            this.horizontalToolStripMenuItem.Click += new System.EventHandler(this.horizontalToolStripMenuItem_Click);
            // 
            // verticalToolStripMenuItem
            // 
            this.verticalToolStripMenuItem.Name = "verticalToolStripMenuItem";
            this.verticalToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.verticalToolStripMenuItem.Text = "Tile Vertically";
            this.verticalToolStripMenuItem.Click += new System.EventHandler(this.verticalToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.ms_main);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.ms_main;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pokémon Tabletop Manager";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ms_main.ResumeLayout(false);
            this.ms_main.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon niMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pokemonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.MenuStrip ms_main;
        private System.Windows.Forms.ToolStripMenuItem windowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem horizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editPokedexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editMoveListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editAbilitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editCapabilitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem damageCalculatorToolStripMenuItem;
    }
}

