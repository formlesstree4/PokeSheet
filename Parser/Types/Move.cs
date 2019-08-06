
namespace Parser.Types
{
    public class Move
    {

        public Move()
        {
            Name = string.Empty;
            Type = string.Empty;
            Frequency = string.Empty;
            Accuracy = string.Empty;
            Range = string.Empty;
            Damage = string.Empty;
            Class = string.Empty;
            Targets = string.Empty;
            Effect = string.Empty;
            ContestType = string.Empty;
            Appeal = string.Empty;
            ContestEffect = string.Empty;
            Special = string.Empty;
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public string Frequency { get; set; }
        public string Accuracy { get; set; }
        public string Range { get; set; }
        public string Damage { get; set; }
        public string Class { get; set; }
        public string Targets { get; set; }
        public string Effect { get; set; }
        public string ContestType { get; set; }
        public string Appeal { get; set; }
        public string ContestEffect { get; set; }
        public string Special { get; set; }

        public override string ToString()
        {
            return Name;
        }

    }
}
