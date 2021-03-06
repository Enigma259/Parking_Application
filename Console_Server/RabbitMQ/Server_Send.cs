﻿using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Console_Server.RabbitMQ
{
    /// <summary>
    /// This is the class Server_Receive.
    /// </summary>
    public class Server_Send
    {
        private string host_name;
        private string user;
        private string password;
        private string virtuel_host;
        private string excahnge;
        private string type;
        private string message;

        /// <summary>
        /// This is the contructor for the class Server_Send.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        public Server_Send(string type, string message)
        {
            this.host_name = "localhost - User";
            this.user = "serverUser";
            this.password = "123456789";
            this.virtuel_host = "/";
            this.excahnge = "direct_logs";
            this.type = type;
            this.message = message;
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
        /// This method returns the value of the instance excahnge.
        /// </summary>
        /// <returns></returns>
        public string GetExcahnge()
        {
            return excahnge;
        }

        /// <summary>
        /// This method returns the value of the instance type.
        /// </summary>
        /// <returns></returns>
        public string GetRMQType()
        {
            return type;
        }

        /// <summary>
        /// This method returns the value of the instance message.
        /// </summary>
        /// <returns></returns>
        public string GetMessage()
        {
            return message;
        }

        /// <summary>
        /// This method changes the value of the instance host_name.
        /// </summary>
        /// <param name="host_name"></param>
        public void SethostName(string host_name)
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
        /// This method changes the value of the instance excahnge.
        /// </summary>
        /// <param name="excahnge"></param>
        public void SetExcahnge(string excahnge)
        {
            this.excahnge = excahnge;
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
        /// This method changes the value of the instance message.
        /// </summary>
        /// <param name="message"></param>
        public void SetMessage(string message)
        {
            this.message = message;
        }

        /// <summary>
        /// This method sends the result from the server to a specific user.
        /// </summary>
        /// <param name="args"></param>
        public void SendMessage(string[] args)
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
                channel.ExchangeDeclare(exchange: GetExcahnge(), type: GetRMQType());

                var severity = (args.Length > 0) ? args[0] : "info";
                var message = (args.Length > 1) ? string.Join(" ", args.Skip(1).ToArray()) : GetMessage();
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchange: GetExcahnge(), routingKey: severity, basicProperties: null, body: body);
                Console.WriteLine(" [x] Sent '{0}':'{1}'", severity, message);
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}