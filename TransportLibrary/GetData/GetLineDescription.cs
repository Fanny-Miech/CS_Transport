using Newtonsoft.Json;
using System.Collections.Generic;
using TransportLibrary.Data;
using TransportLibrary.Request;
using TransportLibrary.SendRequest;

namespace TransportLibrary.GetData
{
    public class GetLineDescription
    {
        private string m_listName;
        public ISendRequest SendRequest { get; set; }
        public GetLineDescription(ISendRequest sendRequest, string listLineName)
        {
            SendRequest = sendRequest;
            m_listName = listLineName;
        }

        public List<LineDescription> LinesDescription
        {
            get
            {
                //send Request
                IRequest request = new LineDescriptionRequest(SendRequest, m_listName);
                //ConvertJson to object
                List<LineDescription> myDeserializedLinesDescription = JsonConvert.DeserializeObject<List<LineDescription>>(request.SendTheRequest);
                return myDeserializedLinesDescription;
            }
            set
            {
            }
        }
    }
}
