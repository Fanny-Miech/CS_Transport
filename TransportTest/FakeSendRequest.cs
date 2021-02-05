using TransportLibrary.SendRequest;

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
                return "[{ \"id\": \"SEM:0844\", \"name\": \"Grenoble, Champs-Elysées\", \"lon\": 5.71025,\"lat\": 45.17794,\"zone\": \"SEM_GENCHAMPSEL\", \"lines\":[\"SEM:12\"]},{ \"id\": \"SEM:0846\",\"name\": \"Grenoble, Salengro\",\"lon\": 5.70893,\"lat\": 45.17557,\"zone\": \"SEM_GENSALENGRO\",\"lines\":[\"SEM:12\"]}]";
            }
            if (Url.Contains("lines/"))
            {
                return "[{\"id\": \"SEM:12\",\"gtfsId\": \"SEM:12\",\"shortName\": \"12\",\"longName\": \"Eybens Maisons Neuves / Saint-Martin-d'Hères Les Alloves\",\"color\": \"399645\",\"textColor\": \"FFFFFF\",\"mode\": \"BUS\",\"type\": \"PROXIMO\"}]";
            }
            return "no response";
        }
    }
}
