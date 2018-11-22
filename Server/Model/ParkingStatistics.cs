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
        //parking service request number.
        private int psr_number;

        //average amount of parking service request.
        private double psr_average;

        //list of parking service request numbers
        private List<int> psr_numbers;

        //last update of psr_average.
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
        /// This method returns the values in the list last_update.
        /// </summary>
        /// <returns>last_update</returns>
        public DateTime GetLastUpdate()
        {
            return last_update;
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

        public void SetLastUpdate()
        {
            this.last_update = DateTime.Now;
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

        /// <summary>
        /// This method increases the psr_number and if there has gone a minute or more it will update the psr_average.
        /// </summary>
        public void PSRNumberIncrease()
        {
            DateTime now = DateTime.Now;
            int seconds = 60;
            
            if(now.Year == GetLastUpdate().Year)
            {
                if (now.Month == GetLastUpdate().Month)
                {
                    if (now.Day == GetLastUpdate().Day)
                    {
                        if (now.Hour == GetLastUpdate().Hour)
                        {
                            if (now.Minute > GetLastUpdate().Minute)
                            {
                                SetPSRAverage(seconds);
                            }

                            //if the minutes now isn't higher than the last update minute.
                            else
                            {
                                SetPSRNumber(false);
                            }
                        }

                        //if the two instances hour aren't equal.
                        else
                        {
                            if(now.Hour - GetLastUpdate().Hour == 1)
                            {
                                if (now.Minute > GetLastUpdate().Minute)
                                {
                                    SetPSRAverage(seconds);
                                }

                                //if the minutes now isn't higher than the last update minute.
                                else
                                {
                                    SetPSRNumber(false);
                                }
                            }

                            else
                            {
                                SetPSRNumber(false);
                            }
                        }
                    }

                    //if the two instances days aren't equal.
                    else
                    {
                        if (now.Day - GetLastUpdate().Day == 1)
                        {
                            if (now.Hour - GetLastUpdate().Hour == 1)
                            {
                                if (now.Minute > GetLastUpdate().Minute)
                                {
                                    SetPSRAverage(seconds);
                                }

                                //if the minutes now isn't higher than the last update minute.
                                else
                                {
                                    SetPSRNumber(false);
                                }
                            }

                            else
                            {
                                SetPSRNumber(false);
                            }
                        }

                        else
                        {
                            SetPSRNumber(false);
                        }
                    }
                }

                //if the two instances months aren't equal.
                else
                {
                    if (now.Month - GetLastUpdate().Month == 1)
                    {
                        if (now.Day - GetLastUpdate().Day == 1)
                        {
                            if (now.Hour - GetLastUpdate().Hour == 1)
                            {
                                if (now.Minute > GetLastUpdate().Minute)
                                {
                                    SetPSRAverage(seconds);
                                }

                                //if the minutes now isn't higher than the last update minute.
                                else
                                {
                                    SetPSRNumber(false);
                                }
                            }

                            else
                            {
                                SetPSRNumber(false);
                            }
                        }

                        else
                        {
                            SetPSRNumber(false);
                        }
                    }

                    else
                    {
                        SetPSRNumber(false);
                    }
                }
            }

            //if the two instances years aren't equal.
            else
            {
                if (now.Year - GetLastUpdate().Year == 1)
                {
                    if (now.Month - GetLastUpdate().Month == 1)
                    {
                        if (now.Day - GetLastUpdate().Day == 1)
                        {
                            if (now.Hour - GetLastUpdate().Hour == 1)
                            {
                                if (now.Minute > GetLastUpdate().Minute)
                                {
                                    SetPSRAverage(seconds);
                                }

                                //if the minutes now isn't higher than the last update minute.
                                else
                                {
                                    SetPSRNumber(false);
                                }
                            }

                            else
                            {
                                SetPSRNumber(false);
                            }
                        }

                        else
                        {
                            SetPSRNumber(false);
                        }
                    }

                    else
                    {
                        SetPSRNumber(false);
                    }
                }

                else
                {
                    SetPSRNumber(false);
                }
            }

            SetLastUpdate();
        }

        /// <summary>
        /// This method calculates the total psr_number and return the result.
        /// </summary>
        /// <returns></returns>
        public int GetTotalPSRNumber()
        {
            int result = 0;
            List<int> psrs = GetPSRNumbers();

            foreach(int number in psrs)
            {
                result += number;
            }

            return result;
        }
    }
}