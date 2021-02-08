using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportLibrary.Data;
using TransportLibrary.SendRequest;

namespace TransportLibrary.GetData
{
    public class GetLinesNearDescription
    {

        //params to construct LinesNear Url
        public double X { get; set; }
        public double Y { get; set; }
        public int Z { get; set; }
        public ISendRequest SendRequest { get; set; }

        //constructor with default values
        public GetLinesNearDescription(ISendRequest sendRequest, double x = 5.728043, double y = 45.184320, int z = 500)
        {
            X = x;
            Y = y;
            Z = z;
            SendRequest = sendRequest;
        }
        //constructor with input values from console (string values)
        public GetLinesNearDescription(ISendRequest sendRequest, string x, string y, string z)
        {
            X = Convert.ToDouble(x, new CultureInfo("en-US"));
            Y = Convert.ToDouble(y, new CultureInfo("en-US"));
            Z = Convert.ToInt32(z, new CultureInfo("en-US"));
            SendRequest = sendRequest;
        }


        public LinesNearDescription LinesNearDescription
        {
            get
            {
                //Get LinesNear object
                GetLinesNear getLinesNear = new GetLinesNear(SendRequest, X, Y, Z);
                List<LinesNear> linesNear = getLinesNear.LinesNear;
                //Get List<LineDescription>
                //get list of names
                string list = GetListOfName(linesNear);

                //send Request and transform Json to data
                GetLineDescription getLineDescription = new GetLineDescription(SendRequest, list);
                List<LineDescription> listLineDescription = getLineDescription.LinesDescription;

                return new LinesNearDescription(linesNear, listLineDescription);
            }
            set
            {
            }
        }

        private string GetListOfName(List<LinesNear> linesNear)
        {
            List<string> listLinesName = new List<string>();

            linesNear.ForEach(delegate (LinesNear busStop)
            {
                busStop.Lines.ForEach(delegate (string line)
                {
                    if (!listLinesName.Any(x => x.Equals(line)))
                    {
                        listLinesName.Add(line);
                    }
                });

            });

            return GetStringFromList(listLinesName);
        }

        private string GetStringFromList(List<string> stringList)
        {
            string list = "";
            stringList.ForEach(delegate (string name)
            {
                list += name + ",";
            });
            return list.Remove(list.Length - 1);
        }
    }

}

