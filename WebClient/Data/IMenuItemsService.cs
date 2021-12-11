using System.Collections.Generic;
using System.Threading.Tasks;
using WebClient.Models;

namespace WebClient.Data
{
    public interface IMenuItemsService
    {
        Task<IList<MenuItem>> GetMenuItemsAsync(int menuId);
        Task<MenuItem> CreateMenuItemAsync(MenuItem menuItem);
    }
}