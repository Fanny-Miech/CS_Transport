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
using Caliburn.Micro;

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
        public LinesNearDescription _data;
        public LinesNearDescription Data { get { return _data; } set { _data = value; OnPropertyChanged("Data"); } }
        public BindableCollection<LinesToDisplay> LinesToDisplay { get; set; }

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
            LinesToDisplay = new BindableCollection<LinesToDisplay>();

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
            Data.Clear();
            LinesToDisplay.Clear();
        }

        // Executes the "Display Transport" command
        public void DisplayTransportMessage()
        {
            //clear the list
            LinesToDisplay.Clear();
            //instanciate sendrequest
            if (IsOnline) { SendRequest = new SendRequestOnLine(); }
            else { SendRequest = new SendRequestOffLine(); };
            // getData
            GetLinesNearDescription getData = new GetLinesNearDescription(SendRequest, coordonates.Latitude, coordonates.Longitude, coordonates.Distance);
            Data = getData.LinesNearDescription;
            SetLinesToDisplay(Data);
        }

        //---------------   Fill ObservableCollections     -------------------------------------------------------------

        // fill LinesToDisplay
        public void SetLinesToDisplay(LinesNearDescription linesNearDescription)
        {
            linesNearDescription.LinesNear.ForEach(delegate (LinesNear linesNear)
            {
                List<Lines> lines = SetLines(linesNearDescription.LinesDescription, linesNear);
                LinesToDisplay linesToDisplay = new LinesToDisplay(linesNear.Name, linesNear.Zone, linesNearDescription.Message, lines);
                LinesToDisplay.Add(linesToDisplay);
            });
        }
        // fill Lines
        public List<Lines> SetLines(List<LineDescription> lineDescription, LinesNear linesNear)
        {
            List<Lines> listLines = new List<Lines>();
            linesNear.Lines.ForEach(delegate (string name)
            {
                lineDescription.ForEach(delegate (LineDescription line)
                {
                    if (name == line.Id)
                    {
                        Lines newLine = new Lines(line.LongName, line.ShortName, line.Color, line.Mode);
                        listLines.Add(newLine);
                    }
                });
            });
            return listLines;
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
