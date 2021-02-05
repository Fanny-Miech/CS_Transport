using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using TransportLibrary.Request;
using TransportLibrary.SendRequest;
using TransportLibrary.Data;

namespace TransportConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 |
                SecurityProtocolType.Tls11 |
                SecurityProtocolType.Tls;

            //Define choice to make request online
            Console.WriteLine("API OnLine ? y/n");
            string apiChoice = Console.ReadLine();

            ISendRequest sendRequest;

            if (apiChoice == "y")
            {
                sendRequest = new SendRequestOnLine();
            }
            else sendRequest = new SendRequestOffLine();

            //Define params for LinesNear request
            Console.WriteLine("Ajouter des infos personnalisées ? y/n");
            string choice = Console.ReadLine();

            IRequest request;

            if (choice == "y")
            {
                Console.WriteLine("Ajouter un X (5.677519 < X < 5.786009) :");
                string xUser = Console.ReadLine();

                Console.WriteLine("Ajouter un Y (45.147729 < Y < 45.205693) :");
                string yUser = Console.ReadLine();

                Console.WriteLine("Ajouter une distance en mètre :");
                string zUser = Console.ReadLine();

                request = new LinesNearRequest(sendRequest, xUser, yUser, zUser);
            }

            else
            {
                request = new LinesNearRequest(sendRequest);
            }

            List<LinesNear> myDeserializedNearLines = JsonConvert.DeserializeObject<List<LinesNear>>(request.SendTheRequest);
            DisplayNearBus displayBus = new DisplayNearBus(sendRequest, myDeserializedNearLines);
            displayBus.Display();

            Console.ReadLine();
        }
    }
}
