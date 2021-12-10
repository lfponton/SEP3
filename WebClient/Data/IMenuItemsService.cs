using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using WebClient.Models;

namespace WebClient.Data
{
    public interface IMenuItemsService
    {
        Task<IList<MenuItem>> GetMenuItems(int menuId);
        Task<MenuItem> CreateMenuItemAsync(MenuItem menuItem);

    }
}