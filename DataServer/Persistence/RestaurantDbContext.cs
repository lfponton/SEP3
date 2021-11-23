using System;
using DataServer.Models;
using DataServer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataServer.Persistence
{
    public class RestaurantDbContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<DeliveryDriver> DeliveryDrivers { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<StaffMember> StaffMembers { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<TableBooking> TableBookings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Change this to the path in your system
            optionsBuilder
                .UseNpgsql(
                    "Host=abul.db.elephantsql.com;Port=5432;Database=wdrfaqaw;Username=wdrfaqaw;Password=J2znMlw_7mZqYQQNJhVZQscdQHJLxFop;Pooling=false;Timeout=300;CommandTimeout=300;;"
                    );
            
            // ElephantSQL Connection String: "Host=abul.db.elephantsql.com;Port=5432;Database=pdkfscsn;Username=pdkfscsn;Password=xmosZfgxDtcqhD9YxxovvWuQ4DJTyKtH;Pooling=false;Timeout=300;CommandTimeout=300;"
        }


}
}