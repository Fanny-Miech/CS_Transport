using System;

namespace TransportLibrary.Request
{
    public interface IRequest
    {
        string Url { get; set; }
        string SendTheRequest { get; }
    }
}
