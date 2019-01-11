using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console_Server.RabbitMQ;

namespace Console_Server
{
    /// <summary>
    /// This is the class Program.
    /// </summary>
    class Program
    {
        private static Server_Receive receive_message;

        /// <summary>
        /// This method is the starting method for the project Console_Server.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            receive_message = new Server_Receive();
            receive_message.ReceiveMessage(args);
        }
    }
}
