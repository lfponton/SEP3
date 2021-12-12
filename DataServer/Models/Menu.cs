using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DataServer.Models
{
    public class Menu
    {
        public long  MenuId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public IList<MenuItemsSelection> MenuItemsSelections { get; set; } 
        [JsonIgnore]
        public IList<OrderItem> OrderItems { get; set; }


        public Menu()
        {
            MenuItemsSelections = new List<MenuItemsSelection>();
            OrderItems = new List<OrderItem>();
        }

    }
}