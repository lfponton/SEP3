using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataServer.Models;
using DataServer.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DataServer.DataAccess.Impl
{
    public class MenuItemsSelectionsRepository : IMenuItemsSelectionsRepository
    {
        private RestaurantDbContext context;

        public MenuItemsSelectionsRepository(RestaurantDbContext context)
        {
            this.context = context;
        }
        
        public async Task<List<MenuItemsSelection>> GetMenuItemsSelections(long menuId)
        {
            return await context.MenuItemsSelections.Where(selection => selection.MenuId == menuId)
                .Include(selection => selection.MenuItem).ToListAsync();
        }

        public async Task<MenuItemsSelection> CreateMenuItemsSelectionAsync(MenuItemsSelection menuItemsSelection)
        {
            if (menuItemsSelection.MenuItem != null)
            {
                MenuItem menuItem = await context.MenuItems.FirstOrDefaultAsync(mI => mI.MenuItemId == menuItemsSelection.MenuItem.MenuItemId);
                menuItemsSelection.MenuItem = menuItem;
            }
            await context.MenuItemsSelections.AddAsync(menuItemsSelection);
            return menuItemsSelection;
        }
    }
}