using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_User.Model
{
    public sealed class Location
    {
        private static volatile Location _instance;
        private static object syncRoot = new object();
        private double longtitude;
        private double latitude;
        private double altitude;
        private bool location_success;

        /// <summary>
        /// This is the constructor for the class Location.
        /// </summary>
        private Location()
        {
            SetLocation();
        }

        /// <summary>
        /// This is a multi threaded singleton for the class Location.
        /// </summary>
        /// <returns>_instance</returns>
        public static Location GetInstance()
        {
            if (_instance == null)
            {
                lock (syncRoot)
                {
                    if (_instance == null)
                    {
                        _instance = new Location();
                    }
                }
            }

            return _instance;
        }

        /// <summary>
        /// This method returns the value of the instance longtitude.
        /// </summary>
        /// <returns>longtitude</returns>
        public double GetLongtitude()
        {
            return longtitude;
        }

        /// <summary>
        /// This method returns the value of the instance latitude.
        /// </summary>
        /// <returns>latitude</returns>
        public double GetLatitude()
        {
            return latitude;
        }

        /// <summary>
        /// This method returns the value of the instance altitude.
        /// </summary>
        /// <returns>altitude</returns>
        public double GetAltitude()
        {
            return altitude;
        }

        /// <summary>
        /// This method returns the value of the instance location_success.
        /// </summary>
        /// <returns>location_success</returns>
        public bool GetLocationSuccess()
        {
            return location_success;
        }

        /// <summary>
        /// This method changes the value of the instance longtitude.
        /// </summary>
        /// <param name="longtitude"></param>
        public void SetLongtitude(double longtitude)
        {
            this.longtitude = longtitude;
        }

        /// <summary>
        /// This method changes the value of the instance latitude.
        /// </summary>
        /// <param name="latitude"></param>
        public void SetLatitude(double latitude)
        {
            this.latitude = latitude;
        }

        /// <summary>
        /// This method changes the value of the instance altitude.
        /// </summary>
        /// <param name="altitude"></param>
        public void SetAltitude(double altitude)
        {
            this.altitude = altitude;
        }

        /// <summary>
        /// This method changes the value of the instance location_success.
        /// </summary>
        /// <param name="location_success"></param>
        public void SetLocationSuccess(bool location_success)
        {
            this.location_success = location_success;
        }

        /// <summary>
        /// This method get the current location.
        /// </summary>
        /// <returns></returns>
        public void SetLocation()
        {
            GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();
            GeoCoordinate coordinates = watcher.Position.Location;

            if (coordinates != null)
            {
                SetLongtitude(coordinates.Longitude);
                SetLatitude(coordinates.Latitude);
                SetAltitude(coordinates.Altitude);
                SetLocationSuccess(true);
            }

            else
            {
                SetLongtitude(0.0);
                SetLatitude(0.0);
                SetAltitude(0.0);
                SetLocationSuccess(false);
            }
        }
    }
}
