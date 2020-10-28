using System.Collections.ObjectModel;

namespace PtaSheet3.Core.Models
{
    public sealed class NatureCollection
    {
        public ObservableCollection<Nature> Natures { get; set; }


        public override string ToString() => $"Natures: {Natures.Count} item(s)";

    }

}
