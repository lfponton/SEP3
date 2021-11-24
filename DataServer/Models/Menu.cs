using System.Collections.Generic;

namespace DataServer.Models
{
    public class Menu
    {
        public long  MenuId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public IList<MenuItem> MenuItems { get; set; } 
        
        public IList<OrderItem> OrderItems { get; set; }


        public Menu()
        {
            MenuItems = new List<MenuItem>();
            OrderItems = new List<OrderItem>();
        }

        
    }
}