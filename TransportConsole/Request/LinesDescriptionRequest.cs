using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportConsole.Request
{
    public class LinesDescriptionRequest : IRequest
    {
        public string Url { get; set; }
        public string SendTheRequest { get; }

    }
}
