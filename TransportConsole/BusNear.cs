using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportConsole
{
    public class BusNear
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Lon { get; set; }
        public double Lat { get; set; }
        public string Zone { get; set; }
        public List<string> Lines { get; set; }
    }
}
