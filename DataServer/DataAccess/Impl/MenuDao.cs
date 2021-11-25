using System.Collections.Generic;
using System.Threading.Tasks;
using DataServer.Models;
using DataServer.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DataServer.DataAccess.Impl
{
    public class MenuDao : IMenuDao
    {
        private RestaurantDbContext context;

        public MenuDao(RestaurantDbContext context)
        {
            this.context = context;
        }

        public async Task CreateMenuAsync(Menu menu)
        {
            await context.Menus.AddAsync(menu);
            await context.SaveChangesAsync();
        }

        public async Task<List<Menu>> GetMenusAsync()
        {
            return await context.Menus.ToListAsync();
        }
    }
}