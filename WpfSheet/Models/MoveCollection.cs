using System.Collections.ObjectModel;

namespace WpfSheet.Models
{
    public sealed class MoveCollection
    {
        public ObservableCollection<Move> Moves { get; set; }

        public override string ToString() => $"Moves: {Moves.Count} item(s)";

    }


}
