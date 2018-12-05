using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Server.Model;
using Server.Database;

namespace Server.Control
{
    //
    public class CTR_Parking
    {
        private Parking parking;


        public CTR_Parking()
        {
            this.parking = Parking.GetInstance();
        }

        //
        public string Create(double longtitude, double latitude, double altitude, string parking_name, int spaces, int vacant, string city, string country)
        {
            return parking.CreateParking(longtitude, latitude, altitude, parking_name, spaces, vacant, city, country);
        }

        //        
        public List<TableParkingPlace> ListAll()
        {
            return parking.ListAllParkings();
        }

        //
        public TableParkingPlace FindById(int id)
        {
            return parking.FindParkingByid(id);
        }

        //
        public List<TableParkingPlace> FindByLocation(double longtitude, double latitude, double altitude)
        {
            return parking.FindParkingByLocation(longtitude, latitude, altitude);
        }

        //
        public TableParkingPlace FindNearest(string city, string country, double longtitude, double latitude)
        {
            return parking.FindNearestParking(city, country, longtitude, latitude);
        }

        //
        public List<TableParkingPlace> FindByName(string parking_name)
        {
            return parking.FindParkingByParkingName(parking_name);
        }

        //
        public List<TableParkingPlace> FindBySpaces(int spaces, string where)
        {
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

        //
        public List<TableParkingPlace> FindByVacant(int vacant, string where)
        {
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

        //
        public List<TableParkingPlace> FindByCity(string city)
        {
            return parking.FindParkingByCity(city);
        }

        //
        public List<TableParkingPlace> FindByCountry(string country)
        {
            return parking.FindParkingByCountry(country);
        }

        //
        public string Update(int id, double longtitude, double latitude, double altitude, string parking_name, int spaces, int vacant, string city, string country)
        {
            return parking.UpdateParking(id, longtitude, latitude, altitude, parking_name, spaces, vacant, city, country);
        }

        //
        public string Delete(int id)
        {
            return parking.DeleteParking(id);
        }
    }
}