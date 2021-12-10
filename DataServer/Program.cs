using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using DataServer.Models;
using DataServer.DataAccess;
using DataServer.DataAccess.Impl;
using DataServer.Network;
using DataServer.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DataServer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //DataSeeder seeder = new DataSeeder();
            //await seeder.Seed();
            //await seeder.SeedPendingOrders();
            //await seeder.SeedNumberOfCustomerOrdersByStatus(9, "completed");
            Server server = new Server(IPAddress.Parse("127.0.0.1"), 2001);
            var serverThread = new Thread(server.Listen);
            serverThread.Start();
            Console.WriteLine($"Server started.");
        }
    }
}