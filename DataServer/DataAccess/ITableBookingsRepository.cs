using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataServer.Models;

namespace DataServer.DataAccess
{
    public interface ITableBookingsRepository
    {
        Task<IList<TableBooking>> GetTableBookingsAsync(DateTime bookingDateTime);
    }
}