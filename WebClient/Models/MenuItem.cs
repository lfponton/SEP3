using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebClient.Models
{
    public class MenuItem
    {
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public long MenuItemId { get; set; }

        [Required, MaxLength(128)] public string Name { get; set; }
        [DataType(DataType.Currency)] public decimal Price { get; set; }

        public IList<MenuItemsSelection> MenusItemsSelections { get; set; }

        public MenuItem()
        {
            MenusItemsSelections = new List<MenuItemsSelection>();
        }
    }
}