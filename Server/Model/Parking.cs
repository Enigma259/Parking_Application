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
            List<TableParkingPlace> parking_places;

            try
            {
                var list = from pp in db.TableParkingPlaces select pp;
                parking_places = list.ToList<TableParkingPlace>();
            }

            catch (Exception exception)
            {
                parking_places = new List<TableParkingPlace>();
                Console.WriteLine(exception.Message);
            }

            return parking_places;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TableParkingPlace FindParkingByid(int id)
        {
            TableParkingPlace parking_place;

            try
            {
                parking_place = db.TableParkingPlaces.First(pp => pp.id == id);
            }

            catch (Exception exception)
            {
                parking_place = new TableParkingPlace();
                Console.WriteLine(exception.Message);
            }

            return parking_place;
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
            List<TableParkingPlace> parking_places;

            try
            {
                var list = from pp in db.TableParkingPlaces where pp.longtitude == longtitude && pp.latitude == latitude && pp.altitude == altitude select pp;
                parking_places = list.ToList();
            }

            catch (Exception exception)
            {
                parking_places = new List<TableParkingPlace>();
                Console.WriteLine(exception.Message);
            }

            return parking_places;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parking_name"></param>
        /// <returns></returns>
        public List<TableParkingPlace> FindParkingByParkingName(string parking_name)
        {
            List<TableParkingPlace> parking_places;

            try
            {
                var list = from pp in db.TableParkingPlaces where pp.parking_name.Contains(parking_name) select pp;
                parking_places = list.ToList();
            }

            catch (Exception exception)
            {
                parking_places = new List<TableParkingPlace>();
                Console.WriteLine(exception.Message);
            }

            return parking_places;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="spaces"></param>
        /// <returns></returns>
        public List<TableParkingPlace> FindParkingBySpaces(int spaces)
        {
            List<TableParkingPlace> parking_places;

            try
            {
                var list = from pp in db.TableParkingPlaces where pp.spaces == spaces select pp;
                parking_places = list.ToList();
            }

            catch (Exception exception)
            {
                parking_places = new List<TableParkingPlace>();
                Console.WriteLine(exception.Message);
            }

            return parking_places;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="spaces"></param>
        /// <returns></returns>
        public List<TableParkingPlace> FindParkingBySpacesHigher(int spaces)
        {
            List<TableParkingPlace> parking_places;

            try
            {
                var list = from pp in db.TableParkingPlaces where pp.spaces > spaces select pp;
                parking_places = list.ToList();
            }

            catch (Exception exception)
            {
                parking_places = new List<TableParkingPlace>();
                Console.WriteLine(exception.Message);
            }

            return parking_places;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="spaces"></param>
        /// <returns></returns>
        public List<TableParkingPlace> FindParkingBySpacesLower(int spaces)
        {
            List<TableParkingPlace> parking_places;

            try
            {
                var list = from pp in db.TableParkingPlaces where pp.spaces < spaces select pp;
                parking_places = list.ToList();
            }

            catch (Exception exception)
            {
                parking_places = new List<TableParkingPlace>();
                Console.WriteLine(exception.Message);
            }

            return parking_places;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vacant"></param>
        /// <returns></returns>
        public List<TableParkingPlace> FindParkingByVacant(int vacant)
        {
            List<TableParkingPlace> parking_places;

            try
            {
                var list = from pp in db.TableParkingPlaces where pp.vacant == vacant select pp;
                parking_places = list.ToList();
            }

            catch (Exception exception)
            {
                parking_places = new List<TableParkingPlace>();
                Console.WriteLine(exception.Message);
            }

            return parking_places;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vacant"></param>
        /// <returns></returns>
        public List<TableParkingPlace> FindParkingByVacantHigher(int vacant)
        {
            List<TableParkingPlace> parking_places;

            try
            {
                var list = from pp in db.TableParkingPlaces where pp.vacant > vacant select pp;
                parking_places = list.ToList();
            }

            catch (Exception exception)
            {
                parking_places = new List<TableParkingPlace>();
                Console.WriteLine(exception.Message);
            }

            return parking_places;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vacant"></param>
        /// <returns></returns>
        public List<TableParkingPlace> FindParkingByVacantLower(int vacant)
        {
            List<TableParkingPlace> parking_places;

            try
            {
                var list = from pp in db.TableParkingPlaces where pp.vacant < vacant select pp;
                parking_places = list.ToList();
            }

            catch (Exception exception)
            {
                parking_places = new List<TableParkingPlace>();
                Console.WriteLine(exception.Message);
            }

            return parking_places;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        public List<TableParkingPlace> FindParkingByCity(string city)
        {
            List<TableParkingPlace> parking_places;

            try
            {
                var list = from pp in db.TableParkingPlaces where pp.city.Contains(city) select pp;
                parking_places = list.ToList();
            }

            catch (Exception exception)
            {
                parking_places = new List<TableParkingPlace>();
                Console.WriteLine(exception.Message);
            }

            return parking_places;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        public List<TableParkingPlace> FindParkingByCountry(string country)
        {
            List<TableParkingPlace> parking_places;

            try
            {
                var list = from pp in db.TableParkingPlaces where pp.country.Contains(country) select pp;
                parking_places = list.ToList();
            }

            catch (Exception exception)
            {
                parking_places = new List<TableParkingPlace>();
                Console.WriteLine(exception.Message);
            }

            return parking_places;
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
            string result;
            bool change = false;
            var parking_place = from pp in db.TableParkingPlaces where pp.id == id  select pp;

            foreach (TableParkingPlace pp in parking_place)
            {
                if (pp.longtitude != longtitude)
                {
                    change = true;
                    pp.longtitude = longtitude;
                }

                if (pp.latitude != latitude)
                {
                    change = true;
                    pp.latitude = latitude;
                }

                if (pp.altitude != altitude)
                {
                    change = true;
                    pp.altitude = altitude;
                }

                if (pp.parking_name != parking_name)
                {
                    change = true;
                    pp.parking_name = parking_name;
                }

                if (pp.spaces != spaces)
                {
                    change = true;
                    pp.spaces = spaces;
                }

                if (pp.vacant != vacant)
                {
                    change = true;
                    if (vacant > spaces)
                    {
                        pp.vacant = spaces;
                    }

                    else
                    {
                        pp.vacant = vacant;
                    }
                }

                if (pp.city != city)
                {
                    change = true;
                    pp.city = city;
                }

                if (pp.country != country)
                {
                    change = true;
                    pp.country = country;
                }

                if(change.Equals(true))
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
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string DeleteParking(int id)
        {
            string result;
            TableParkingPlace parking_place = FindParkingByid(id);

            try
            {
                if (parking_place.id >= 1)
                {
                    db.TableParkingPlaces.DeleteOnSubmit(parking_place);
                    db.SubmitChanges();
                    result = "Success";
                }

                else
                {
                    result = "Could not find the parking space";
                }
            }

            catch(Exception exception)
            {
                result = exception.Message;
            }

            return result;
        }
    }
}