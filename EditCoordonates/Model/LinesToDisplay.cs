using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportLibrary.Data;

namespace WpfDisplayTransportMessage.Model
{
    public class LinesToDisplay
    {
        public string Name { get; set; }
        public string Zone { get; set; }
        string Message { get; set; }
        public List<Lines> Lines { get; set; }

        public LinesToDisplay(string name, string zone, string message, List<Lines> lines)
        {
            Name = name;
            Zone = zone;
            Lines = lines;
            Message = message;
        }
    }
}
