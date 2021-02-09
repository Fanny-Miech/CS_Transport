using EditCoordonates.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EditCoordonates.ViewModel
{
    public class CoordonatesViewModel
    {
        /// The coordonates to edit
        public Coordonates CoordonatesToEdit { get; set; }

        /// The "apply changes" command
        public ICommand ApplyChangesCommand { get; private set; }

        /// constructor
        public CoordonatesViewModel()
        {
            CoordonatesToEdit = new Coordonates
            {
                Latitude = "5.123487",
                Longitude = "45.365479",
                Distance = "500"
            };

            //ApplyChangesCommand = new RelayCommand(
            //    o => ExecuteApplyChangesCommand(),
            //    o => CoordonatesToEdit.IsValid);
        }

        /// Executes the "apply changes" command
        private void ExecuteApplyChangesCommand()
        {

        }

    }
}
