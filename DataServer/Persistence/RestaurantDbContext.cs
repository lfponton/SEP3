using DataServer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataServer.Persistence
{
    public class RestaurantDbContext : DbContext
    {
        public DbSet<DeliveryAddress> Addresses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<DeliveryDriver> DeliveryDrivers { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<TableBooking> TableBookings { get; set; }
        public DbSet<MenuItemsSelection> MenuItemsSelections { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Change this to the path in your system
            optionsBuilder
                .UseNpgsql(
                    "Host=abul.db.elephantsql.com;Port=5432;Database=grkhhafd;Username=grkhhafd;Password=EP1QkE5cKtGtGTn9lI4A9vMMJDqNz3uB;Pooling=false;Timeout=300;CommandTimeout=300;;"
                );

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuItemsSelection>().HasKey(selection => new { selection.MenuId, selection.MenuItemId });
        }
    }
}