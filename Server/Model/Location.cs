using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Device.Location;

namespace Server.Model
{
    /// <summary>
    /// This is the class Location.
    /// </summary>
    public class Location
    {
        private double longtitude;
        private double latitude;
        private double altitude;

        /// <summary>
        /// This is the constructor for the class Location.
        /// </summary>
        public Location()
        {
            string result = GetLocation();

            if(result != "Done")
            {
                this.longtitude = 0.0;
                this.latitude = 0.0;
                this.altitude = 0.0;
            }
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
        /// This method get the current location.
        /// </summary>
        /// <returns></returns>
        public string GetLocation()
        {
            string result;
            GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();
            GeoCoordinate coordinates = watcher.Position.Location;

            if(coordinates != null)
            {
                SetLongtitude(coordinates.Longitude);
                SetLatitude(coordinates.Latitude);
                SetAltitude(coordinates.Altitude);

                result = "Done";
            }

            else
            {
                result = "Unknown Location";
            }

            return result;
        }
    }
}