using System;
using System.IO;
using System.Net;

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
