﻿using System.Threading.Tasks;
using DataServer.Persistence;

namespace DataServer.DataAccess.Impl
{
    public class UnitOfWork : IUnitOfWork
    {
        private RestaurantDbContext context;
        
        private IOrdersRepository ordersRepository;
        private IAccountsRepository accountsRepository;
        private IAddressRepository addressRepository;
        private IMenusRepository menusRepository;
        private IMenuItemsRepository menuItemsRepository;
        private IMenuItemsSelectionsRepository menuItemsSelectionsRepository;
        private ITableBookingsRepository tableBookingsRepository;
        private IRestaurantRepository restaurantRepository;

        public UnitOfWork(RestaurantDbContext context)
        {
            this.context = context;
        }

        public IOrdersRepository OrdersRepository
        {
            get
            {
                if (ordersRepository == null)
                {
                    ordersRepository = new OrdersRepository(context);
                }

                return ordersRepository;
            }
        }

        public IAccountsRepository AccountsRepository { get{
            if (accountsRepository == null)
            {
                accountsRepository = new AccountsRepository(context);
            }

            return accountsRepository;
        } }
        public IAddressRepository AddressRepository { get {
            if (addressRepository == null)
            {
                addressRepository = new AddressRepository(context);
            }

            return addressRepository;
        } }
        public IMenusRepository MenusRepository { get {
            if (menusRepository == null)
            {
                menusRepository = new MenusRepository(context);
            }

            return menusRepository;
        } }
        public IMenuItemsRepository MenuItemsRepository { get {
            if (menuItemsRepository == null)
            {
                menuItemsRepository = new MenuItemsRepository(context);
            }

            return menuItemsRepository;
        } }

        public IMenuItemsSelectionsRepository MenuItemsSelectionsRepository
        {
            get
            {
                if (menuItemsSelectionsRepository == null)
                {
                    menuItemsSelectionsRepository = new MenuItemsSelectionsRepository(context);
                }

                return menuItemsSelectionsRepository;
            }
        }

        public ITableBookingsRepository TableBookingsRepository
        {
            get
            {
                if (tableBookingsRepository == null)
                {
                    tableBookingsRepository = new TableBookingsRepository(context);
                }

                return tableBookingsRepository;
            }
        }

        public IRestaurantRepository RestaurantRepository
        {
            get
            {
                if (restaurantRepository == null)
                {
                    restaurantRepository = new RestaurantRepository(context);
                }

                return restaurantRepository;
            }
        }


        public async Task Save()
        {
            await context.SaveChangesAsync();
        }
    }
}