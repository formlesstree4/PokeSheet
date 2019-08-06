using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parser.Types
{
    public class Capability
    {

        /// <summary>
        /// The name of the capability.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// This is the capability type; only the Ranger class
        /// needs to know this as that class might draw on specific
        /// aspects of nature when looking for specific talents for their job.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The complete description of the capability.
        /// </summary>
        public string Description { get; set; }

        public override string ToString()
        {
            return Name;
        }

    }
}
