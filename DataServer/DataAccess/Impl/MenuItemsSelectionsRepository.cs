using System.Collections.Generic;
using System.Threading.Tasks;
using DataServer.Models;
using DataServer.Persistence;

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
            throw new System.NotImplementedException();
        }
    }
}