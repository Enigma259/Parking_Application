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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plate_number"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="parking_id"></param>
        /// <returns></returns>
        public string Create(string plate_number, DateTime start, DateTime end, int parking_id)
        {
            string result;
            TableParkingPlace parking = ctr_parking.FindById(parking_id);

            if (parking.id >= 0)
            {
                if(parking.vacant > 0)
                {
                    result = reservation.CreateReservation(plate_number, start, end, parking_id);
                }

                else
                {
                    result = "No more room at the parking place";
                }
            }

            else
            {
                result = "The parking place coesn't exist.";
            }

            result = result + "AND " + ActiveReservations(parking_id);

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<TableReservation> ListAll()
        {
            return reservation.ListAllReservations();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TableReservation FindById(int id)
        {
            return reservation.FindReservationById(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plate_number"></param>
        /// <returns></returns>
        public List<TableReservation> FindByPlateNumber(string plate_number)
        {
            return reservation.FindReservationByPlateNumber(plate_number);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
        public List<TableReservation> FindByStart(DateTime start, string when)
        {
            List<TableReservation> result;

            if(when.Equals("Here"))
            {
                result = reservation.FindReservationByStart(start);
            }

            else if(when.Equals("Later"))
            {
                result = reservation.FindReservationByStartLater(start);
            }

            else if(when.Equals("Earlier"))
            {
                result = reservation.FindReservationByStartEarlier(start);
            }

            else
            {
                result = new List<TableReservation>();
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="end"></param>
        /// <returns></returns>
        public List<TableReservation> FindByEnd(DateTime end, string when)
        {
            List<TableReservation> result;

            if (when.Equals("Here"))
            {
                result = reservation.FindReservationByEnd(end);
            }

            else if (when.Equals("Later"))
            {
                result = reservation.FindReservationByEndLater(end);
            }

            else if (when.Equals("Earlier"))
            {
                result = reservation.FindReservationByEndEarlier(end);
            }

            else
            {
                result = new List<TableReservation>();
            }

            return result;
        }   

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parking_id"></param>
        /// <returns></returns>
        public List<TableReservation> FindByParkingId(int parking_id)
        {
            return reservation.FindReservationByParkingId(parking_id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="plate_number"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="parking_id"></param>
        /// <returns></returns>
        public string Update(int id, string plate_number, DateTime start, DateTime end, int parking_id)
        {
            string result;
            TableParkingPlace parking = ctr_parking.FindById(parking_id);

            if(FindById(id).id >= 1)
            {
                if (parking.id >= 0)
                {
                    if (parking.vacant > 0)
                    {
                        result = reservation.CreateReservation(plate_number, start, end, parking_id);
                    }

                    else
                    {
                        result = "No more room at the parking place";
                    }
                }

                else
                {
                    result = "The parking place coesn't exist.";
                }

                ActiveReservations(parking_id);
            }

            else
            {
                result = "The reservation doesn't exist";
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="what"></param>
        /// <returns></returns>
        public string Delete(int id, string what)
        {
            string result;
            int parking_id = -5;

            if (FindById(id).id >= 1)
            {
                if (what.Equals("Primary"))
                {
                    parking_id = FindById(id).parking_place_id;
                    result = reservation.DeleteReservationById(id);
                }

                else if(what.Equals("Foreign"))
                {
                    parking_id = id;
                    result = reservation.DeleteReservationByParkingId(id);
                }

                else
                {
                    result = "Type of id is not specified";
                }


                result = reservation.DeleteReservationById(id);

                if(what.Equals("Primary") || what.Equals("Foreign"))
                {
                    result = result + "AND " + ActiveReservations(parking_id);
                }
            }

            else
            {
                result = "The reservation doesn't exist";
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parking_id"></param>
        /// <returns></returns>
        public string ActiveReservations(int parking_id)
        {
            string result;
            TableParkingPlace parking;
            int active_reservations;

            active_reservations = reservation.ActiveReservations(parking_id);
            parking = ctr_parking.FindById(parking_id);
            result = ctr_parking.Update(parking.id, parking.longtitude, parking.latitude, parking.altitude, parking.parking_name, parking.spaces, parking.spaces - active_reservations, parking.city, parking.country);

            return result;
        }
    }
}