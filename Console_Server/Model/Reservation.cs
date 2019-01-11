using Console_Server.Database;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Console_Server.Model
{
    /// <summary>
    /// This is the class Reservation.
    /// </summary>
    public sealed class Reservation
    {
        private static volatile Reservation _instance;
        private static readonly object syncRoot = new object();
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

        /// <summary>
        /// This method creates a reservation in the database.
        /// </summary>
        /// <param name="plate_number"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="parking_id"></param>
        /// <returns>string</returns>
        public string CreateReservation(string plate_number, DateTime start, DateTime end, int parking_id)
        {
            string result;

            TableReservation reservation = new TableReservation();

            reservation.plate_number = plate_number;
            reservation.time_from = start;

            if (end < start)
            {
                reservation.time_to = start;
            }

            else
            {
                reservation.time_to = end;
            }

            reservation.parking_place_id = parking_id;


            try
            {
                db.TableReservations.InsertOnSubmit(reservation);
                db.SubmitChanges();

                result = "Success";
            }

            catch (Exception exception)
            {
                result = "ERROR: " + exception.Message;
            }

            return result;
        }

        /// <summary>
        /// This method list all the reservations in the database.
        /// </summary>
        /// <returns>List<TableReservation></returns>
        public List<TableReservation> ListAllReservations()
        {
            List<TableReservation> reservations;

            try
            {
                var list = from pp in db.TableReservations select pp;
                reservations = list.ToList<TableReservation>();
            }

            catch (Exception exception)
            {
                reservations = new List<TableReservation>();
                Console.WriteLine(exception.Message);
            }

            return reservations;
        }

        /// <summary>
        /// This method finds a reservation in the database by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>TableReservation</returns>
        public TableReservation FindReservationById(int id)
        {
            TableReservation reservation;

            try
            {
                reservation = db.TableReservations.First(pp => pp.id == id);
            }

            catch (Exception exception)
            {
                reservation = new TableReservation();
                Console.WriteLine(exception.Message);
            }

            return reservation;
        }

        /// <summary>
        /// This method finds a reservation in the database by its plate_number.
        /// </summary>
        /// <param name="plate_number"></param>
        /// <returns>List<TableReservation></returns>
        public List<TableReservation> FindReservationByPlateNumber(string plate_number)
        {
            List<TableReservation> reservations;

            try
            {
                var list = from pp in db.TableReservations where pp.plate_number.Contains(plate_number) select pp;
                reservations = list.ToList();
            }

            catch (Exception exception)
            {
                reservations = new List<TableReservation>();
                Console.WriteLine(exception.Message);
            }

            return reservations;
        }

        /// <summary>
        /// This method finds a reservation in the database by its start.
        /// </summary>
        /// <param name="start"></param>
        /// <returns>List<TableReservation></returns>
        public List<TableReservation> FindReservationByStart(DateTime start)
        {
            List<TableReservation> reservations;

            try
            {
                var list = from pp in db.TableReservations where pp.time_from == start select pp;
                reservations = list.ToList();
            }

            catch (Exception exception)
            {
                reservations = new List<TableReservation>();
                Console.WriteLine(exception.Message);
            }

            return reservations;
        }

        /// <summary>
        /// This method finds a reservation in the database that is later than the start.
        /// </summary>
        /// <param name="start"></param>
        /// <returns>List<TableReservation></returns>
        public List<TableReservation> FindReservationByStartLater(DateTime start)
        {
            List<TableReservation> reservations;

            try
            {
                var list = from pp in db.TableReservations where pp.time_from > start select pp;
                reservations = list.ToList();
            }

            catch (Exception exception)
            {
                reservations = new List<TableReservation>();
                Console.WriteLine(exception.Message);
            }

            return reservations;
        }

        /// <summary>
        /// This method finds a reservation in the database that is earlier than the start.
        /// </summary>
        /// <param name="start"></param>
        /// <returns>List<TableReservation></returns>
        public List<TableReservation> FindReservationByStartEarlier(DateTime start)
        {
            List<TableReservation> reservations;

            try
            {
                var list = from pp in db.TableReservations where pp.time_from < start select pp;
                reservations = list.ToList();
            }

            catch (Exception exception)
            {
                reservations = new List<TableReservation>();
                Console.WriteLine(exception.Message);
            }

            return reservations;
        }

        /// <summary>
        /// This method finds a reservation in the database by its end.
        /// </summary>
        /// <param name="end"></param>
        /// <returns>List<TableReservation></returns>
        public List<TableReservation> FindReservationByEnd(DateTime end)
        {
            List<TableReservation> reservations;

            try
            {
                var list = from pp in db.TableReservations where pp.time_to == end select pp;
                reservations = list.ToList();
            }

            catch (Exception exception)
            {
                reservations = new List<TableReservation>();
                Console.WriteLine(exception.Message);
            }

            return reservations;
        }

        /// <summary>
        /// This method finds a reservation in the database that is later than the end.
        /// </summary>
        /// <param name="end"></param>
        /// <returns>List<TableReservation></returns>
        public List<TableReservation> FindReservationByEndLater(DateTime end)
        {
            List<TableReservation> reservations;

            try
            {
                var list = from pp in db.TableReservations where pp.time_to > end select pp;
                reservations = list.ToList();
            }

            catch (Exception exception)
            {
                reservations = new List<TableReservation>();
                Console.WriteLine(exception.Message);
            }

            return reservations;
        }

        /// <summary>
        /// This method finds a reservation in the database that is earlier than the end.
        /// </summary>
        /// <param name="end"></param>
        /// <returns>List<TableReservation></returns>
        public List<TableReservation> FindReservationByEndEarlier(DateTime end)
        {
            List<TableReservation> reservations;

            try
            {
                var list = from pp in db.TableReservations where pp.time_to < end select pp;
                reservations = list.ToList();
            }

            catch (Exception exception)
            {
                reservations = new List<TableReservation>();
                Console.WriteLine(exception.Message);
            }

            return reservations;
        }

        /// <summary>
        /// This method finds a reservation in the database by its parking_id.
        /// </summary>
        /// <param name="parking_id"></param>
        /// <returns>List<TableReservation></returns>
        public List<TableReservation> FindReservationByParkingId(int parking_id)
        {
            List<TableReservation> reservations;

            try
            {
                var list = from pp in db.TableReservations where pp.parking_place_id == parking_id select pp;
                reservations = list.ToList();
            }

            catch (Exception exception)
            {
                reservations = new List<TableReservation>();
                Console.WriteLine(exception.Message);
            }

            return reservations;
        }

        /// <summary>
        /// This method updates a reservation in the database.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="plate_number"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="parking_id"></param>
        /// <returns>string</returns>
        public string UpdateReservation(int id, string plate_number, DateTime start, DateTime end, int parking_id)
        {
            string result = "";
            bool change = false;
            var reservation_query = from pp in db.TableReservations where pp.id == id select pp;

            foreach (TableReservation pp in reservation_query)
            {
                if (pp.plate_number != plate_number)
                {
                    change = true;
                    pp.plate_number = plate_number;
                }

                if (pp.time_from != start)
                {
                    change = true;
                    pp.time_from = start;
                }

                if (pp.time_to != end && pp.time_to >= start)
                {
                    change = true;
                    pp.time_to = end;
                }

                else
                {
                    change = true;
                    pp.time_to = start;
                }

                if (pp.parking_place_id != parking_id)
                {
                    change = true;
                    pp.parking_place_id = parking_id;
                }
                
                if (change.Equals(true))
                {
                    try
                    {
                        db.SubmitChanges();
                        result = "Success";
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                        result = exception.Message;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// This method deletes a reservation from the database using its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>string</returns>
        public string DeleteReservationById(int id)
        {
            string result;
            TableReservation reservation = FindReservationById(id);

            try
            {
                if (reservation.id >= 1)
                {
                    db.TableReservations.DeleteOnSubmit(reservation);
                    db.SubmitChanges();
                    result = "Success";
                }

                else
                {
                    result = "Could not find the reservation";
                }
            }

            catch (Exception exception)
            {
                result = exception.Message;
            }

            return result;
        }

        /// <summary>
        /// This method deletes a reservation from the database using its parking_id.
        /// </summary>
        /// <param name="parking_id"></param>
        /// <returns>string</returns>
        public string DeleteReservationByParkingId(int parking_id)
        {
            string result;
            List<TableReservation> reservations = FindReservationByParkingId(parking_id);

            try
            {
                if (reservations.Count >= 1)
                {
                    db.TableReservations.DeleteAllOnSubmit(reservations);
                    db.SubmitChanges();
                    result = "Success";
                }

                else
                {
                    result = "Could not find the reservations";
                }
            }

            catch (Exception exception)
            {
                result = exception.Message;
            }

            return result;
        }

        /// <summary>
        /// This method finds a list of active reservations
        /// </summary>
        /// <param name="parking_id"></param>
        /// <returns>string</returns>
        public int ActiveReservations(int parking_id)
        {
            int result = 0;
            DateTime current = DateTime.Now;
            List<TableReservation> reservations = FindReservationByParkingId(parking_id);

            foreach(TableReservation reservation in reservations)
            {
                if(reservation.time_from > current && reservation.time_to < current)
                {
                    result++;
                }
            }

            return result;
        }
    }
}