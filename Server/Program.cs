using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server;
            while (true)
            {
                Console.WriteLine("\nEnter valid IP");
                var ip = Console.ReadLine();
                Console.WriteLine("\nEnter valid port number");
                var port = Console.ReadLine();

                if (ip == "" && port == "") // default values
                {
                    ip = "127.0.0.1";
                    port = "8910";
                }

                try
                {
                    server = new Server(ip, int.Parse(port), "mamlasDB");
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid IP or port number");
                }
            }

            try
            {
                server.Begin();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            while (true)
            {
                Console.WriteLine("Enter 'exit' to stop the server.");
                if (Console.ReadLine() == "exit")
                {
                    server.Exit();
                    break;
                }
            }
        }
    }
}
