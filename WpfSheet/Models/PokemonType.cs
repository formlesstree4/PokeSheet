using System;
using System.Linq;

namespace WpfSheet.Models
{
    public sealed class PokemonType
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public string[] StrongAgainst { get; set; }
        public string[] WeakAgainst { get; set; }
        public string[] ImmuneAgainst { get; set; }


        public override string ToString() => Name;



        public bool DoesDoubleDamageTo(PokemonType t) => StrongAgainst.Contains(t.Name, StringComparer.OrdinalIgnoreCase);

        public bool DoesHalfDamageTo(PokemonType t) => WeakAgainst.Contains(t.Name, StringComparer.OrdinalIgnoreCase);

        public bool DoesNoDamageTo(PokemonType t) => ImmuneAgainst.Contains(t.Name, StringComparer.OrdinalIgnoreCase);

    }

}
