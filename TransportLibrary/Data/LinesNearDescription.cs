using System;
using System.Collections.Generic;
using System.Linq;

namespace TransportLibrary.Data
{
    public class LinesNearDescription
    {
        public string Message { get; set; }
        public List<LinesNear> LinesNear { get; set; }
        public List<LineDescription> LinesDescription { get; set; }

        public LinesNearDescription(List<LinesNear> linesNear, List<LineDescription> linesDescription)
        {
            LinesNear = linesNear;
            LinesDescription = linesDescription;
            if (!linesNear.Any())
            {
                Message = "Il n'y a pas de transport correspondant à votre demande.";
            }
            else Message = "Liste des transports correspondants à votre demande :";
        }

        public void Clear()
        {
            Message.Remove(0);
            LinesNear.Clear();
            LinesDescription.Clear();
        }
    }
}
