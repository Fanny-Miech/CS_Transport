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
        private readonly Coordonates coordonates;
        public event PropertyChangedEventHandler PropertyChanged;

        // The commands
        public ICommand DisplayTransportMessageCommand { get; private set; }
        public ICommand RefreshCommand { get; private set; }

        // Data to display (get from library)
        public ObservableCollection<LinesNear> LinesNear { get; set; }
        public ObservableCollection<LineDescription> LinesDescription { get; set; }
        public ObservableCollection<string> Lines { get; set; }
        public LinesNearDescription _data;
        public LinesNearDescription Data { get { return _data; } set { _data = value; OnPropertyChanged("Data"); } }
        public ISendRequest SendRequest { get; set; }

        //---------------   Constructor     ---------------------------------------------------------

        public CoordonatesViewModel()
        {
            //instanciate coordonates
            coordonates = new Coordonates
            {
                Latitude = "5.728043",
                Longitude = "45.184320",
                Distance = "500",
                IsValid = true,
            };

            //instanciate ICommand
            DisplayTransportMessageCommand = new CoordonatesCommand(
                DisplayTransportMessage);
            RefreshCommand = new RefreshCommand(RefreshData);

            //instanciate ObservableCollection
            LinesNear = new ObservableCollection<LinesNear>();
            LinesDescription = new ObservableCollection<LineDescription>();
            Lines = new ObservableCollection<string>();

        }

        //------------------------------------------------------------------------------------------
        //--------------    Commands    -------------------------------------------------------------
        //-------------------------------------------------------------------------------------------


        // Execute the "RefreshData" command
        public void RefreshData()
        {
            Latitude = "5.728043";
            Longitude = "45.184320";
            Distance = "500";
            LinesNear.Clear();
            LinesDescription.Clear();
            Lines.Clear();
            Data.Clear();
        }

        // Executes the "Display Transport" command
        public void DisplayTransportMessage()
        {
            //clear the list
            LinesDescription.Clear();
            Lines.Clear();
            LinesNear.Clear();
            //instanciate sendrequest
            if (IsOnline) { SendRequest = new SendRequestOnLine(); }
            else { SendRequest = new SendRequestOffLine(); };
            // getData
            GetLinesNearDescription getData = new GetLinesNearDescription(SendRequest, coordonates.Latitude, coordonates.Longitude, coordonates.Distance);
            Data = getData.LinesNearDescription;
            // set ObservableCollection
            SetLinesNear(Data.LinesNear);
            SetLinesDescription(Data.LinesDescription);
        }

        //---------------   Fill ObservableCollections     -------------------------------------------------------------

        // fill the observableCollection LinesNear and Lines
        public void SetLinesNear(List<LinesNear> linesNear)
        {
            linesNear.ForEach(delegate (LinesNear lineNear)
            {
                LinesNear.Add(lineNear);
                lineNear.Lines.ForEach(delegate (string line)
                {
                    Lines.Add(line);
                });
            });
        }
        // fill the observableCollection LinesDescription
        public void SetLinesDescription(List<LineDescription> linesDescription)
        {
            linesDescription.ForEach(delegate (LineDescription lineDescription)
            {
                LinesDescription.Add(lineDescription);
            });
        }

        //-----------------------------------------------------------------------------------------------------------
        //----------------------    Form parameters     -------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------


        // IsOnline
        public bool _isOnline;
        public bool IsOnline
        {
            get { return _isOnline; }
            set
            {
                if (_isOnline != value)
                {
                    _isOnline = value;
                    OnPropertyChanged("IsOnline");
                }
            }
        }

        // Coordonates Latitude
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

        // Coordonates Longitude
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

        // Coordonates Distance
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

        // Indicates whether the model is in a valid state or not.
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

        // Sets the value of the IsValid property.
        private void SetIsValid()
        {
            IsValid = !string.IsNullOrEmpty(Latitude) && !string.IsNullOrEmpty(Longitude) && !string.IsNullOrEmpty(Distance);
        }

        // Raises the PropertyChanged event.
        // <param name="propertyName">Name of the property.</param>
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
