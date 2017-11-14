using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BussinesOdyssey_Client.ClientFolder
{
    class Client
    {
        private const int SERVPORT = 1234;
        public string SERVHOST { get; set; } = "localhost";
        private TcpClient client = null;
        private StreamReader ns = null;
        private StreamWriter sw = null;

        public Client()
        {
            Console.WriteLine(connect());
            sendMessage("Hello");
            sendMessage("By by");
        }

        public string connect()
        {
            try
            {
                client = new TcpClient(SERVHOST, SERVPORT);
                ns = new StreamReader(client.GetStream());
                return "connected";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return "";
        }

        public void sendMessage(string message)
        {
            try
            {
                Console.WriteLine("Connected to server......");

                // Send message no 1 to the server 
                sw = new StreamWriter(client.GetStream());
                sw.Write(message);
                sw.Flush();
                Console.WriteLine("Message sent: " + message);
                Console.Read();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
