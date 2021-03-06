﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console_User.Control;
using Console_User.RabbitMQ;
using Console_Server.Control;
using Console_Server.Database;
using Console_User.Test;

namespace Console_User
{
    /// <summary>
    /// This is the class Program.
    /// </summary>
    class Program
    {
        private static CTR_User user;
        private static User_Send send_message;
        private static User_Receive receive_message;
        private int requests_sent = 0;

        /// <summary>
        /// This method is where the program starts.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            UserInfo();
            Choices(args);
        }

        /// <summary>
        /// This method prints the choices and read what the user choose.
        /// </summary>
        /// <param name="args"></param>
        public static void Choices(string[] args)
        {
            string number = "";

            while (number != "-5")
            {
                Console.WriteLine("");
                Console.WriteLine("0 - Close program.");
                Console.WriteLine("1 - find nearest parking place.");
                Console.WriteLine("2 - Get your location.");
                Console.WriteLine("3 - get request number.");
                Console.WriteLine("4 - Get average number.");
                Console.WriteLine("5 - Create reservation.");
                Console.WriteLine("6 - Update reservation.");
                Console.WriteLine("7 - Delete reservation.");

                number = Console.ReadLine();

                Inputs(args, number);
            }
        }

        /// <summary>
        /// this method gets the user information.
        /// </summary>
        public static void UserInfo()
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

            receive_message = User_Receive.GetInstance(plate_number);
        }

        /// <summary>
        /// This method gets the user input and gets the information that the input requires.
        /// </summary>
        /// <param name="args"></param>
        /// <param name="input"></param>
        public static void Inputs(string[] args, string input)
        {
            CTR_Reservation reservation = CTR_Reservation.GetInstance();
            CTR_ParkingStatistics stats = CTR_ParkingStatistics.GetInstance();
            send_message = User_Send.GetInstance("");
            receive_message = User_Receive.GetInstance(user.GetUser().GetPlateNumber());

            string server_message = "";
            string splitter = "$$$";

            switch(input)
            {
                case "0": //Close program
                    Environment.Exit(0);

                    break;

                case "1": //Nearest Parking Place
                    Console.WriteLine("Here is the nearest parking place: ");
                    /*
                    server_message = "Get Neareest Parking Place" + splitter;
                    user.GetUser().UpdateLocation();
                    server_message += user.GetUser().GetLocation().GetLongtitude() + splitter;
                    server_message += user.GetUser().GetLocation().GetLatitude() + splitter;
                    server_message += user.GetUser().GetLocation().GetAltitude() + splitter;
                    server_message += user.GetUser().GetPlateNumber();

                    send_message.SetMessage(server_message);
                    send_message.NewTask(args);

                    receive_message.ReceiveMessage(args);
                    */

                    CTR_Parking parking = new CTR_Parking();
                    TableParkingPlace nearest = parking.FindNearest(user.GetUser().GetLocation().GetLongtitude(), user.GetUser().GetLocation().GetLatitude(), user.GetUser().GetLocation().GetAltitude());

                    double distance = Math.Sqrt(Math.Sqrt((nearest.longtitude * nearest.longtitude) + (nearest.latitude * nearest.latitude)) + (nearest.altitude * nearest.altitude));

                    Console.WriteLine("name: " + nearest.parking_name);
                    Console.WriteLine("longtitude: " + nearest.longtitude);
                    Console.WriteLine("latitude: " + nearest.latitude);
                    Console.WriteLine("altitude: " + nearest.altitude);
                    Console.WriteLine("distance: " + distance);

                    break;

                case "2": //Get Location
                    Console.WriteLine("Here is your location: ");
                    user.GetUser().UpdateLocation();

                    double longtitude = user.GetUser().GetLocation().GetLongtitude();
                    double latitude = user.GetUser().GetLocation().GetLatitude();
                    double altitude = user.GetUser().GetLocation().GetAltitude();

                    Console.WriteLine(longtitude + ", " + latitude + ", " + altitude);
                    break;

                case "3": //Get Request Number
                    Console.WriteLine("Here is the request number: ");

                    server_message = "Get Request Number" + splitter + user.GetUser().GetPlateNumber();

                    /*
                    send_message.SetMessage(server_message);
                    send_message.NewTask(args);

                    receive_message.ReceiveMessage(args);
                    */
                    
                    Console.WriteLine(stats.GetRequestNumber());
                    break;

                case "4": //Get Average Number
                    Console.WriteLine("Here is the average number: ");

                    server_message = "Get Average Number" + splitter + user.GetUser().GetPlateNumber();

                    /*
                    send_message.SetMessage(server_message);
                    send_message.NewTask(args);

                    receive_message.ReceiveMessage(args);
                    */
                    
                    Console.WriteLine(stats.GetAverage());
                    break;

                case "5": //Create Reservation
                    string create_plate_number;
                    DateTime create_start;
                    DateTime create_end;
                    double create_minutes;
                    int create_parking_id;
                    string create_result;

                    create_plate_number = user.GetUser().GetPlateNumber();
                    create_start = DateTime.Now;
                    create_end = create_start;
                    
                    Console.WriteLine("How long time will you be parked? - in minutes");
                    create_minutes = Convert.ToDouble(Console.ReadLine());
                    create_end.AddMinutes(create_minutes);

                    Console.WriteLine("what is the parking id?");
                    create_parking_id = Convert.ToInt32(Console.ReadLine());

                    /*
                    server_message = "Create Reservation" + splitter + create_plate_number + splitter + create_start + splitter + create_end + splitter + create_parking_id + splitter + create_plate_number;

                    send_message.SetMessage(server_message);
                    send_message.NewTask(args);

                    receive_message.ReceiveMessage(args);
                    */

                    create_result = reservation.Create(create_plate_number, create_start, create_end, create_parking_id);

                    Console.WriteLine("reservation status: " + create_result);

                    break;

                case "6": //Update Reservation
                    int update_id;
                    string update_plate_number;
                    DateTime update_start;
                    DateTime update_end;
                    double update_minutes;
                    int update_parking_id;
                    string update_result;

                    update_plate_number = user.GetUser().GetPlateNumber();
                    update_start = DateTime.Now;
                    update_end = update_start;

                    Console.WriteLine("what is the id?");
                    update_id = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("How long time will you be parked? - in minutes");
                    update_minutes = Convert.ToDouble(Console.ReadLine());
                    update_end.AddMinutes(update_minutes);

                    Console.WriteLine("what is the parking id?");
                    update_parking_id = Convert.ToInt32(Console.ReadLine());

                    /*
                    server_message = "Update Reservation" + splitter + update_id + splitter + update_plate_number + splitter + update_start + splitter + update_end + splitter + update_parking_id + splitter + update_plate_number;

                    send_message.SetMessage(server_message);
                    send_message.NewTask(args);

                    receive_message.ReceiveMessage(args);
                    */

                    update_result = reservation.Update(update_id, update_plate_number, update_start, update_end, update_parking_id);

                    Console.WriteLine("reservation status: " + update_result);
                    break;

                case "7": //Delete Reservation
                    int delete_id;
                    string delete_id_type;
                    string delete_result;

                    Console.WriteLine("what is the parking id?");
                    delete_id = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("what is the id type?");
                    delete_id_type = Console.ReadLine();

                    /*
                    server_message = "Update Reservation" + splitter + delete_id + splitter + delete_id_type + splitter + user.GetUser().GetPlateNumber();

                    send_message.SetMessage(server_message);
                    send_message.NewTask(args);

                    receive_message.ReceiveMessage(args);
                    */

                    delete_result = reservation.Delete(delete_id, delete_id_type);

                    Console.WriteLine("reservation status: " + delete_result);
                    break;

                case "Test NPP":
                    Test_Parking park = new Test_Parking(user.GetUser().GetName(), user.GetUser().GetEmail(), user.GetUser().GetMobile(), user.GetUser().GetPlateNumber());
                    Console.WriteLine(park.TestNearestParking());
                    break;

                default: //default case
                    Console.WriteLine("Invalid input");
                    break;
            }
        }
    }
}
