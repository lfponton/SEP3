using System.Collections.Generic;
using System.Threading.Tasks;
using DataServer.Models;

namespace DataServer.DataAccess
{
    public interface IMenuItemsSelectionsRepository
    {
        Task<List<MenuItemsSelection>> GetMenuItemsSelections(long menuId);
        
        Task<MenuItemsSelection> CreateMenuItemsSelectionAsync(MenuItemsSelection menuItemsSelection);
    }
}