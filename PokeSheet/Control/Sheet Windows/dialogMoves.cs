using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Parser.Types;

namespace PokeSheet.Control.Sheet_Windows
{
    public partial class DialogMoves : Form
    {

        public Pokemon Pokemon;
        public List<string> Learned;
        public List<string> LearnedEggs;
        public List<string> LearnedTutor;
        public int Level { get; set; }

        public List<string> SelectedMoves { get; set; }
        public List<string> SelectedEgg { get; set; }
        public List<string> SelectedTutor { get; set; }

        public DialogMoves()
        {
            InitializeComponent();
            Learned = new List<string>();
            LearnedEggs = new List<string>();
            SelectedMoves = new List<string>();
            SelectedEgg = new List<string>();
            SelectedTutor = new List<string>();
        }

        private void LoadMoves()
        {

            // Get the move list
            var moves = Static.Moves;
            var eggMoves = Static.Moves.Where(m => Pokemon.EggMoves.Contains(m.Name)).ToList();
            var tutorMoves = Static.Moves.Where(m => Pokemon.TutorMoves.Contains(m.Name)).ToList();

            // Do we want legal moves only?
            if(cbLegalMoves.Checked)
            {
                var validMoves = Pokemon.Moves.Where(s => s.Level <= Level).Select(s => s.Name);
                moves = moves.Where(f => validMoves.Contains(f.Name)).ToList();
            }

            // Do we want duplicates?
            if(cbDuplicates.Checked)
            {
                moves = moves.Where(f => !Learned.Contains(f.Name)).ToList();
                eggMoves = eggMoves.Where(m => !LearnedEggs.Contains(m.Name)).ToList();
                tutorMoves = tutorMoves.Where(m => !LearnedTutor.Contains(m.Name)).ToList();
            }

            // CLear the listbox
            lbMoves.Items.Clear();
            lvEggTutor.Items.Clear();

            // Add the string only.
            foreach (var result in moves.Select(s => s.Name))
                lbMoves.Items.Add(result);
            foreach (var eggMove in eggMoves.Select(s => s.Name))
                lvEggTutor.Items.Add(new ListViewItem(eggMove, lvEggTutor.Groups[0]));
            foreach (var tutorMove in tutorMoves.Select(s => s.Name))
                lvEggTutor.Items.Add(new ListViewItem(tutorMove, lvEggTutor.Groups[1]));

        }

        private void DialogMovesLoad(object sender, EventArgs e)
        {
            LoadMoves();
        }

        private void DialogMovesFormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var selectedItem in lbMoves.SelectedItems)
                SelectedMoves.Add(selectedItem.ToString());
            SelectedEgg.AddRange(
                lvEggTutor.SelectedItems.Cast<ListViewItem>().Where(i => i.Group == lvEggTutor.Groups[0]).Select(i => i.Text));
            SelectedTutor.AddRange(
                lvEggTutor.SelectedItems.Cast<ListViewItem>().Where(i => i.Group == lvEggTutor.Groups[1]).Select(i => i.Text));
        }

        private void CbLegalMovesCheckedChanged(object sender, EventArgs e)
        {
            LoadMoves();
        }

        private void CbDuplicatesCheckedChanged(object sender, EventArgs e)
        {
            LoadMoves();
        }

        private void TbFilterTextChanged(object sender, EventArgs e)
        {

            lbMoves.SelectedItems.Clear();
            lbMoves.SelectedItem = lbMoves.Items.Cast<string>().First(s => s.ToLowerInvariant().Contains(tbFilter.Text.ToLowerInvariant()));
            

        }

    }
}
