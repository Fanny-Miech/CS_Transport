using System;

namespace TransportLibrary.SendRequest
{
    public interface ISendRequest
    {
        string Url { get; set; }
        string DoRequest();
    }
}
