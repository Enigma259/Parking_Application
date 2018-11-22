using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.Model
{
    /// <summary>
    /// This is the class ParkingStatistics.
    /// </summary>
    public class ParkingStatistics
    {
        private int psr_number;
        private double psr_average;
        private List<int> psr_numbers;
        private DateTime last_update;
        private static volatile ParkingStatistics _instance;
        private static object syncRoot = new object();

        /// <summary>
        /// This is the constructor for the class ParkingStatistics.
        /// </summary>
        private ParkingStatistics(int starting_number)
        {
            this.psr_number = starting_number;
            this.psr_average = starting_number;
            this.psr_numbers = new List<int>();
            this.last_update = DateTime.Now;
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
                        _instance = new ParkingStatistics(0);
                    }
                }
            }

            return _instance;
        }

        /// <summary>
        /// This method returns the value of the instance psr_number.
        /// </summary>
        /// <returns>psr_number</returns>
        public int GetPSRNumber()
        {
            return psr_number;
        }

        /// <summary>
        /// This method returns the value of the instance psr_average.
        /// </summary>
        /// <returns>psr_average</returns>
        public double GetPSRAverage()
        {
            return psr_average;
        }

        /// <summary>
        /// This method returns the values in the list psr_numbers.
        /// </summary>
        /// <returns>psr_numbers</returns>
        public List<int> GetPSRNumbers()
        {
            return psr_numbers;
        }

        /// <summary>
        /// This method changes the value of the instance psr_number.
        /// </summary>
        /// <param name="reset"></param>
        public void SetPSRNumber(bool reset)
        {
            if(reset.Equals(true))
            {
                this.psr_number = 0;
            }

            else
            {
                this.psr_number++;
            }
        }

        /// <summary>
        /// This method changes the value of the instance psr_average.
        /// </summary>
        /// <param name="seconds"></param>
        public void SetPSRAverage(int seconds)
        {
            if(GetPSRNumber() > 0)
            {
                this.psr_average = GetPSRNumber() / seconds;
                AddPSRNumberToList(GetPSRNumber(), true);
            }

            else
            {
                this.psr_average = 0;
            }
        }

        /// <summary>
        /// This method either changes the list or adding new values to the list psr_numbers.
        /// </summary>
        /// <param name="list_of_psr_numbers"></param>
        /// <param name="adding"></param>
        public void SetPSRNumbers(List<int> list_of_psr_numbers, bool adding)
        {
            if(adding.Equals(true))
            {
                foreach(int number in list_of_psr_numbers)
                {
                    AddPSRNumberToList(number, false);
                }
            }

            else
            {
                this.psr_numbers = list_of_psr_numbers;
            }
        }

        /// <summary>
        /// This method adds a new value to the list psr_numbers.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="reset_psr_number"></param>
        public void AddPSRNumberToList(int number, bool reset_psr_number)
        {
            GetPSRNumbers().Add(number);

            if(reset_psr_number.Equals(true))
            {
                SetPSRNumber(true);
            }
        }

        public void PSRNumberIncrease()
        {

        }
    }
}