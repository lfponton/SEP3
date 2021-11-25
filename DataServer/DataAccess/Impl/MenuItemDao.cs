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

        public async Task CreateMenuItemAsync(MenuItem menuItem)
        {
            await context.MenuItems.AddAsync(menuItem);
        }

        public async Task<List<MenuItem>> ReadMenuItemsAsync(int menuId)
        {
            return await context.MenuItems.Where(item => item.Menus.Any(menu => menu.MenuId == menuId)).ToListAsync();
        }
    }
}