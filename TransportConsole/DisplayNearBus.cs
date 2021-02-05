using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportConsole.Request;
using TransportConsole.SendRequest;

namespace TransportConsole
{
    public class DisplayNearBus
    {
        private ISendRequest SendRequest { get; set; }
        private List<BusNear> ListBus { get; set; }
        public DisplayNearBus(ISendRequest sendRequest, List<BusNear> listBus)
        {
            ListBus = listBus;
            SendRequest = sendRequest;
        }

        public void Display()
        {
            int count = 1;
            ListBus.ForEach(delegate (BusNear bus)
            {
                Console.WriteLine(String.Format("{0}- {1} \n{2}", count, bus.Name, DisplayLines(bus.Lines)));
                count++;
            });
        }

        private string DisplayLines(List<string> lines)
        {
            int count = 1;
            string concatLines = "Lines :";
            lines.ForEach(delegate (string line)
            {
                concatLines = String.Format("{0} \n\t{1} \t{2} \n\t\t{3}", concatLines, count, line, DisplayLineDescription(line));
                count++;
            });
            return concatLines;
        }

        private string DisplayLineDescription(string line)
        {
            BusDescription lineDescription = GetLineDescription(line);
            return String.Format("{0}, \n\t\t{1}", lineDescription.LongName, lineDescription.Mode);
        }

        private BusDescription GetLineDescription(string line)
        {
            LineDescriptionRequest ldr = new LineDescriptionRequest(SendRequest, line);
            string jsonToDeserialize = ldr.SendTheRequest;
            List<BusDescription> myDeserializedBusDescription = JsonConvert.DeserializeObject<List<BusDescription>>(jsonToDeserialize);
            return myDeserializedBusDescription[0];
        }
    }
}
