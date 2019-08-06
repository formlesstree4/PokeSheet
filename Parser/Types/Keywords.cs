using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parser.Types
{
    public class Keywords
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
