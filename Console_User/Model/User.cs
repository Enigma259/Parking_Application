using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_User.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class User
    {
        private string name;
        private string email;
        private string mobile;
        private string plate_number;
        private Location location;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="mobile"></param>
        /// <param name="plate_number"></param>
        /// <param name="location"></param>
        public User(string name, string email, string mobile, string plate_number)
        {
            this.name = name;
            this.email = email;
            this.mobile = mobile;
            this.plate_number = plate_number;
            this.location = Location.GetInstance();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetEmail()
        {
            return email;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetMobile()
        {
            return mobile;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetPlateNumber()
        {
            return plate_number;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Location GetLocation()
        {
            UpdateLocation();

            return location;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public void SetName(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        public void SetEmail(string email)
        {
            this.email = email;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mobile"></param>
        public void SetMobile(string mobile)
        {
            this.mobile = mobile;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plate_number"></param>
        public void SetPlateNumber(string plate_number)
        {
            this.plate_number = plate_number;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="location"></param>
        public void SetLocation(Location location)
        {
            this.location = location;
        }

        /// <summary>
        /// 
        /// </summary>
        public void UpdateLocation()
        {
            if(GetLocation().Equals(null))
            {
                SetLocation(Location.GetInstance());
            }

            else
            {
                location.SetLocation();
            }
        }
    }
}
