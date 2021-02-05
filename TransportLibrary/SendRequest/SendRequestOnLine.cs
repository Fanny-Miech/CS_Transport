using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TransportLibrary.SendRequest
{
    public class SendRequestOnLine : ISendRequest
    {
        public string Url { get; set; }

        public SendRequestOnLine(string url = "")
        {
            Url = url;
        }
        public string DoRequest()
        {
            // Create a request for the URL. 		
            WebRequest request = WebRequest.Create(Url);
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
            // Cleanup the streams and the response.
            reader.Close();
            dataStream.Close();
            response.Close();

            return responseFromServer;
        }
    }
}
