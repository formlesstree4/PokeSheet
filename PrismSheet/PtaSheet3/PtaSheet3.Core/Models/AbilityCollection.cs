using System.Collections.ObjectModel;

namespace PtaSheet3.Core.Models
{

    public sealed class AbilityCollection
    {
        public ObservableCollection<Ability> Abilities { get; set; }

        public override string ToString() => $"Abilities: {Abilities.Count} item(s)";

    }

}
