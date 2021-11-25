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
        
        public Task<List<MenuItemsSelection>> GetMenuItemsSelections(long menuId)
        {
            return context.MenuItemsSelections.Where(selection => selection.MenuId == menuId)
                .Include(selection => selection.MenuItem).ToListAsync();
        }
    }
}