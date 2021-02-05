using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportConsole.SendRequest;

namespace TransportConsole.Request
{
    public class LinesNearRequest : IRequest
    {
        public string Url { get; set; }

        //params to construct Url
        public double X { get; set; }
        public double Y { get; set; }
        public int Z { get; set; }
        public bool Detail { get; set; }

        public ISendRequest SendRequest { get; set; }

        public string SendTheRequest
        {
            get
            {
                SendRequest.Url = Url;
                return SendRequest.DoRequest();
            }
        }

        //constructor with default values
        public LinesNearRequest(ISendRequest sendRequest, double x = 5.728043, double y = 45.184320, int z = 500)
        {
            X = x;
            Y = y;
            Z = z;
            Detail = true;
            Url = string.Format("https://data.mobilites-m.fr/api/linesNear/json?x={0}&y={1}&dist={2}&details={3}", X, Y, Z, Detail).Replace(",", ".");
            SendRequest = sendRequest;
        }
        //constructor with input values from console (string values)
        public LinesNearRequest(ISendRequest sendRequest, string x, string y, string z)
        {
            X = Convert.ToDouble(x, new CultureInfo("en-US"));
            Y = Convert.ToDouble(y, new CultureInfo("en-US"));
            Z = Convert.ToInt32(z, new CultureInfo("en-US"));

            Detail = true;
            Url = string.Format("https://data.mobilites-m.fr/api/linesNear/json?x={0}&y={1}&dist={2}&details={3}", X, Y, Z, Detail).Replace(",", ".");
            SendRequest = sendRequest;
        }


    }
}
