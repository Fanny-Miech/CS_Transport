using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TransportLibrary.Request;
using TransportLibrary.SendRequest;
using TransportLibrary.Data;

namespace TransportConsole
{
    public class DisplayNearBus
    {
        private ISendRequest SendRequest { get; set; }
        private List<LinesNear> ListBus { get; set; }
        public DisplayNearBus(ISendRequest sendRequest, List<LinesNear> listBus)
        {
            ListBus = listBus;
            SendRequest = sendRequest;
        }

        public void Display()
        {
            int count = 1;
            ListBus.ForEach(delegate (LinesNear bus)
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
            LineDescription lineDescription = GetLineDescription(line);
            return String.Format("{0}, \n\t\t{1}", lineDescription.LongName, lineDescription.Mode);
        }

        private LineDescription GetLineDescription(string line)
        {
            LineDescriptionRequest ldr = new LineDescriptionRequest(SendRequest, line);
            string jsonToDeserialize = ldr.SendTheRequest;
            List<LineDescription> myDeserializedBusDescription = JsonConvert.DeserializeObject<List<LineDescription>>(jsonToDeserialize);
            return myDeserializedBusDescription[0];
        }
    }
}
