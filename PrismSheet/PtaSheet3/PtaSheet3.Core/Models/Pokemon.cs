namespace PtaSheet3.Core.Models
{

    public sealed class Pokemon
    {
        public Pokedex Pokedex { get; set; }
        public Types Types { get; set; }
        public Height Height { get; set; }
        public Weight Weight { get; set; }
        public Diets Diets { get; set; }
        public Habitats Habitats { get; set; }
        public Gender Gender { get; set; }
        public BreedingDetails Eggs { get; set; }
        public Stages Stages { get; set; }
        public BaseStats Stats { get; set; }
        public Capabilities Capabilities { get; set; }
        public PokemonAbility Abilities { get; set; }
        public PokemonMoves Moves { get; set; }
        public string Name { get; set; }
        public string JapaneseName { get; set; }
        public string Classification { get; set; }
        public string CaptureRate { get; set; }
        public string Experience { get; set; }


        public override string ToString() => $"{Pokedex.National.ToString().PadRight(3, '0')}: {Name}";

    }

}