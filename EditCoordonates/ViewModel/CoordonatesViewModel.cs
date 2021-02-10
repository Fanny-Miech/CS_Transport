using WpfDisplayTransportMessage.Model;
using WpfDisplayTransportMessage.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TransportLibrary.SendRequest;
using System.Windows;
using TransportLibrary.GetData;
using TransportLibrary.Data;
using System.Collections.ObjectModel;

namespace WpfDisplayTransportMessage.ViewModel
{
    public class CoordonatesViewModel : INotifyPropertyChanged
    {
        private Coordonates coordonates;
        public event PropertyChangedEventHandler PropertyChanged;

        //Coordonates Latitude
        public string Latitude
        {
            get
            {
                return coordonates.Latitude;
            }
            set
            {
                if (coordonates.Latitude != value)
                {
                    coordonates.Latitude = value;
                    OnPropertyChanged("Latitude");
                    SetIsValid();
                }
            }
        }

        //Coordonates Longitude
        public string Longitude
        {
            get
            {
                return coordonates.Longitude;
            }
            set
            {
                if (coordonates.Longitude != value)
                {
                    coordonates.Longitude = value;
                    OnPropertyChanged("Longitude");
                    SetIsValid();
                }
            }
        }

        //Coordonates Distance
        public string Distance
        {
            get
            {
                return coordonates.Distance;
            }
            set
            {
                if (coordonates.Distance != value)
                {
                    coordonates.Distance = value;
                    OnPropertyChanged("Distance");
                    SetIsValid();
                }
            }
        }

        /// Indicates whether the model is in a valid state or not.
        public bool IsValid
        {
            get
            {
                return coordonates.IsValid;
            }
            set
            {
                if (coordonates.IsValid != value)
                {
                    coordonates.IsValid = value;
                    OnPropertyChanged();
                }
            }
        }

        /// Sets the value of the IsValid property.
        private void SetIsValid()
        {
            IsValid = !string.IsNullOrEmpty(Latitude) && !string.IsNullOrEmpty(Longitude) && !string.IsNullOrEmpty(Distance);
        }

        /// Raises the PropertyChanged event.
        /// <param name="propertyName">Name of the property.</param>
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        //-------------------------------------------------------------------------------------------

        /// The "apply changes" command
        public ICommand DisplayTransportMessageCommand { get; private set; }
        public ObservableCollection<LinesNear> Lines { get; set; }

        /// constructor
        public CoordonatesViewModel()
        {
            coordonates = new Coordonates
            {
                Latitude = "5.728043",
                Longitude = "45.184320",
                Distance = "500",
                IsValid = true,
                SendRequest = new SendRequestOffLine()
            };

            DisplayTransportMessageCommand = new CoordonatesCommand(
                DisplayTransportMessage);
            Lines = new ObservableCollection<LinesNear>();

        }


        /// Executes the "apply changes" command
        public void DisplayTransportMessage()
        {
            Lines.Clear();
            GetLinesNearDescription getData = new GetLinesNearDescription(coordonates.SendRequest, coordonates.Latitude, coordonates.Longitude, coordonates.Distance);
            LinesNearDescription Data = getData.LinesNearDescription;
            SetLines(Data.LinesNear);
        }

        public void SetLines(List<LinesNear> linesNear)
        {
            linesNear.ForEach(delegate (LinesNear line)
            {
                Lines.Add(line);
            });
        }

    }
}
