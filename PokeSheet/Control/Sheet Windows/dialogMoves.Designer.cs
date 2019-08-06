namespace PokeSheet.Control.Sheet_Windows
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
            System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("Egg Moves", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup6 = new System.Windows.Forms.ListViewGroup("Tutor Moves", System.Windows.Forms.HorizontalAlignment.Left);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbMoves = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lvEggTutor = new System.Windows.Forms.ListView();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbLegalMoves = new System.Windows.Forms.CheckBox();
            this.cbDuplicates = new System.Windows.Forms.CheckBox();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbMoves);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 201);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Move List";
            // 
            // lbMoves
            // 
            this.lbMoves.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbMoves.FormattingEnabled = true;
            this.lbMoves.Location = new System.Drawing.Point(3, 16);
            this.lbMoves.Name = "lbMoves";
            this.lbMoves.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbMoves.Size = new System.Drawing.Size(194, 182);
            this.lbMoves.Sorted = true;
            this.lbMoves.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lvEggTutor);
            this.groupBox2.Location = new System.Drawing.Point(218, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(285, 170);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Egg && Tutor Moves";
            // 
            // lvEggTutor
            // 
            this.lvEggTutor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvEggTutor.FullRowSelect = true;
            listViewGroup5.Header = "Egg Moves";
            listViewGroup5.Name = "lvgEggs";
            listViewGroup6.Header = "Tutor Moves";
            listViewGroup6.Name = "lvgTutor";
            this.lvEggTutor.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup5,
            listViewGroup6});
            this.lvEggTutor.HideSelection = false;
            this.lvEggTutor.Location = new System.Drawing.Point(3, 16);
            this.lvEggTutor.Name = "lvEggTutor";
            this.lvEggTutor.Size = new System.Drawing.Size(279, 151);
            this.lvEggTutor.TabIndex = 0;
            this.lvEggTutor.TileSize = new System.Drawing.Size(168, 15);
            this.lvEggTutor.UseCompatibleStateImageBehavior = false;
            this.lvEggTutor.View = System.Windows.Forms.View.Tile;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(347, 188);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 51);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "&OK";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(428, 188);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 51);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // cbLegalMoves
            // 
            this.cbLegalMoves.AutoSize = true;
            this.cbLegalMoves.Location = new System.Drawing.Point(221, 188);
            this.cbLegalMoves.Name = "cbLegalMoves";
            this.cbLegalMoves.Size = new System.Drawing.Size(111, 17);
            this.cbLegalMoves.TabIndex = 4;
            this.cbLegalMoves.Text = "Legal Moves Only";
            this.cbLegalMoves.UseVisualStyleBackColor = true;
            this.cbLegalMoves.CheckedChanged += new System.EventHandler(this.CbLegalMovesCheckedChanged);
            // 
            // cbDuplicates
            // 
            this.cbDuplicates.AutoSize = true;
            this.cbDuplicates.Location = new System.Drawing.Point(221, 211);
            this.cbDuplicates.Name = "cbDuplicates";
            this.cbDuplicates.Size = new System.Drawing.Size(119, 17);
            this.cbDuplicates.TabIndex = 5;
            this.cbDuplicates.Text = "Remove Duplicates";
            this.cbDuplicates.UseVisualStyleBackColor = true;
            this.cbDuplicates.CheckedChanged += new System.EventHandler(this.CbDuplicatesCheckedChanged);
            // 
            // tbFilter
            // 
            this.tbFilter.Location = new System.Drawing.Point(50, 219);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(165, 20);
            this.tbFilter.TabIndex = 6;
            this.tbFilter.TextChanged += new System.EventHandler(this.TbFilterTextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Filter:";
            // 
            // DialogMoves
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 251);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbFilter);
            this.Controls.Add(this.cbDuplicates);
            this.Controls.Add(this.cbLegalMoves);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogMoves";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Moves";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DialogMovesFormClosing);
            this.Load += new System.EventHandler(this.DialogMovesLoad);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListBox lbMoves;
        private System.Windows.Forms.CheckBox cbLegalMoves;
        private System.Windows.Forms.CheckBox cbDuplicates;
        private System.Windows.Forms.ListView lvEggTutor;
        private System.Windows.Forms.TextBox tbFilter;
        private System.Windows.Forms.Label label1;
    }
}