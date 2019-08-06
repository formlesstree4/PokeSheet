using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parser.Types
{
    public class Berry
    {
        public string Name { get; set; }
        public string Damage { get; set; }
        public string Type { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
