﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Console_Server.Model;

namespace Console_Server.Control
{
    /// <summary>
    /// this is the class CTR_Location.
    /// </summary>
    public class CTR_Location
    {
        private static volatile CTR_Location _instance;
        private static readonly object syncRoot = new object();

        private Location location;
        private CTR_ParkingStatistics stats;

        /// <summary>
        /// This is the constructor for the class CTR_Location.
        /// </summary>
        private CTR_Location()
        {
            this.location = new Location();
            this.stats = CTR_ParkingStatistics.GetInstance();
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
        
        /// <summary>
        /// This method gets the longtitude value.
        /// </summary>
        /// <returns>double</returns>
        public double GetLongtitude()
        {
            stats.NewRequest();
            return location.GetLongtitude();
        }

        /// <summary>
        /// This method gets the latitude value.
        /// </summary>
        /// <returns>double</returns>
        public double GetLatitude()
        {
            stats.NewRequest();
            return location.GetLatitude();
        }

        /// <summary>
        /// This method gets the altitude value.
        /// </summary>
        /// <returns>double</returns>
        public double GetAltitude()
        {
            stats.NewRequest();
            return location.GetAltitude();
        }

        /// <summary>
        /// This method changes the location
        /// </summary>
        /// <returns>string</returns>
        public string SetLocation()
        {
            stats.NewRequest();
            return location.SetLocation();  
        }
    }
}