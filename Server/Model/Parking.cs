using System;
using System.Collections.Generic;
using Server.Database;

namespace Server.Model
{
    public sealed class Parking
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="longtitude"></param>
        /// <param name="latitude"></param>
        /// <param name="altitude"></param>
        /// <param name="parking_name"></param>
        /// <param name="spaces"></param>
        /// <param name="vacant"></param>
        /// <param name="city"></param>
        /// <param name="country"></param>
        /// <returns></returns>
        public string CreateParking(double longtitude, double latitude, double altitude, string parking_name, int spaces, int vacant, string city, string country)
        {
            string result;

            TableParkingPlace parking_place = new TableParkingPlace();

            parking_place.longtitude = longtitude;
            parking_place.latitude = latitude;
            parking_place.altitude = altitude;
            parking_place.parking_name = parking_name;
            parking_place.spaces = spaces;

            if (vacant > spaces)
            {
                parking_place.vacant = spaces;
            }

           else
            {
                parking_place.vacant = vacant;
            }

            parking_place.city = city;
            parking_place.country = country;

            try
            {
                db.TableParkingPlaces.InsertOnSubmit(parking_place);
                db.SubmitChanges();

                result = "Success";
            }

            catch(Exception exception)
            {
                result = "ERROR: " + exception.Message;
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<TableParkingPlace> ListAllParkings()
        {
            List<TableParkingPlace> administrations;

            try
            {
                var list = from a in db.TableParkingPlaces select a;
                administrations = list.ToList<TableParkingPlace>();
            }

            catch (Exception exception)
            {
                administrations = new List<TableParkingPlace>();
            }

            return administrations;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TableParkingPlace FindParkingByid(int id)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="longtitude"></param>
        /// <param name="latitude"></param>
        /// <param name="altitude"></param>
        /// <returns></returns>
        public List<TableParkingPlace> FindParkingByLocation(double longtitude, double latitude, double altitude)
        {

        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parking_name"></param>
        /// <returns></returns>
        public List<TableParkingPlace> FindParkingByParkingName(string parking_name)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="spaces"></param>
        /// <returns></returns>
        public List<TableParkingPlace> FindParkingBySpaces(int spaces)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="spaces"></param>
        /// <returns></returns>
        public List<TableParkingPlace> FindParkingBySpacesHigher(int spaces)
        {

        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="spaces"></param>
        /// <returns></returns>
        public List<TableParkingPlace> FindParkingBySpacesLower(int spaces)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vacant"></param>
        /// <returns></returns>
        public List<TableParkingPlace> FindParkingByVacant(int vacant)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vacant"></param>
        /// <returns></returns>
        public List<TableParkingPlace> FindParkingByVacantHigher(int vacant)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vacant"></param>
        /// <returns></returns>
        public List<TableParkingPlace> FindParkingByVacantLower(int vacant)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        public List<TableParkingPlace> FindParkingByCity(string city)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        public List<TableParkingPlace> FindParkingByCountry(string country)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="longtitude"></param>
        /// <param name="latitude"></param>
        /// <param name="altitude"></param>
        /// <param name="parking_name"></param>
        /// <param name="spaces"></param>
        /// <param name="vacant"></param>
        /// <param name="city"></param>
        /// <param name="country"></param>
        /// <returns></returns>
        public string UpdateParking(int id, double longtitude, double latitude, double altitude, string parking_name, int spaces, int vacant, string city, string country)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string DeleteParking(int id)
        {

        }
    }
}