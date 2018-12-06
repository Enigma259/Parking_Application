using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Server.Model;
using Server.Database;

namespace Server.Control
{
    public class CTR_Reservation
    {
        private static volatile CTR_Reservation _instance;
        private static object syncRoot = new object();

        private Reservation reservation;
        private CTR_Parking ctr_parking;

        /// <summary>
        /// This is the constructor for the class CTR_Reservation.
        /// </summary>
        private CTR_Reservation()
        {
            this.reservation = Reservation.GetInstance();
            this.ctr_parking = new CTR_Parking();
        }

        /// <summary>
        /// This is a multi threaded singleton for the class CTR_Reservation.
        /// </summary>
        /// <returns>_instance</returns>
        public static CTR_Reservation GetInstance()
        {
            if (_instance == null)
            {
                lock (syncRoot)
                {
                    if (_instance == null)
                    {
                        _instance = new CTR_Reservation();
                    }
                }
            }

            return _instance;
        }
    }
}