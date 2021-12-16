using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using DataServer.Network;

namespace DataServer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Server server = new Server(IPAddress.Parse("127.0.0.1"), 2001);
            var serverThread = new Thread(server.Listen);
            serverThread.Start();
            Console.WriteLine($"Server started.");
        }
    }
}