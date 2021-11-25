using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DataServer.DataAccess;

namespace DataServer.Network
{
    public class MenusHandler : IRequestHandler
    {
        private IDaoFactory daoFactory;

        private JsonSerializerOptions options;
        private JsonSerializerOptions optionsWithoutConverter;

        public MenusHandler(IDaoFactory daoFactory)
        {
            this.daoFactory = daoFactory;

            options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
            options.Converters.Add(new DateTimeConverter());

            optionsWithoutConverter = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            
        }

        public async Task<string> ProcessClientRequestType(string requestType, string args)
        {
            switch (requestType)
            {
                case "getMenus":
                    return await GetMenus();
                default:
                    return "";
            }
        }

        private async Task<string> GetMenus()
        {
           return JsonSerializer.Serialize(await daoFactory.MenuDao.GetMenusAsync(), options);
        }
    }
}