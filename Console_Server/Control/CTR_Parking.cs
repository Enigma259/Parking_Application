using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Console_Server.Model;
using Console_Server.Database;

namespace Console_Server.Control
{
    /// <summary>
    /// This is the class CTR_Parking.
    /// </summary>
    public class CTR_Parking
    {
        private Parking parking;
        private CTR_ParkingStatistics stats;

        /// <summary>
        /// This is the constructor for the class CTR_Parking.
        /// </summary>
        public CTR_Parking()
        {
            this.parking = Parking.GetInstance();
            this.stats = CTR_ParkingStatistics.GetInstance();
        }

        /// <summary>
        /// This method creates a parking place.
        /// </summary>
        /// <param name="longtitude"></param>
        /// <param name="latitude"></param>
        /// <param name="altitude"></param>
        /// <param name="parking_name"></param>
        /// <param name="spaces"></param>
        /// <param name="vacant"></param>
        /// <param name="city"></param>
        /// <param name="country"></param>
        /// <returns>string</returns>
        public string Create(double longtitude, double latitude, double altitude, string parking_name, int spaces, int vacant, string city, string country)
        {
            stats.NewRequest();
            return parking.CreateParking(longtitude, latitude, altitude, parking_name, spaces, vacant, city, country);
        }

        /// <summary>
        /// This method lists all the parking places.
        /// </summary>
        /// <returns>List<TableParkingPlace></returns>
        public List<TableParkingPlace> ListAll()
        {
            stats.NewRequest();
            return parking.ListAllParkings();
        }

        /// <summary>
        /// This method finds a parking place by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>TableParkingPlace</returns>
        public TableParkingPlace FindById(int id)
        {
            stats.NewRequest();
            return parking.FindParkingByid(id);
        }

        /// <summary>
        /// This method finds a list of parking places by its longtitude, latitude, and altitude.
        /// </summary>
        /// <param name="longtitude"></param>
        /// <param name="latitude"></param>
        /// <param name="altitude"></param>
        /// <returns>List<TableParkingPlace></returns>
        public List<TableParkingPlace> FindByLocation(double longtitude, double latitude, double altitude)
        {
            stats.NewRequest();
            return parking.FindParkingByLocation(longtitude, latitude, altitude);
        }

        /// <summary>
        /// This method finds the nearest parking place from a given location.
        /// </summary>
        /// <param name="longtitude"></param>
        /// <param name="latitude"></param>
        /// <param name="altitude"></param>
        /// <returns>TableParkingPlace</returns>
        public TableParkingPlace FindNearest(double longtitude, double latitude, double altitude)
        {
            stats.NewRequest();
            return parking.FindNearestParking(longtitude, latitude, altitude);
        }

        /// <summary>
        /// This method finds a list of parking places by its parking_name.
        /// </summary>
        /// <param name="parking_name"></param>
        /// <returns>List<TableParkingPlace></returns>
        public List<TableParkingPlace> FindByName(string parking_name)
        {
            stats.NewRequest();
            return parking.FindParkingByParkingName(parking_name);
        }

        /// <summary>
        /// This method finds a list of parking places by its spaces.
        /// </summary>
        /// <param name="spaces"></param>
        /// <param name="where"></param>
        /// <returns>List<TableParkingPlace></returns>
        public List<TableParkingPlace> FindBySpaces(int spaces, string where)
        {
            stats.NewRequest();
            List<TableParkingPlace> result;

            if (where.Equals("Here"))
            {
                result = parking.FindParkingBySpaces(spaces);
            }

            else if (where.Equals("Higher"))
            {
                result = parking.FindParkingBySpacesHigher(spaces);
            }

            else if (where.Equals("Lower"))
            {
                result = parking.FindParkingBySpacesLower(spaces);
            }

            else
            {
                result = new List<TableParkingPlace>();
            }

            return result;
        }

        /// <summary>
        /// This method finds a list of parking places by its vacant.
        /// </summary>
        /// <param name="vacant"></param>
        /// <param name="where"></param>
        /// <returns>List<TableParkingPlace></returns>
        public List<TableParkingPlace> FindByVacant(int vacant, string where)
        {
            stats.NewRequest();
            List<TableParkingPlace> result;

            if (where.Equals("Here"))
            {
                result = parking.FindParkingByVacant(vacant);
            }

            else if (where.Equals("Higher"))
            {
                result = parking.FindParkingByVacantHigher(vacant);
            }

            else if (where.Equals("Lower"))
            {
                result = parking.FindParkingByVacantLower(vacant);
            }

            else
            {
                result = new List<TableParkingPlace>();
            }

            return result;
        }

        /// <summary>
        /// This method finds a list of parking places by its city.
        /// </summary>
        /// <param name="city"></param>
        /// <returns>List<TableParkingPlace></returns>
        public List<TableParkingPlace> FindByCity(string city)
        {
            stats.NewRequest();
            return parking.FindParkingByCity(city);
        }

        /// <summary>
        /// This method finds a list of parking places by its country.
        /// </summary>
        /// <param name="country"></param>
        /// <returns>List<TableParkingPlace></returns>
        public List<TableParkingPlace> FindByCountry(string country)
        {
            stats.NewRequest();
            return parking.FindParkingByCountry(country);
        }

        /// <summary>
        /// This method updates a parking place.
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
        /// <returns>string</returns>
        public string Update(int id, double longtitude, double latitude, double altitude, string parking_name, int spaces, int vacant, string city, string country)
        {
            stats.NewRequest();
            return parking.UpdateParking(id, longtitude, latitude, altitude, parking_name, spaces, vacant, city, country);
        }

        /// <summary>
        /// This method deletes a parking place.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>string</returns>
        public string Delete(int id)
        {
            stats.NewRequest();
            return parking.DeleteParking(id);
        }
    }
}