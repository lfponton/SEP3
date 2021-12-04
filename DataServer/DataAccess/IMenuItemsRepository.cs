using System.Collections.Generic;
using System.Threading.Tasks;
using DataServer.Models;

namespace DataServer.DataAccess
{
    public interface IMenuItemsRepository
    {
        Task<MenuItem> CreateMenuItemAsync(MenuItem menuItem);

        Task<List<MenuItem>> ReadMenuItemsAsync(int menuId);

        Task DeleteMenuItemAsync(long menuItemsId);
    }
}