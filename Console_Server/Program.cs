using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console_Server.RabbitMQ;

namespace Console_Server
{
    class Program
    {
        private static Server_Receive receive_message;

        static void Main(string[] args)
        {
            receive_message = new Server_Receive();
            receive_message.ReceiveMessage(args);
        }
    }
}
