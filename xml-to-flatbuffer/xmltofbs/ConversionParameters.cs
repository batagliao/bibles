using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xmltofbs
{
    internal class ConversionParameters
    {
        public string Origin { get; set; }
        public bool IsOriginDir { get; set; }

        public string? Destination { get; set; }
        public bool IsDestinationDir { get; set; }

        public Exception? Error { get; set; }
    }
}
