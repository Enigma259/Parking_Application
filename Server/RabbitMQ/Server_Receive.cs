using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Server.Control;
using Server.Database;

namespace Server.RabbitMQ
{
    /// <summary>
    /// This is the class Server_Receive.
    /// </summary>
    public class Server_Receive
    {
        private string host_name;
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

        private CTR_ParkingStatistics ctr_stats;

        /// <summary>
        /// this is the constructor for the class Server_Receive.
        /// </summary>
        public Server_Receive()
        {
            this.host_name = "localhost - Tasks";
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

            this.ctr_stats = CTR_ParkingStatistics.GetInstance();
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
            var factory = new ConnectionFactory() { HostName = GetHostName() };
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

                    channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: GetMultiple());
                    ctr_stats.NewRequest();
                };
                channel.BasicConsume(queue: "task_queue", autoAck: GetAutoAck(), consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }
    }
}