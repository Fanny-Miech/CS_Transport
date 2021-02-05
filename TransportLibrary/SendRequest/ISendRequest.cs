using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportLibrary.SendRequest
{
    public interface ISendRequest
    {
        string Url { get; set; }
        string DoRequest();
    }
}
