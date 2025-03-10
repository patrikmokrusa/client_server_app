using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Server.DataAccess;

namespace Server
{
    class Server
    {
        private TcpListener _listener;
        private bool _running;
        private fileDB _database;
        private Thread _thread;

        public Server(string ip, int port, string db_name)
        {
            // Create a new server
            _listener = new TcpListener(IPAddress.Parse(ip), port);
            _running = false;
            // restore from db
            _database = new fileDB(db_name);

        }

        public void Begin()
        {
            _thread = new Thread(new ThreadStart(Start));
            _thread.Start();
            
        }

        public void Exit()
        {
            _running = false;
            _listener.Stop();
            _thread.Abort();
        }

        private void Start()
        {
            // Start the server
            Console.WriteLine("Starting server");
            _running = true;
            _listener.Start();

            while (_running)
            {
                Console.WriteLine("Waiting for client");
                TcpClient client = _listener.AcceptTcpClient();
                Console.WriteLine("Client connected");
                HandleClient(client);
                client.Close();
            }

            _listener.Stop();

        }

        private void HandleClient(TcpClient client)
        {
            Console.WriteLine("Handling request");
            StreamReader reader = new StreamReader(client.GetStream(), Encoding.ASCII);

            string request = "";
            while (reader.Peek() != -1)
            {
                request += reader.ReadLine() + "\n";
            }

            Console.WriteLine("Received:\n" + request);

            // Handle request
            string response_msg = HandleRequest(request);

            Respond(client.GetStream(), response_msg);
            


        }

        private string HandleRequest(string request)
        {
            var tokens = request.Split(' ');
            if (tokens.Length < 2)
            {
                return "Invalid request";
            }
            
            if (tokens[0] == "GET")
            {
                return _database.Get(tokens[1]);
            }
            else if (tokens[0] == "EDIT")
            {
                return _database.Edit(tokens[1], tokens[2], tokens[3]);
            }
            else if (tokens[0] == "DELETE")
            {
                return _database.Delete(tokens[1]);
            }
            else if (tokens[0] == "ADD")
            {
                return _database.Add(tokens[2], tokens[3]);
            }
            else if (tokens[0] == "GETALL")
            {
                return _database.GetAll();
            }
            else
            {
                return "Invalid request";
            }
        }

        private void Respond(NetworkStream stream, string str_data)
        {
            StreamWriter writer = new StreamWriter(stream, Encoding.ASCII) { AutoFlush = true };
            writer.WriteLine(str_data);
        }
    }
}
