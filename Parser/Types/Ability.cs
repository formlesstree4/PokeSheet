namespace Parser.Types
{
    public class Ability
    {
        public string Name { get; set; }
        public string Activation { get; set; }
        public string Limit { get; set; }
        public string Keywords { get; set; }
        public string Effect { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
