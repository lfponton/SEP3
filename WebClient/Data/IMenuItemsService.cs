using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DataServer.Models;

namespace WebClient.Data
{
    public interface IMenuItemsService
    {
        Task<IList<MenuItem>> GetMenuItem(int menuId);
        Task<MenuItem> CreateMenuAsync(MenuItem menuItem);

    }
}