using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.Model
{
    public class Commercial
    {
        private static volatile Commercial _instance;
        private static object syncRoot = new object();
        private DateTime last_updated;
        private int update_sequence_seconds;

        /// <summary>
        /// This is the constructor for the class Commercial.
        /// </summary>
        private Commercial()
        {
            this.last_updated = DateTime.Now;
            this.update_sequence_seconds = 120;
        }

        /// <summary>
        /// This is a multi threaded singleton for the class Commercial.
        /// </summary>
        /// <returns>_instance</returns>
        public static Commercial GetInstance()
        {
            if (_instance == null)
            {
                lock (syncRoot)
                {
                    if (_instance == null)
                    {
                        _instance = new Commercial();
                    }
                }
            }

            return _instance;
        }

        public DateTime GetLastUpdated()
        {
            return last_updated;
        }

        public int GetUpdateSequenceSeconds()
        {
            return update_sequence_seconds;
        }

        public void SetLastUpdated()
        {
            this.last_updated = DateTime.Now;
        }

        public void SetUpdateSequenceSeconds(int update_sequence_seconds)
        {
            this.update_sequence_seconds = update_sequence_seconds;
        }

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