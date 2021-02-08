using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportLibrary.Data
{
    public class LinesNearDescription
    {
        public List<LinesNear> LinesNear { get; set; }

        public List<LineDescription> LinesDescription { get; set; }

        public LinesNearDescription(List<LinesNear> linesNear, List<LineDescription> linesDescription)
        {
            LinesNear = linesNear;
            LinesDescription = linesDescription;
        }
    }
}
