using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parser.Types
{
    public class Environ
    {
        public string Area { get; set; }
        public string Nature { get; set; }
        public string Secret { get; set; }

        public override string ToString()
        {
            return Area;
        }
    }
}
