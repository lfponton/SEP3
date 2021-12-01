using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DataServer.DataAccess;

namespace DataServer.Network
{
    public class ServerHandler
    {
        private TcpClient client;

        private StreamWriter writer;
        private StreamReader reader;

        private bool clientConnected;
        
        public ServerHandler(TcpClient client)
        {
            this.client = client;

            NetworkStream stream = client.GetStream();
            writer = new StreamWriter(stream, Encoding.ASCII){AutoFlush = true};
            reader = new StreamReader(stream, Encoding.ASCII);

        }

        public async Task Start()
        {
            clientConnected = true;
            Console.WriteLine("Server Handler started");
            do
            {
                try
                {
                    // What type of service is it?
                    var serviceType = await reader.ReadLineAsync();

                    IRequestHandler handler = GetRequestHandler(serviceType);
                    // What type of request is it?
                    var requestType = await reader.ReadLineAsync();
                    
                    // Any additional arguments?

                    var args = await reader.ReadLineAsync();
                    
                    // Process request
                    string jsonObject = await handler.ProcessClientRequestType(requestType, args);
                    
                    // Send reply to client
                    await writer.WriteLineAsync(jsonObject);
                
                }
                catch (IOException e)
                {
                    clientConnected = false;
                    Console.WriteLine($"IOException: {e}" );
                }
            } while (clientConnected);
            client.Close();
        }

        private IRequestHandler GetRequestHandler(string requestType)
        {
            switch (requestType)
            {
                case "Orders":
                    return new OrdersHandler();
                case "Menus":
                    return new MenusHandler();
                case "MenuItems":
                    return new MenuItemsHandler();
                case "MenuItemsSelections":
                    return new MenuItemsSelectionsHandler();
                case "Bookings":
                    return new TableBookingsHandler();
                default:
                    return null;
            }
        }
        
    }
}