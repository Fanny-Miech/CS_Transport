using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportLibrary.Data;
using TransportLibrary.Request;
using TransportLibrary.SendRequest;

namespace TransportLibrary.GetData
{
    public class GetLinesNear
    {
        //params to construct Url
        public double X { get; set; }
        public double Y { get; set; }
        public int Z { get; set; }
        public ISendRequest SendRequest { get; set; }

        public GetLinesNear(ISendRequest sendRequest, double x, double y, int z)
        {
            SendRequest = sendRequest;
            X = x;
            Y = y;
            Z = z;
        }

        public List<LinesNear> LinesNear
        {
            get
            {
                //send Request
                IRequest request = new LinesNearRequest(SendRequest, X, Y, Z);
                //ConvertJson to object
                List<LinesNear> myDeserializedNearLines = JsonConvert.DeserializeObject<List<LinesNear>>(request.SendTheRequest);
                return myDeserializedNearLines;

            }
            set
            {
            }
        }
    }
}
