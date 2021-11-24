using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebClient.Models
{
    public class Menu
    {
        
        public int MenuId { get; set; }
        [Required]
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
        
        //For Testing
        public override string ToString()
        {
            return $"{MenuId},{Name},{Type},{Price}";
        }
    }
}