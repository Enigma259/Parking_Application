using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;
using Server.Control;


namespace Server.RabbitMQ.Receiver
{
    /// <summary>
    /// This is the class UserMessage.
    /// </summary>
    public class UserMessage
    {
        private CTR_ParkingStatistics stats;

        /// <summary>
        /// This is the constructor for the class UserMessage.
        /// </summary>
        public UserMessage()
        {
            this.stats = CTR_ParkingStatistics.GetInstance();
        }

        /// <summary>
        /// This message listens to a message qeueue and takes in the messages from a user.
        /// </summary>
        public void ReceiveUserMessage()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "task_queue", durable: true, exclusive: false, autoDelete: false, arguments: null);

                channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

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

                    channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                };
                channel.BasicConsume(queue: "task_queue", autoAck: false, consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();

                stats.NewRequest();
            }
        }
    }
}