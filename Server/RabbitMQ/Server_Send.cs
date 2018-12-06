using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Server.RabbitMQ
{
    /// <summary>
    /// This is the class Server_Receive.
    /// </summary>
    public class Server_Send
    {
        private string host_name;
        private string queue;
        private string exchange;
        private string routingKey;
        private bool durable;
        private bool exclusive;
        private bool autoDelete;
        private IDictionary<string, object> arguments;

        /// <summary>
        /// This is the constructor for the class Server_Receive.
        /// </summary>
        public Server_Send()
        {
            this.host_name = "localhost - Tasks";
            this.queue = "task_queue";
            this.exchange = "";
            this.routingKey = "task_queue";
            this.durable = true;
            this.exclusive = false;
            this.autoDelete = false;
            this.arguments = null;
        }

        /// <summary>
        /// This method returns the value of the instance host_name.
        /// </summary>
        /// <returns></returns>
        public string GetHostName()
        {
            return host_name;
        }

        /// <summary>
        /// This method returns the value of the instance queue.
        /// </summary>
        /// <returns></returns>
        public string GetQueue()
        {
            return queue;
        }

        /// <summary>
        /// This method returns the value of the instance exchange.
        /// </summary>
        /// <returns></returns>
        public string GetExchange()
        {
            return exchange;
        }

        /// <summary>
        /// This method returns the value of the instance routingKey.
        /// </summary>
        /// <returns></returns>
        public string GetRoutingKey()
        {
            return routingKey;
        }

        /// <summary>
        /// This method returns the value of the instance durable.
        /// </summary>
        /// <returns></returns>
        public bool GetDurable()
        {
            return durable;
        }

        /// <summary>
        /// This method returns the value of the instance exclusive.
        /// </summary>
        /// <returns></returns>
        public bool GetExclusive()
        {
            return exclusive;
        }

        /// <summary>
        /// This method returns the value of the instance autoDelete.
        /// </summary>
        /// <returns></returns>
        public bool GetAutoDelete()
        {
            return autoDelete;
        }

        /// <summary>
        /// This method returns the value of the instance arguments.
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, object> GetArguments()
        {
            return arguments;
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
        /// This method changes the value of the instance queue.
        /// </summary>
        /// <param name="queue"></param>
        public void SetQueue(string queue)
        {
            this.queue = queue;
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
        /// This method changes the value of the instance routingKey.
        /// </summary>
        /// <param name="routingKey"></param>
        public void SetRoutingKey(string routingKey)
        {
            this.routingKey = routingKey;
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
        /// This method Sends results to a user.
        /// </summary>
        /// <param name="args"></param>
        public void SendTask(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = GetHostName() };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: GetQueue(), durable: GetDurable(), exclusive: GetDurable(), autoDelete: GetAutoDelete(), arguments: GetArguments());

                var message = GetMessage(args);
                var body = Encoding.UTF8.GetBytes(message);

                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;

                channel.BasicPublish(exchange: GetExchange(), routingKey: GetRoutingKey(), basicProperties: properties, body: body);
                Console.WriteLine(" [x] Sent {0}", message);
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }

        /// <summary>
        /// This method gets the message from the command line argument.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private string GetMessage(string[] args)
        {
            return ((args.Length > 0) ? string.Join(" ", args) : "Hello World!");
        }
    }
}