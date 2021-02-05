using System;
using TransportLibrary.SendRequest;

namespace TransportLibrary.Request
{
    public class LineDescriptionRequest : IRequest
    {
        private string m_lineChoice;

        public ISendRequest SendRequest { get; set; }

        public LineDescriptionRequest(ISendRequest sendRequest, string lineChoice)
        {
            m_lineChoice = lineChoice;
            Url = string.Format("https://data.mobilites-m.fr/api/routers/default/index/routes?codes={0}", lineChoice);
            SendRequest = sendRequest;
        }

        public string Url { get; set; }
        public string SendTheRequest
        {
            get
            {
                SendRequest.Url = Url;
                return SendRequest.DoRequest();
            }
        }

    }
}
