using System;
using System.Collections.Generic;

namespace Console_Server.Model
{
    /// <summary>
    /// This is the class ParkingStatistics.
    /// </summary>
    public sealed class ParkingStatistics
    {
        private static volatile ParkingStatistics _instance;
        private static readonly object syncRoot = new object();

        private int request_number;

        //time for average is in seconds.
        private int time_for_average;
        private List<DateTime> averages;
        private int average;

        /// <summary>
        /// This is the constructor for the class ParkingStatistics.
        /// </summary>
        private ParkingStatistics()
        {
            this.request_number = 0;
            this.time_for_average = 60;
            this.averages = new List<DateTime>();
            this.average = 0;
        }

        /// <summary>
        /// This is a multi threaded singleton for the class ParkingStatistics.
        /// </summary>
        /// <returns>_instance</returns>
        public static ParkingStatistics GetInstance()
        {
            if (_instance == null)
            {
                lock (syncRoot)
                {
                    if (_instance == null)
                    {
                        _instance = new ParkingStatistics();
                    }
                }
            }

            return _instance;
        }

        /// <summary>
        /// This method returns tha value in the instance request_number.
        /// </summary>
        /// <returns>int</returns>
        public int GetRequestNumber()
        {
            return request_number;
        }

        /// <summary>
        /// This method returns tha value in the instance time_for_average.
        /// </summary>
        /// <returns>int</returns>
        public int GetTimeForAverage()
        {
            return time_for_average;
        }

        /// <summary>
        /// This method returns tha list averages.
        /// </summary>
        /// <returns>List<DateTime></returns>
        public List<DateTime> GetAverages()
        {
            return averages;
        }

        /// <summary>
        /// This method returns tha value in the instance average.
        /// </summary>
        /// <returns>int</returns>
        public int GetAverage()
        {
            return average;
        }

        /// <summary>
        /// This method changes tha value in the instance request_number.
        /// </summary>
        /// <param name="reset"></param>
        public void SetRequestNumber(bool reset)
        {
            if (reset || GetRequestNumber().Equals(int.MaxValue))
            {
                this.request_number = 0;
            }

            else
            {
                request_number++;
            }
        }

        /// <summary>
        /// This method changes tha value in the instance time_for_average.
        /// </summary>
        /// <param name="time_for_average"></param>
        public void SetTimeForAverage(int time_for_average)
        {
            this.time_for_average = time_for_average;
        }

        /// <summary>
        /// This method changes tha value in the instance averages.
        /// </summary>
        /// <param name="averages"></param>
        public void SetAverages(List<DateTime> averages)
        {
            this.averages = averages;
        }

        /// <summary>
        /// This method changes tha value in the instance average.
        /// </summary>
        public void SetAverage()
        {
            CheckAverages();
            this.average = GetAverages().Count;
        }

        /// <summary>
        /// This method removes the outdated values from the list averages.
        /// </summary>
        private void CheckAverages()
        {
            int index = 0;
            DateTime current;
            DateTime outdate_limit = DateTime.Now.Subtract(InsertSecondsToTimeSpan(GetTimeForAverage()));

            while (index < GetAverages().Count)
            {
                current = GetAverages()[index];

                if(current < outdate_limit)
                {
                    GetAverages().Remove(current);
                }

                else
                {
                    index++;
                }
            }
        }

        /// <summary>
        /// This method adds a new time stamp for a request.
        /// </summary>
        public void NewRequest()
        {
            SetRequestNumber(false);
            GetAverages().Add(DateTime.Now);
            SetAverage();
        }

        /// <summary>
        /// This method creates a time span and put an integer into the position where seconds are.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>TimeSpan</returns>
        private TimeSpan InsertSecondsToTimeSpan(int value)
        {
            TimeSpan result;

            result = new TimeSpan(0, 0, value);

            return result;
        }
    }
}