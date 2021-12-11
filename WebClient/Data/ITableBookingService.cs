using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebClient.Models;

namespace WebClient.Data
{
    public interface ITableBookingService
    {
        Task<List<TableBooking>> GetBookingsAsync(DateTime bookingDateTime);
        Task<TableBooking> CreateTableBookingAsync(TableBooking tableBooking);
        Task<TableBooking> UpdateTableBookingAsync(TableBooking tableBooking);
        Task<TableBooking> GetBookingByIdAsync(long tableBookingId);
    }
}