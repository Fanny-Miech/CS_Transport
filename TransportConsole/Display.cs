using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportLibrary.Data;

namespace TransportConsole
{
    public class Display
    {
        public LinesNearDescription LinesNearDescription { get; set; }
        public Display(LinesNearDescription linesNearDescription)
        {
            LinesNearDescription = linesNearDescription;
        }

        public void DisplayLines()
        {
            int count = 1;
            //For each stop bus -> display busTop.Name and get details for lines
            LinesNearDescription.LinesNear.ForEach(delegate (LinesNear busStop)
            {
                Console.WriteLine(String.Format("{0}- {1} \n{2}", count, busStop.Name, DisplayLines(busStop.Lines)));
                count++;
            });

        }

        //display details for line
        private string DisplayLines(List<string> lines)
        {
            LineDescription lineDescriptionToDisplay;
            int count = 1;
            string concatLines = "Lines :";
            //for each line name get the associated objet in the list
            lines.ForEach(delegate (string line)
            {
                LinesNearDescription.LinesDescription.ForEach(delegate (LineDescription lineDescription)
                {
                    if (line == lineDescription.Id)
                    {
                        lineDescriptionToDisplay = lineDescription;
                        concatLines = String.Format("{0} \n\t{1} \t{2} \n\t\t{3}", concatLines, count, line, DisplayLineDescription(lineDescriptionToDisplay));
                        count++;
                    }
                });

            });
            return concatLines;
        }

        //display details for line
        private string DisplayLineDescription(LineDescription line)
        {
            return String.Format("{0}, \n\t\t{1}, \n\t\t{2}", line.LongName, line.Mode, line.Color);
        }

    }
}
