using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console_User.Model;

namespace Console_User.Control
{
    /// <summary>
    /// This is the class CTR_User.
    /// </summary>
    public class CTR_User
    {
        private static volatile CTR_User _instance;
        private static readonly object syncRoot = new object();
        private User user;

        /// <summary>
        /// This is the constructor for the class CTR_User.
        /// </summary>
        private CTR_User(string name, string email, string mobile, string plate_number)
        {
            this.user = new User(name, email, mobile, plate_number);
        }

        /// <summary>
        /// This is a multi threaded singleton for the class CTR_User.
        /// </summary>
        /// <returns>_instance</returns>
        public static CTR_User GetInstance(string name, string email, string mobile, string plate_number)
        {
            if (_instance == null)
            {
                lock (syncRoot)
                {
                    if (_instance == null)
                    {
                        _instance = new CTR_User(name, email, mobile, plate_number);
                    }
                }
            }

            return _instance;
        }

        /// <summary>
        /// This method updates the information of the user.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="mobile"></param>
        /// <param name="plate_number"></param>
        /// <returns></returns>
        public string UpdateUser(string name, string email, string mobile, string plate_number)
        {
            string result;

            if (!name.Equals(null) || !name.Equals(""))
            {
                user.SetName(name);
            }

            if (!email.Equals(null) || !email.Equals(""))
            {
                user.SetEmail(email);
            }

            if (!mobile.Equals(null) || !mobile.Equals(""))
            {
                user.SetMobile(mobile);
            }

            if (!plate_number.Equals(null) || !plate_number.Equals(""))
            {
                user.SetPlateNumber(plate_number);
            }

            user.UpdateLocation();
            result = "Update complete";

            return result;
        }

        /// <summary>
        /// This method returns the user.
        /// </summary>
        /// <returns></returns>
        public User GetUser()
        {
            return user;
        }
    }
}
