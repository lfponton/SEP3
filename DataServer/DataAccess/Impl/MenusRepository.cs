﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataServer.Models;
using DataServer.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DataServer.DataAccess.Impl
{
    public class MenusRepository : IMenusRepository
    {
        private RestaurantDbContext context;

        public MenusRepository(RestaurantDbContext context)
        {
            this.context = context;
        }

        public async Task<Menu> CreateMenuAsync(Menu menu)
        {
            await context.Menus.AddAsync(menu);
            return menu;
        }

        public async Task<List<Menu>> GetMenusAsync()
        {
            return await context.Menus.Include(menu => menu.MenuItemsSelections)
                .ThenInclude(selection => selection.MenuItem)
                .ToListAsync();
        }

        public async Task DeleteMenuAsync(Menu menu)
        {
            Menu toRemove = await context.Menus.FirstOrDefaultAsync(menu => menu.MenuId == menu.MenuId);

            if (toRemove != null)
            {
                context.Menus.Remove(toRemove);
                await context.SaveChangesAsync();
            }
        }

    
    }
}