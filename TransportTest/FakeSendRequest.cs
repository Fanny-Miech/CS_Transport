using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportConsole;
using TransportConsole.SendRequest;

namespace TransportTest
{
    class FakeSendRequest : ISendRequest
    {
        public string Url { get; set; }

        public FakeSendRequest(string url = "")
        {
            Url = url;
        }
        public string DoRequest()
        {
            if (Url.Contains("linesNear/"))
            {
                return "[{ id: 'SEM:0844', name: 'Grenoble, Champs-Elysées', lon: 5.71025,lat: 45.17794,zone: 'SEM_GENCHAMPSEL', lines:['SEM:12']},{ id: 'SEM:0846',name: 'Grenoble, Salengro',lon: 5.70893,lat: 45.17557,zone: 'SEM_GENSALENGRO',lines:['SEM:12']}]";
            }

            if (Url.Contains("lines/"))
            {
                return "{ type: 'FeatureCollection', features:[ ] }";
            }
            return "no response";
        }
    }
}
