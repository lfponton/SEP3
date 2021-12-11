using System.Collections.Generic;
using System.Threading.Tasks;
using WebClient.Models;

namespace WebClient.Data
{
    public interface IMenuItemsSelectionsService
    {
        Task<IList<MenuItemsSelection>> GetMenuItemsSelectionsAsync(long menuId);
    }
}