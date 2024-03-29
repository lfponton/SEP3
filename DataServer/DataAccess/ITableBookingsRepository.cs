﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataServer.Models;

namespace DataServer.DataAccess
{
    public interface ITableBookingsRepository
    {
        Task<IList<TableBooking>> GetTableBookingsAsync(DateTime bookingDateTime);
        Task<TableBooking> UpdateTableBookingAsync(TableBooking tableBooking);
        Task<TableBooking> CreateTableBookingAsync(TableBooking tableBooking);
        Task<TableBooking> GetBookingByIdAsync(long tableBookingId);
    }
}