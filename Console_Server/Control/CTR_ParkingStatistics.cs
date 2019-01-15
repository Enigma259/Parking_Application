using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Console_Server.Model;

namespace Console_Server.Control
{
    /// <summary>
    /// Ths is the class CTR_ParkingStatistics.
    /// </summary>
    public sealed class CTR_ParkingStatistics
    {
        private static volatile CTR_ParkingStatistics _instance;
        private static readonly object syncRoot = new object();

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

        /// <summary>
        /// This method gets the number of requests.
        /// </summary>
        /// <returns>int</returns>
        public int GetRequestNumber()
        {
            return p_stats.GetRequestNumber();
        }

        /// <summary>
        /// This method gets the time for average.
        /// </summary>
        /// <returns>int</returns>
        public double GetTimeForAverage()
        {
            return p_stats.GetTimeForAverage();
        }

        /// <summary>
        /// This method gets a list of averages.
        /// </summary>
        /// <returns>List<DateTime></returns>
        public List<DateTime> GetAverages()
        {
            return p_stats.GetAverages();
        }

        /// <summary>
        /// This method gets the average number.
        /// </summary>
        /// <returns>int</returns>
        public double GetAverage()
        {
            return p_stats.GetAverage();
        }

        /// <summary>
        /// This method updates the instance time_for_average.
        /// </summary>
        /// <param name="time_for_average"></param>
        public void SetTimeForAverage(int time_for_average)
        {
            p_stats.SetTimeForAverage(time_for_average);
        }

        /// <summary>
        /// This method updates the list averages.
        /// </summary>
        /// <param name="averages"></param>
        public void SetAverages(List<DateTime> averages)
        {
            p_stats.SetAverages(averages);
        }

        /// <summary>
        /// This method updates the instance average.
        /// </summary>
        public void SetAverage()
        {
            p_stats.SetAverage();
        }
        
        /// <summary>
        /// This method adds a new request log.
        /// </summary>
        public void NewRequest()
        {
            p_stats.NewRequest();
        }
    }
}