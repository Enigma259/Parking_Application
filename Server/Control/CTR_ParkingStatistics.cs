using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Server.Model;

namespace Server.Control
{
    public class CTR_ParkingStatistics
    {
        private static volatile CTR_ParkingStatistics _instance;
        private static object syncRoot = new object();

        private ParkingStatistics p_stats;

        /// <summary>
        /// This is the constructor for the class CTR_ParkingStatistics.
        /// </summary>
        private CTR_ParkingStatistics()
        {
            this.p_stats = ParkingStatistics.GetInstance();
        }

        /// <summary>
        /// This is a multi threaded singleton for the class CTR_ParkingStatistics.
        /// </summary>
        /// <returns>_instance</returns>
        public static CTR_ParkingStatistics GetInstance()
        {
            if (_instance == null)
            {
                lock (syncRoot)
                {
                    if (_instance == null)
                    {
                        _instance = new CTR_ParkingStatistics();
                    }
                }
            }

            return _instance;
        }

        //
        public int GetRequestNumber()
        {
            return p_stats.GetRequestNumber();
        }

        //
        public int GetTimeForAverage()
        {
            return p_stats.GetTimeForAverage();
        }

        //
        public List<DateTime> GetAverages()
        {
            return p_stats.GetAverages();
        }

        //
        public int GetAverage()
        {
            return p_stats.GetAverage();
        }

        //
        public void SetTimeForAverage(int time_for_average)
        {
            p_stats.SetTimeForAverage(time_for_average);
        }

        //
        public void SetAverages(List<DateTime> averages)
        {
            p_stats.SetAverages(averages);
        }

        //
        public void SetAverage()
        {
            p_stats.SetAverage();
        }
        
        //
        public void NewRequest()
        {
            p_stats.NewRequest();
        }
    }
}