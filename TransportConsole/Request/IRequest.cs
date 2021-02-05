using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportConsole.Request
{
    public interface IRequest
    {
        string Url { get; set; }
        string SendTheRequest { get; }
    }
}
