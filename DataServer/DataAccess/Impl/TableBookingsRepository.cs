using System.Collections.Generic;
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
        public async  Task<IList<TableBooking>> GetTableBookingsAsync()
        {
            return await context.TableBookings.Include(tb => tb.Table).ToListAsync();
        }
    }
}