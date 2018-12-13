using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Server.Model;

namespace Server.Control
{
    /// <summary>
    /// this is the class CTR_Location.
    /// </summary>
    public class CTR_Location
    {
        private static volatile CTR_Location _instance;
        private static object syncRoot = new object();

        private Location location;

        /// <summary>
        /// This is the constructor for the class CTR_Location.
        /// </summary>
        private CTR_Location()
        {
            this.location = new Location();
        }

        /// <summary>
        /// This is a multi threaded singleton for the class CTR_Location.
        /// </summary>
        /// <returns>_instance</returns>
        public static CTR_Location GetInstance()
        {
            if (_instance == null)
            {
                lock (syncRoot)
                {
                    if (_instance == null)
                    {
                        _instance = new CTR_Location();
                    }
                }
            }

            return _instance;
        }


        public double GetLongtitude()
        {
            return location.GetLongtitude();
        }

        public double GetLatitude()
        {
            return location.GetLatitude();
        }

        public double GetAltitude()
        {
            return location.GetAltitude();
        }
        
        public string SetLocation()
        {
            return location.SetLocation();  
        }
    }
}