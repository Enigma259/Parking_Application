using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Console_Server.Control;
using Console_Server.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Console_Server.RabbitMQ
{
    /// <summary>
    /// This is the class Server_Receive.
    /// </summary>
    public class Server_Receive
    {
        private string host_name;
        private string user;
        private string password;
        private string virtuel_host;
        private string queue;
        private bool durable;
        private bool exclusive;
        private bool autoDelete;
        private IDictionary<string, object> arguments;
        private uint prefetchSize;
        private ushort prefetchCount;
        private bool global;
        private bool multiple;
        private bool autoAck;

        private CTR_Location location;
        private CTR_Parking parking;
        private CTR_ParkingStatistics stats;
        private CTR_Reservation reservation;

        /// <summary>
        /// this is the constructor for the class Server_Receive.
        /// </summary>
        public Server_Receive()
        {
            this.host_name = "localhost - tasks";
            this.user = "serverUser";
            this.password = "123456789";
            this.virtuel_host = "/";
            this.queue = "task_queue";
            this.durable = true;
            this.exclusive = false;
            this.autoDelete = false;
            this.arguments = null;
            this.prefetchSize = 0;
            this.prefetchCount = 1;
            this.global = false;
            this.multiple = false;
            this.autoAck = false;

            this.location = CTR_Location.GetInstance();
            this.parking = new CTR_Parking();
            this.stats = CTR_ParkingStatistics.GetInstance();
            this.reservation = CTR_Reservation.GetInstance();
        }

        /// <summary>
        /// This method returns the value of the instance host_name.
        /// </summary>
        /// <returns>string</returns>
        public string GetHostName()
        {
            return host_name;
        }

        /// <summary>
        /// This method returns the value of the instance user.
        /// </summary>
        /// <returns>string</returns>
        public string GetUser()
        {
            return user;
        }

        /// <summary>
        /// This method returns the value of the instance password.
        /// </summary>
        /// <returns>string</returns>
        public string GetPassword()
        {
            return password;
        }

        /// <summary>
        /// This method returns the value of the instance virtuel_host.
        /// </summary>
        /// <returns>string</returns>
        public string GetVirtuelHost()
        {
            return virtuel_host;
        }

        /// <summary>
        /// This method returns the value of the instance queue.
        /// </summary>
        /// <returns>string</returns>
        public string GetQueue()
        {
            return queue;
        }

        /// <summary>
        /// This method returns the value of the instance durable.
        /// </summary>
        /// <returns>bool</returns>
        public bool GetDurable()
        {
            return durable;
        }

        /// <summary>
        /// This method returns the value of the instance exclusive.
        /// </summary>
        /// <returns>bool</returns>
        public bool GetExclusive()
        {
            return exclusive;
        }

        /// <summary>
        /// This method returns the value of the instance autoDelete.
        /// </summary>
        /// <returns>bool</returns>
        public bool GetAutoDelete()
        {
            return autoDelete;
        }

        /// <summary>
        /// This method returns the value of the instance arguments.
        /// </summary>
        /// <returns>IDictionary<string, object></returns>
        public IDictionary<string, object> GetArguments()
        {
            return arguments;
        }

        /// <summary>
        /// This method returns the value of the instance prefetchSize.
        /// </summary>
        /// <returns>uint</returns>
        public uint GetPrefetchSize()
        {
            return prefetchSize;
        }

        /// <summary>
        /// This method returns the value of the instance prefetchCount.
        /// </summary>
        /// <returns>ushort</returns>
        public ushort GetPrefetchCount()
        {
            return prefetchCount;
        }

        /// <summary>
        /// This method returns the value of the instance global.
        /// </summary>
        /// <returns>bool</returns>
        public bool GetGlobal()
        {
            return global;
        }

        /// <summary>
        /// This method returns the value of the instance multiple.
        /// </summary>
        /// <returns>bool</returns>
        public bool GetMultiple()
        {
            return multiple;
        }

        /// <summary>
        /// This method returns the value of the instance autoAck.
        /// </summary>
        /// <returns>bool</returns>
        public bool GetAutoAck()
        {
            return autoAck;
        }

        /// <summary>
        /// This method changes the value of the instance host_name.
        /// </summary>
        /// <param name="host_name"></param>
        public void SetHostName(string host_name)
        {
            this.host_name = host_name;
        }

        /// <summary>
        /// This method changes the value of the instance user.
        /// </summary>
        /// <param name="user"></param>
        public void SetUser(string user)
        {
            this.user = user;
        }

        /// <summary>
        /// This method changes the value of the instance password.
        /// </summary>
        /// <param name="password"></param>
        public void SetPassword(string password)
        {
            this.password = password;
        }

        /// <summary>
        /// This method changes the value of the instance virtuel_host.
        /// </summary>
        /// <param name="virtuel_host"></param>
        public void SetVirtuelHost(string virtuel_host)
        {
            this.virtuel_host = virtuel_host;
        }

        /// <summary>
        /// This method changes the value of the instance queue.
        /// </summary>
        /// <param name="queue"></param>
        public void SetQueue(string queue)
        {
            this.queue = queue;
        }

        /// <summary>
        /// This method changes the value of the instance durable.
        /// </summary>
        /// <param name="durable"></param>
        public void SetDurable(bool durable)
        {
            this.durable = durable;
        }

        /// <summary>
        /// This method changes the value of the instance exclusive.
        /// </summary>
        /// <param name="exclusive"></param>
        public void SetExclusive(bool exclusive)
        {
            this.exclusive = exclusive;
        }

        /// <summary>
        /// This method changes the value of the instance autoDelete.
        /// </summary>
        /// <param name="autoDelete"></param>
        public void SetAutoDelete(bool autoDelete)
        {
            this.autoDelete = autoDelete;
        }

        /// <summary>
        /// This method changes the value of the instance arguments.
        /// </summary>
        /// <param name="arguments"></param>
        public void SetArguments(IDictionary<string, object> arguments)
        {
            this.arguments = arguments;
        }

        /// <summary>
        /// This method changes the value of the instance prefetchSize.
        /// </summary>
        /// <param name="prefetchSize"></param>
        public void SetPrefetchSize(uint prefetchSize)
        {
            this.prefetchSize = prefetchSize;
        }

        /// <summary>
        /// This method changes the value of the instance prefetchCount.
        /// </summary>
        /// <param name="prefetchCount"></param>
        public void SetPrefetchCount(ushort prefetchCount)
        {
            this.prefetchCount = prefetchCount;
        }

        /// <summary>
        /// This method changes the value of the instance global.
        /// </summary>
        /// <param name="global"></param>
        public void SetGlobal(bool global)
        {
            this.global = global;
        }

        /// <summary>
        /// This method changes the value of the instance multiple.
        /// </summary>
        /// <param name="multiple"></param>
        public void SetMultiple(bool multiple)
        {
            this.multiple = multiple;
        }

        /// <summary>
        /// This method changes the value of the instance autoAck.
        /// </summary>
        /// <param name="autoAck"></param>
        public void SetAutoAck(bool autoAck)
        {
            this.autoAck = autoAck;
        }

        /// <summary>
        /// This method sends the result to the message queue.
        /// </summary>
        /// <param name="args"></param>
        public void ReceiveMessage(string[] args)
        {
            var factory = new ConnectionFactory()
            {
                HostName = GetHostName(),
                UserName = GetUser(),
                Password = GetPassword(),
                VirtualHost = GetVirtuelHost(),
                RequestedHeartbeat = 60
            };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: GetQueue(), durable: GetDurable(), exclusive: GetExclusive(), autoDelete: GetAutoDelete(), arguments: GetArguments());

                channel.BasicQos(prefetchSize: GetPrefetchSize(), prefetchCount: GetPrefetchCount(), global: GetGlobal());

                Console.WriteLine(" [*] Waiting for messages.");

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(" [x] Received {0}", message);
                    
                    int dots = message.Split('.').Length - 1;
                    Thread.Sleep(dots * 1000);

                    Console.WriteLine(" [x] Done");
                    Tasks(args, message);

                    channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: GetMultiple());
                };
                channel.BasicConsume(queue: "task_queue", autoAck: GetAutoAck(), consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }

        /// <summary>
        /// This method takes the received message and executes the task that the meessage tells it to do.
        /// </summary>
        /// <param name="message"></param>
        public void Tasks(string[] args, string message)
        {
            stats.NewRequest();

            List<string> information;
            information = SplitMessage(message);

            Console.WriteLine("Finding task to execute.");
            switch (information[0])
            {
                case "Get Neareest Parking Place":
                    NearestParkingPlace(args, information);
                    break;

                case "Get Location":
                    GetLocation(args, information);
                    break;

                case "Get Request Number":
                    GetRequestNumber(args, information);
                    break;

                case "Get Average Number":
                    GetAverageNumber(args, information);
                    break;

                case "Create Reservation":
                    CreateReservation(args, information);
                    break;

                case "Update Reservation":
                    UpdateReservation(args, information);
                    break;

                case "Delete Reservation":
                    DeleteReservation(args, information);
                    break;

                default:
                    Switch_Default(args, information);
                    break;
            }
        }

        /// <summary>
        /// This method splits the message up into smaller parts so it can be handled.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public List<string> SplitMessage(string message)
        {
            Console.WriteLine("Splitting up the message: " + message);

            int index = 0;
            string part_information = "";
            bool part_started = false;
            List<string> information = new List<string>();

            //getting the task out of message.
            while (index < message.Length)
            {
                if (!message[index].Equals("$"))
                {
                    if (part_started.Equals(false) && message[index].Equals(" "))
                    {
                        index++;
                    }

                    else
                    {
                        part_started = true;
                        part_information = part_information + message[index];
                        index++;
                    }
                }

                else
                {
                    if (part_started.Equals(true))
                    {
                        information.Add(part_information);
                        part_information = "";
                        part_started = false;
                        index++;
                    }

                    else
                    {
                        index++;
                    }
                }
            }

            return information;
        }

        /// <summary>
        /// This method find the nearest parking place and send it back to the specific user.
        /// </summary>
        /// <param name="information"></param>
        public void NearestParkingPlace(string[] args, List<string> information)
        {
            stats.NewRequest();
            Console.WriteLine("executing task: Get Neareest Parking Place");

            Server_Send send_result;
            string result;
            double longtitude = Double.Parse(information[1]);
            double latitude = Double.Parse(information[2]);
            double altitude = Double.Parse(information[3]);

            TableParkingPlace nearest = parking.FindNearest(longtitude, latitude, altitude);
            double part_distance;
            double distance;

            part_distance = Math.Sqrt((nearest.longtitude * nearest.longtitude) + (nearest.latitude * nearest.latitude));
            distance = Math.Sqrt((part_distance * part_distance) + (nearest.altitude * nearest.altitude));

            result = "Nearest Parking Place" + "$$$" + nearest.parking_name + "$$$" + distance + "$$$" + nearest.longtitude + "$$$" + nearest.latitude + "$$$" + nearest.altitude;

            send_result = new Server_Send(information[5], result);
            send_result.SendMessage(args);
        }

        /// <summary>
        /// This method gets the location and send it back to the specific user.
        /// </summary>
        /// <param name="information"></param>
        public void GetLocation(string[] args, List<string> information)
        {
            stats.NewRequest();
            Console.WriteLine("executing task: Get Location");

            location.SetLocation();

            double longtitude = location.GetLongtitude();
            double lattitude = location.GetLatitude();
            double altitude = location.GetAltitude();
            string result;
            Server_Send send_result;

            result = "Get Location" + "$$$" + longtitude + "$$$" + lattitude + "$$$" + altitude;

            send_result = new Server_Send(information[1], result);
            send_result.SendMessage(args);
        }

        /// <summary>
        /// This method gets the number of requests and send it back to the specific user.
        /// </summary>
        public void GetRequestNumber(string[] args, List<string> information)
        {
            stats.NewRequest();
            Console.WriteLine("executing task: Get Request Number");

            Server_Send send_result;
            int request_number = stats.GetRequestNumber();

            string result = "Get Request Number" + "$$$" + request_number;

            send_result = new Server_Send(information[1], result);
            send_result.SendMessage(args);
        }

        /// <summary>
        /// This method get the average number of request and send it to the user.
        /// </summary>
        public void GetAverageNumber(string[] args, List<string> information)
        {
            stats.NewRequest();
            Console.WriteLine("executing task: Get Average Number");

            Server_Send send_result;
            double average = stats.GetAverage();

            string result = "Get Average Number" + "$$$" + average;

            send_result = new Server_Send(information[1], result);
            send_result.SendMessage(args);
        }

        /// <summary>
        /// This method creates a reservation and send the response to the user.
        /// </summary>
        /// <param name="information"></param>
        public void CreateReservation(string[] args, List<string> information)
        {
            stats.NewRequest();
            Console.WriteLine("executing task: Create Reservation");

            string result;
            Server_Send send_result;
            string plate_number = information[1];
            DateTime start = DateTime.Parse(information[2]);
            DateTime end = DateTime.Parse(information[3]);
            int parking_id = int.Parse(information[4]);

            result = "Create Reservation" + "$$$" + reservation.Create(plate_number, start, end, parking_id);

            send_result = new Server_Send(information[5], result);
            send_result.SendMessage(args);
        }

        /// <summary>
        /// This method updates a reservation and send the response to the user.
        /// </summary>
        /// <param name="information"></param>
        public void UpdateReservation(string[] args, List<string> information)
        {
            stats.NewRequest();
            Console.WriteLine("executing task: Update Reservation");

            string result;
            Server_Send send_result;
            int id = int.Parse(information[1]);
            string plate_number = information[2];
            DateTime start = DateTime.Parse(information[3]);
            DateTime end = DateTime.Parse(information[4]);
            int parking_id = int.Parse(information[5]);

            result = "Update Reservation" + "$$$" + reservation.Update(id, plate_number, start, end, parking_id);

            send_result = new Server_Send(information[6], result);
            send_result.SendMessage(args);
        }

        /// <summary>
        /// This method deletes a reservation and send the response to the user.
        /// </summary>
        /// <param name="information"></param>
        public void DeleteReservation(string[] args, List<string> information)
        {
            stats.NewRequest();
            Console.WriteLine("executing task: Delete Reservation");

            string result;
            Server_Send send_result;
            int id = int.Parse(information[1]);
            string id_type = information[2];

            result = "Delete Reservation" + "$$$" + reservation.Delete(id, id_type);

            send_result = new Server_Send(information[3], result);
            send_result.SendMessage(args);
        }

        /// <summary>
        /// This method send s a response if it doesn't know what to do with the information.
        /// </summary>
        public void Switch_Default(string[] args, List<string> information)
        {
            stats.NewRequest();
            string result;
            Server_Send send_result;

            result = "This feature is not available.";

            send_result = new Server_Send(information[1], result);
            send_result.SendMessage(args);
        }
    }
}