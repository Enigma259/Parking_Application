using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Device.Location;

namespace Server.Model
{
    public class Location
    {
        private double longtitude;
        private double latitude;
        private double altitude;

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

        public double GetLongtitude()
        {
            return longtitude;
        }

        public double GetLatitude()
        {
            return latitude;
        }

        public void SetLongtitude(double longtitude)
        {
            this.longtitude = longtitude;
        }

        public void SetLatitude(double latitude)
        {
            this.latitude = latitude;
        }

        public string GetLocation()
        {
            string result;
            GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();
            GeoCoordinate coordinates = watcher.Position.Location;

            if(coordinates != null)
            {
                SetLongtitude(coordinates.Longitude);
                SetLatitude(coordinates.Latitude);
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