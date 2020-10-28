using System.Collections.ObjectModel;

namespace PtaSheet3.Core.Models
{
    public sealed class MoveCollection
    {
        public ObservableCollection<Move> Moves { get; set; }

        public override string ToString() => $"Moves: {Moves.Count} item(s)";

    }


}
