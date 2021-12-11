using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebClient.Models
{
    public class Menu
    {
        public int MenuId { get; set; }
        [Required] public string Name { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
        [DataType(DataType.Currency)] public decimal Price { get; set; }
        public string Description { get; set; }
        public IList<MenuItemsSelection> MenusItemsSelections { get; set; }

        public Menu()
        {
            MenusItemsSelections = new List<MenuItemsSelection>();
        }
    }
}