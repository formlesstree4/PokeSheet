namespace PtaSheet3.Core.Models
{
    public sealed class Ability
    {
        public string Name { get; set; }
        public string Activation { get; set; }
        public string Limit { get; set; }
        public string Keyword { get; set; }
        public string Effect { get; set; }

        public override string ToString() => Name;

    }


}
