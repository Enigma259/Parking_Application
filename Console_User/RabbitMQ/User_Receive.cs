using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Console_User.RabbitMQ
{
    public sealed class User_Receive
    {
        private static volatile User_Receive _instance;
        private static readonly object syncRoot = new object();
        private string host_name;
        private string exchange;
        private string type;
        private bool autoAck;

        /// <summary>
        /// This is the constructor for the class User_Receive.
        /// </summary>
        private User_Receive(string type)
        {
            this.host_name = "localhost - user";
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
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetHostName()
        {
            return host_name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetExchange()
        {
            return exchange;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetRMQType()
        {
            return type;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool GetAutoAck()
        {
            return autoAck;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="host_name"></param>
        public void SetHostName(string host_name)
        {
            this.host_name = host_name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exchange"></param>
        public void SetExchange(string exchange)
        {
            this.exchange = exchange;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        public void SetType(string type)
        {
            this.type = type;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="autoAck"></param>
        public void SetAutoAck(bool autoAck)
        {
            this.autoAck = autoAck;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public void ReceiveMessage(string[] args)
        {
            List<string> information;

            var factory = new ConnectionFactory() { HostName = GetHostName() };
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
        /// 
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
        /// 
        /// </summary>
        /// <param name="information"></param>
        public void PrintMessage(List<string> information)
        {
            switch (information[0])
            {
                case "Nearest Parking Place":

                    Console.WriteLine("parking place name: ");
                    Console.WriteLine(information[1]);
                    Console.WriteLine("Distance: ");
                    Console.WriteLine(information[2]);
                    Console.WriteLine("Location: ");
                    Console.WriteLine(information[3] + ", " + information[4] + ", " + information[5]);
                    break;

                case "Get Location":
                    Console.WriteLine("Location: ");
                    Console.WriteLine(information[1] + ", " + information[2] + ", " + information[3]);
                    break;

                case "Get Request Number":
                    Console.WriteLine("Request number: ");
                    Console.WriteLine(information[1]);
                    break;

                case "Get Average Number":
                    Console.WriteLine("Average number: ");
                    Console.WriteLine(information[1]);
                    break;

                case "Create Reservation":
                    Console.WriteLine("Create Reservation status: ");
                    Console.WriteLine(information[1]);
                    break;

                case "Update Reservation":
                    Console.WriteLine("Update Reservation status: ");
                    Console.WriteLine(information[1]);
                    break;

                case "Delete Reservation":
                    Console.WriteLine("Delete Reservation status: ");
                    Console.WriteLine(information[1]);
                    break;

                default:
                    Console.WriteLine(information[0]);
                    break;
            }
        }
    }
}
