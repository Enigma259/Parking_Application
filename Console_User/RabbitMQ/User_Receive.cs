using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_User.RabbitMQ
{
    public sealed class User_Receive
    {
        private static volatile User_Receive _instance;
        private static readonly object syncRoot = new object();

        /// <summary>
        /// This is the constructor for the class User_Receive.
        /// </summary>
        private User_Receive()
        {

        }

        /// <summary>
        /// This is a multi threaded singleton for the class User_Receive.
        /// </summary>
        /// <returns>_instance</returns>
        public static User_Receive GetInstance()
        {
            if (_instance == null)
            {
                lock (syncRoot)
                {
                    if (_instance == null)
                    {
                        _instance = new User_Receive();
                    }
                }
            }

            return _instance;
        }
    }
}
