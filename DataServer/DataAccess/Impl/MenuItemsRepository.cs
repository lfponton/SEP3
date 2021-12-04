using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataServer.Models;
using DataServer.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DataServer.DataAccess.Impl
{
    public class MenuItemsRepository : IMenuItemsRepository
    {
        private RestaurantDbContext context;

        public MenuItemsRepository(RestaurantDbContext context)
        {
            this.context = context;
        }

        public async Task<MenuItem> CreateMenuItemAsync(MenuItem menuItem)
        {
            var menuItemToUpdate = await context.MenuItems
                .Include(Menuitem => menuItem.MenuItemId)
                .FirstAsync(MenuItem => MenuItem.MenuItemId == menuItem.MenuItemId);
            menuItemToUpdate.Name = menuItem.Name;
            menuItemToUpdate.Price = menuItem.Price;
            context.Update(menuItemToUpdate);
            return menuItemToUpdate;
        }

        public async Task<List<MenuItem>> ReadMenuItemsAsync(int menuId)
        {
            List<MenuItemsSelection> selection = await context.MenuItemsSelections
                .Where(selection => selection.MenuId == menuId).Include(selection => selection.MenuItem).ToListAsync();
            List<MenuItem> menuItems = new List<MenuItem>();
            foreach (var s in selection)
            {
                menuItems.Add(s.MenuItem);
            }

            return menuItems;
        }

        public async Task DeleteMenuItemAsync(long menuItemsId)
        {
            MenuItem toRemove =
                await context.MenuItems.FirstOrDefaultAsync(MenuItem => MenuItem.MenuItemId == menuItemsId);
            if (toRemove != null)
            {
                context.MenuItems.Remove(toRemove);
                await context.SaveChangesAsync();
            }
        }
    }
}