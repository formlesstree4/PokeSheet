namespace WpfSheet.Models
{
    public sealed class Nature
    {
        public string Name { get; set; }
        public string IncreaseStat { get; set; }
        public string IncreaseBy { get; set; }
        public string DecreaseStat { get; set; }
        public string DecreaseBy { get; set; }
        public string Likes { get; set; }
        public string Dislikes { get; set; }


        public override string ToString() => $"{Name} [+{IncreaseStat} / -{DecreaseStat}]";
    }


}
