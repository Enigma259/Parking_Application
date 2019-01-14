using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Console_User.RabbitMQ
{
    /// <summary>
    /// This is the class User_Send.
    /// </summary>
    public class User_Send
    {
        private static volatile User_Send _instance;
        private static readonly object syncRoot = new object();
        private string host_name;
        private string user;
        private string password;
        private string virtuel_host;
        private string queue;
        private bool durable;
        private bool exclusive;
        private bool auto_delete;
        private IDictionary<string, object> arguments;
        private string message;
        private bool persistent;
        private string exchange;
        private string routing_key;

        /// <summary>
        /// This is the constructor for the class User_Send.
        /// </summary>
        private User_Send(string message)
        {
            this.host_name = "localhost - tasks";
            this.user = "serverUser";
            this.password = "123456789";
            this.virtuel_host = "/";
            this.queue = "task_queue";
            this.durable = true;
            this.exclusive = false;
            this.auto_delete = false;
            this.arguments = null;
            this.message = "Hello World";
            this.persistent = true;
            this.exchange = "";
            this.routing_key = "task_queue";
        }

        /// <summary>
        /// This is a multi threaded singleton for the class User_Send.
        /// </summary>
        /// <returns>_instance</returns>
        public static User_Send GetInstance(string message)
        {
            if (_instance == null)
            {
                lock (syncRoot)
                {
                    if (_instance == null)
                    {
                        _instance = new User_Send(message);
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
        /// This method returns the value of the instance auto_delete.
        /// </summary>
        /// <returns>bool</returns>
        public bool GetAutoDelete()
        {
            return auto_delete;
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
        /// This method returns the value of the instance message.
        /// </summary>
        /// <returns>string</returns>
        public string GetMessage()
        {
            return message;
        }

        /// <summary>
        /// This method returns the value of the instance persistent.
        /// </summary>
        /// <returns>bool</returns>
        public bool GetPersistent()
        {
            return persistent;
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
        /// This method returns the value of the instance routing_key.
        /// </summary>
        /// <returns>string</returns>
        public string GetRoutingKey()
        {
            return routing_key;
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
        /// This method changes the value of the instance auto_delete.
        /// </summary>
        /// <param name="auto_delete"></param>
        public void SetAutoDelete(bool auto_delete)
        {
            this.auto_delete = auto_delete;
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
        /// This method changes the value of the instance message.
        /// </summary>
        /// <param name="message"></param>
        public void SetMessage(string message)
        {
            this.message = message;
        }

        /// <summary>
        /// This method changes the value of the instance persistent.
        /// </summary>
        /// <param name="persistent"></param>
        public void SetPersistent(bool persistent)
        {
            this.persistent = persistent;
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
        /// This method changes the value of the instance routing_key.
        /// </summary>
        /// <param name="routing_key"></param>
        public void SetRoutingKey(string routing_key)
        {
            this.routing_key = routing_key;
        }

        /// <summary>
        /// This method sends a message to the server by RabbitMQ.
        /// </summary>
        /// <param name="args"></param>
        public void NewTask(string[] args)
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

                var message = GetMessage_RabbitMQ(args);
                var body = Encoding.UTF8.GetBytes(message);

                var properties = channel.CreateBasicProperties();
                properties.Persistent = GetPersistent();

                channel.BasicPublish(exchange: GetExchange(), routingKey: GetRoutingKey(), basicProperties: properties, body: body);
                Console.WriteLine(" [x] Sent {0}", message);
            }

        }

        /// <summary>
        /// This method returns a message ready for RabbitMQ.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private string GetMessage_RabbitMQ(string[] args)
        {
            return ((args.Length > 0) ? string.Join(" ", args) : GetMessage());
        }
    }
}
