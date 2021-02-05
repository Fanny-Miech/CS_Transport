using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportConsole.SendRequest;

namespace TransportConsole.Request
{
    public class LineDescriptionRequest : IRequest
    {
        private string m_lineChoice;

        public ISendRequest SendRequest { get; set; }

        public LineDescriptionRequest(ISendRequest sendRequest, string lineChoice)
        {
            m_lineChoice = lineChoice;
            Url = String.Format("https://data.mobilites-m.fr/api/routers/default/index/routes?codes={0}", lineChoice);
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
