using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebClient.Models;

namespace WebClient.Data
{
    public interface ITableBookingService
    {
        Task<List<TableBooking>> GetBookings(DateTime bookingDateTime, int people);
        Task<Table> GetTables();
        Task<TableBooking> CreateTableBooking(TableBooking tableBooking);
    }
}