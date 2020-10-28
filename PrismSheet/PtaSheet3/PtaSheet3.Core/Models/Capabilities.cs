namespace PtaSheet3.Core.Models
{
    public sealed class Capabilities
    {
        public string[] Capability { get; set; }
        public int Overland { get; set; }
        public int Surface { get; set; }
        public int Jump { get; set; }
        public int Power { get; set; }
        public int Intelligence { get; set; }
        public int Burrow { get; set; }
        public int Sky { get; set; }
        public int Underwater { get; set; }
    }

}