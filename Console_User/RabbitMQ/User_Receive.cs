using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Console_User.RabbitMQ
{
    /// <summary>
    /// This is the class User_Receive.
    /// </summary>
    public sealed class User_Receive
    {
        private static volatile User_Receive _instance;
        private static readonly object syncRoot = new object();
        private string host_name;
        private string user;
        private string password;
        private string virtuel_host;
        private string exchange;
        private string type;
        private bool autoAck;

        /// <summary>
        /// This is the constructor for the class User_Receive.
        /// </summary>
        private User_Receive(string type)
        {
            this.host_name = "localhost - user";
            this.user = "serverUser";
            this.password = "123456789";
            this.virtuel_host = "/";
            this.exchange = "direct_logs";
            this.type = type;
            this.autoAck = true;

        }

        /// <summary>
        /// This is a multi threaded singleton for the class User_Receive.
        /// </summary>
        /// <returns>_instance</returns>
        public static User_Receive GetInstance(string type)
        {
            if (_instance == null)
            {
                lock (syncRoot)
                {
                    if (_instance == null)
                    {
                        _instance = new User_Receive(type);
                    }
                }
            }

            return _instance;
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
        /// This method returns the value of the instance exchange.
        /// </summary>
        /// <returns>string</returns>
        public string GetExchange()
        {
            return exchange;
        }

        /// <summary>
        /// This method returns the value of the instance type.
        /// </summary>
        /// <returns>string</returns>
        public string GetRMQType()
        {
            return type;
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
        /// This method changes the value of the instance exchange.
        /// </summary>
        /// <param name="exchange"></param>
        public void SetExchange(string exchange)
        {
            this.exchange = exchange;
        }

        /// <summary>
        /// This method changes the value of the instance type.
        /// </summary>
        /// <param name="type"></param>
        public void SetType(string type)
        {
            this.type = type;
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
        /// This method receives a message from the server.
        /// </summary>
        /// <param name="args"></param>
        public void ReceiveMessage(string[] args)
        {
            List<string> information;

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
                channel.ExchangeDeclare(exchange: GetExchange(), type: GetRMQType());
                var queueName = channel.QueueDeclare().QueueName;

                if (args.Length < 1)
                {
                    Console.Error.WriteLine("Usage: {0} [info] [warning] [error]", Environment.GetCommandLineArgs()[0]);
                    Console.WriteLine(" Press [enter] to exit.");
                    Console.ReadLine();
                    Environment.ExitCode = 1;
                    return;
                }

                foreach (var severity in args)
                {
                    channel.QueueBind(queue: queueName, exchange: GetExchange(), routingKey: severity);
                }

                Console.WriteLine(" [*] Waiting for messages.");

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    var routingKey = ea.RoutingKey;
                    Console.WriteLine(" [x] Received '{0}':'{1}'", routingKey, message);

                    information = SplitMessage(message);
                    PrintMessage(information);

                };
                channel.BasicConsume(queue: queueName, autoAck: GetAutoAck(), consumer: consumer);
            }
        }

        /// <summary>
        /// This method takes the message from the server and split it up.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public List<string> SplitMessage(string message)
        {
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
        /// This method takes the splitted message and print it.
        /// </summary>
        /// <param name="information"></param>
        public bool PrintMessage(List<string> information)
        {
            bool message_received;
            switch (information[0])
            {
                case "Nearest Parking Place":

                    Console.WriteLine("parking place name: ");
                    Console.WriteLine(information[1]);
                    Console.WriteLine("Distance: ");
                    Console.WriteLine(information[2]);
                    Console.WriteLine("Location: ");
                    Console.WriteLine(information[3] + ", " + information[4] + ", " + information[5]);
                    message_received = true;
                    break;

                case "Get Location":
                    Console.WriteLine("Location: ");
                    Console.WriteLine(information[1] + ", " + information[2] + ", " + information[3]);
                    message_received = true;
                    break;

                case "Get Request Number":
                    Console.WriteLine("Request number: ");
                    Console.WriteLine(information[1]);
                    message_received = true;
                    break;

                case "Get Average Number":
                    Console.WriteLine("Average number: ");
                    Console.WriteLine(information[1]);
                    message_received = true;
                    break;

                case "Create Reservation":
                    Console.WriteLine("Create Reservation status: ");
                    Console.WriteLine(information[1]);
                    message_received = true;
                    break;

                case "Update Reservation":
                    Console.WriteLine("Update Reservation status: ");
                    Console.WriteLine(information[1]);
                    message_received = true;
                    break;

                case "Delete Reservation":
                    Console.WriteLine("Delete Reservation status: ");
                    Console.WriteLine(information[1]);
                    message_received = true;
                    break;

                default:
                    Console.WriteLine(information[0]);
                    message_received = false;
                    break;
            }

            return message_received;
        }
    }
}
