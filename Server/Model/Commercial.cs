using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Server.Model
{
    /// <summary>
    /// This is the class Commercial.
    /// </summary>
    public sealed class Commercial
    {
        private static volatile Commercial _instance;
        private static object syncRoot = new object();
        private DateTime last_updated;
        private int update_sequence_seconds;

        /// <summary>
        /// This is the constructor for the class Commercial.
        /// </summary>
        /// <param name="update_sequence_seconds"></param>
        private Commercial(int update_sequence_seconds)
        {
            this.last_updated = DateTime.Now;
            this.update_sequence_seconds = update_sequence_seconds;
        }

        /// <summary>
        /// This is a multi threaded singleton for the class Commercial.
        /// </summary>
        /// <param name="update_sequence_seconds"></param>
        /// <returns>_instance</returns>
        public static Commercial GetInstance(int update_sequence_seconds)
        {
            if (_instance == null)
            {
                lock (syncRoot)
                {
                    if (_instance == null)
                    {
                        _instance = new Commercial(update_sequence_seconds);
                    }
                }
            }

            return _instance;
        }

        /// <summary>
        /// This method returns the value of the instance last_updated.
        /// </summary>
        /// <returns>last_updated</returns>
        public DateTime GetLastUpdated()
        {
            return last_updated;
        }

        /// <summary>
        /// This method returns the value of the instance update_sequence_seconds.
        /// </summary>
        /// <returns>update_sequence_seconds</returns>
        public int GetUpdateSequenceSeconds()
        {
            return update_sequence_seconds;
        }

        /// <summary>
        /// This method changes the value of the instance last_updated.
        /// </summary>
        public void SetLastUpdated()
        {
            this.last_updated = DateTime.Now;
        }

        /// <summary>
        /// This method changes the value of the instance update_sequence_seconds.
        /// </summary>
        /// <param name="update_sequence_seconds"></param>
        public void SetUpdateSequenceSeconds(int update_sequence_seconds)
        {
            this.update_sequence_seconds = update_sequence_seconds;
        }

        /// <summary>
        /// This method checks if it is time to update the commercial.
        /// </summary>
        /// <returns>result</returns>
        public bool TimeToUpdate()
        {
            DateTime current_time;
            bool result;

            current_time = DateTime.Now;

            if(GetLastUpdated().AddSeconds(GetUpdateSequenceSeconds()) > current_time)
            {
                result = true;
            }

            else
            {
                result = false;
            }

            return result;
        }
    }
}