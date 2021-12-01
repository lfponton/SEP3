using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebClient.Models;

namespace WebClient.Data
{
    public interface ITableBookingService
    {
        Task<List<TableBooking>> GetBookings(DateTime bookingDateTime);
        Task<Table> GetTables();
        Task<TableBooking> CreateTableBooking(TableBooking tableBooking);
        Task<TableBooking> UpdateTableBooking(TableBooking tableBooking);
    }
}