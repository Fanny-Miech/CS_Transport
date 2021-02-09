using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfAppCoordonates.ViewModels.Commands;

namespace WpfAppCoordonates.ViewModels
{

    public class CoordonatesViewModel
    {
        public CoordonatesCommands DisplayCoordonatesCommand { get; private set; }
        public CoordonatesViewModel()
        {
            DisplayCoordonatesCommand = new CoordonatesCommands(DisplayCoordonates);
        }

        public void DisplayCoordonates(List<string> coordonates)
        {
            MessageBox.Show(String.Format("{0}, {1}", coordonates[0], coordonates[1]));
        }

    }
}
