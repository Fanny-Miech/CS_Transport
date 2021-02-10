using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDisplayCoordonates.Model;

namespace WpfDisplayCoordonates.ViewModel
{
    // INotifyPropertyChanged notifies the View of property changes, so that Bindings are updated.
    sealed class MyViewModel : INotifyPropertyChanged
    {
        private Coordonates coordonates;

        public string Latitude
        {
            get { return coordonates.Latitude; }
            set
            {
                if (coordonates.Latitude != value)
                {
                    coordonates.Latitude = value;
                    OnPropertyChange("Latitude");
                }
            }
        }

        public string Longitude
        {
            get { return coordonates.Longitude; }
            set
            {
                if (coordonates.Longitude != value)
                {
                    coordonates.Longitude = value;
                    OnPropertyChange("Longitude");
                }
            }
        }

        public string Distance
        {
            get { return coordonates.Distance; }
            set
            {
                if (coordonates.Distance != value)
                {
                    coordonates.Distance = value;
                    OnPropertyChange("Distance");
                }
            }
        }

        public MyViewModel()
        {
            coordonates = new Coordonates
            {
                Latitude = "5.1245873",
                Longitude = "45.3658741",
                Distance = "500"
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
