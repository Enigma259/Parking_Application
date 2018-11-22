using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;
using Server.Model;


namespace Server.RabbitMQ.Receiver
{
    /// <summary>
    /// This is the class UserMessage.
    /// </summary>
    public class UserMessage
    {
        private ParkingStatistics statistics;

        /// <summary>
        /// This is the constructor for the class UserMessage.
        /// </summary>
        public UserMessage()
        {
            this.statistics = ParkingStatistics.GetInstance();
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

                statistics.PSRNumberIncrease();
            }
        }
    }
}