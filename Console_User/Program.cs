using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console_User.Control;
using Console_User.RabbitMQ;

namespace Console_User
{
    class Program
    {
        private static CTR_User user;
        private User_Send send_message;
        private User_Receive receive_message;
        private int requests_sent = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();

            Console.WriteLine("What is your email?");
            string email = Console.ReadLine();

            Console.WriteLine("What is your mobile number?");
            string mobile = Console.ReadLine();

            Console.WriteLine("What is your platenumber?");
            string plate_number = Console.ReadLine();

            user = CTR_User.GetInstance(name, email, mobile, plate_number);
            Console.ReadLine();
        }

        public void Inputs(string input)
        {
            switch(input)
            {
                case "1": //Nearest Parking Place
                    //some code here;
                    break;

                case "2": //Get Location
                    Console.WriteLine("Here us your location: ");
                    user.GetUser().UpdateLocation();
                    double longtitude = user.GetUser().GetLocation().GetLongtitude();
                    double latitude = user.GetUser().GetLocation().GetLatitude();
                    double altitude = user.GetUser().GetLocation().GetAltitude();

                    Console.WriteLine(longtitude + ", " + latitude + ", " + altitude);
                    break;

                case "3": //Get Request Number
                    //some code here;
                    break;

                case "4": //Get Average Number
                    //some code here;
                    break;

                case "5": //Create Reservation
                    //some code here;
                    break;

                case "6": //Update Reservation
                    //some code here;
                    break;

                case "7": //Delete Reservation
                    //some code here;
                    break;

                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }
    }
}
