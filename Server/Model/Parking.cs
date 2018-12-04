using System;
using System.Collections.Generic;
using Server.Database;

namespace Server.Model
{
    public class Parking
    {
        private static volatile Parking _instance;
        private static object syncRoot = new object();
        private SQL_DatabaseDataContext db;


        /// <summary>
        /// This is the constructor for the class Parking.
        /// </summary>
        private Parking()
        {
            this.db = new SQL_DatabaseDataContext();
        }

        /// <summary>
        /// This is a multi threaded singleton for the class Parking.
        /// </summary>
        /// <returns>_instance</returns>
        public static Parking GetInstance()
        {
            if (_instance == null)
            {
                lock (syncRoot)
                {
                    if (_instance == null)
                    {
                        _instance = new Parking();
                    }
                }
            }

            return _instance;
        }

        private void TestData()
        {

        }
}