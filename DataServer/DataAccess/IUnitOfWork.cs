﻿using System.Threading.Tasks;

namespace DataServer.DataAccess.Impl
{
    public interface IUnitOfWork
    {
        IOrdersRepository OrdersRepository { get; }
        IAccountsRepository AccountsRepository { get; }
        IAddressRepository AddressRepository { get; }
        IMenusRepository MenusRepository { get; }
        IMenuItemsRepository MenuItemsRepository { get; }
        IOrderItemsRepository OrderItemsRepository { get; }
        Task Save();

    }
}