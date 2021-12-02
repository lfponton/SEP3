using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataServer.Models;
using DataServer.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DataServer.DataAccess.Impl
{
    public class TableBookingsRepository:ITableBookingsRepository
    {
        private RestaurantDbContext context;

        public TableBookingsRepository(RestaurantDbContext context)
        {
            this.context = context;
        }
        public async  Task<IList<TableBooking>> GetTableBookingsAsync(DateTime bookingDateTime)
        {
            
            return await context.TableBookings.Include(tb => tb.Table)
                .Include(tb=>tb.Customer)
                .Where(tb=>tb.BookingDateTime.Date == bookingDateTime).ToListAsync();
        }

        public async Task<TableBooking> UpdateTableBookingAsync(TableBooking tableBooking)
        {
            var toUpdate = await context.TableBookings
                .Include(tb => tb.Table)
                .FirstAsync(tb => tb.TableBookingId == tableBooking.TableBookingId);
            toUpdate.Customer = tableBooking.Customer;
            toUpdate.Description = tableBooking.Description;
            toUpdate.People = tableBooking.People;
            context.Update(toUpdate);
            return toUpdate;

        }

        public async Task<TableBooking> CreateTableBookingAsync(TableBooking tableBooking)
        {
            var tableToUpdate = await context.Tables
                .Include(t=>t.TableBookings)
                .FirstAsync(t => t.TableId == tableBooking.Table.TableId);
            tableToUpdate.TableBookings.Add(tableBooking);
            context.Update(tableToUpdate);
            return tableBooking;
        }
    }
}