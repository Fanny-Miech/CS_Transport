using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportLibrary.Data
{
    // BusDescription myDeserializedBusDescription = JsonConvert.DeserializeObject<BusDescription>(myJsonResponse); 
    public class LineDescription
    {
        public string Id { get; set; }
        public string GtfsId { get; set; }
        public string ShortName { get; set; }
        public string LongName { get; set; }
        public string Color { get; set; }
        public string TextColor { get; set; }
        public string Mode { get; set; }
        public string Type { get; set; }
    }
}
