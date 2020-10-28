namespace PtaSheet3.Core.Models
{

    public sealed class Move
    {
        public string Target { get; set; }
        public string Effect { get; set; }
        public Contest Contest { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Frequency { get; set; }
        public string AC { get; set; }
        public string Damage { get; set; }
        public string Class { get; set; }
        public string Range { get; set; }
        public string Special { get; set; }


        public override string ToString() => $"{Name} ({Type} type)";
    }

}
