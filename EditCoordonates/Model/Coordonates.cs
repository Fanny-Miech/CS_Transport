using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EditCoordonates.Model
{
    public class Coordonates : INotifyPropertyChanged
    {
        private string _latitude;
        private string _longitude;
        private string _distance;
        private bool _isValid;
        public event PropertyChangedEventHandler PropertyChanged;

        //Coordonates Latitude
        public string Latitude
        {
            get
            {
                return _latitude;
            }
            set
            {
                if (_latitude != value)
                {
                    _latitude = value;
                    OnPropertyChanged();
                    SetIsValid();
                }
            }
        }

        //Coordonates Longitude
        public string Longitude
        {
            get
            {
                return _longitude;
            }
            set
            {
                if (_longitude != value)
                {
                    _latitude = value;
                    OnPropertyChanged();
                    SetIsValid();
                }
            }
        }

        //Coordonates Distance
        public string Distance
        {
            get
            {
                return _distance;
            }
            set
            {
                if (_distance != value)
                {
                    _distance = value;
                    OnPropertyChanged();
                    SetIsValid();
                }
            }
        }

        /// Indicates whether the model is in a valid state or not.
        public bool IsValid
        {
            get
            {
                return _isValid;
            }
            set
            {
                if (_isValid != value)
                {
                    _isValid = value;
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


    }


}
