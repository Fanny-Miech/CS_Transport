using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TransportConsole
{
    public class Request
    {
        public double X { get; set; }
        public double Y { get; set; }
        public int Z { get; set; }
        public bool Detail { get; set; }

        public Request()
            : this(5.728043, 45.184320)
        {
        }

        public Request(double x, double y, int z = 500, bool detail = true)
        {
            X = x;
            Y = y;
            Z = z;
            Detail = detail;
        }

        private string ConstructUrl()
        {
            string convertX = ConvertToString(X);
            string convertY = ConvertToString(Y);
            return string.Format("https://data.mobilites-m.fr/api/linesNear/json?x={0}&y={1}&dist={2}&details={3}", convertX, convertY, Z, Detail);
        }

        //This method converts double to String while keeping the '.' in place of ','
        private string ConvertToString(double any)
        {
            string anyString = any.ToString();
            return anyString.Replace(',', '.');
        }

        public void GetRequest()
        {
            string url = ConstructUrl();
            // Create a request for the URL. 		
            WebRequest request = WebRequest.Create(url);
            // Get the response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            // Display the status.
            Console.WriteLine(response.StatusDescription);
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            Console.WriteLine(responseFromServer);
            // Cleanup the streams and the response.
            reader.Close();
            dataStream.Close();
            response.Close();
        }
    }
}
