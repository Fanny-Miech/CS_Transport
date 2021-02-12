using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDisplayTransportMessage.Model
{
    public class Lines
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public string Color { get; set; }
        public string Mode { get; set; }

        public Lines(string name, string number, string color, string mode)
        {
            Name = name;
            Number = number;
            Color = color;
            Mode = mode;
        }
    }
}
