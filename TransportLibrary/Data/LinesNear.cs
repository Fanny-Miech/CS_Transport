using System;
using System.Collections.Generic;

namespace TransportLibrary.Data
{
    public class LinesNear
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Lon { get; set; }
        public double Lat { get; set; }
        public string Zone { get; set; }
        public List<string> Lines { get; set; }
    }
}
