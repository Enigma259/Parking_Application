using Server.Database;
using System;
using System.Collections.Generic;

namespace Server.Model
{
    public sealed class Reservation
    {
        private static volatile Reservation _instance;
        private static object syncRoot = new object();
        private SQL_DatabaseDataContext db;


        /// <summary>
        /// This is the constructor for the class Reservation.
        /// </summary>
        private Reservation()
        {
            this.db = new SQL_DatabaseDataContext();
        }

        /// <summary>
        /// This is a multi threaded singleton for the class Reservation.
        /// </summary>
        /// <returns>_instance</returns>
        public static Reservation GetInstance()
        {
            if (_instance == null)
            {
                lock (syncRoot)
                {
                    if (_instance == null)
                    {
                        _instance = new Reservation();
                    }
                }
            }

            return _instance;
        }


    }
}