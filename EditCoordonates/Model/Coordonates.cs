using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TransportLibrary.SendRequest;

namespace WpfDisplayTransportMessage.Model
{
    public class Coordonates
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Distance { get; set; }
        public bool IsValid { get; set; }
    }


}
