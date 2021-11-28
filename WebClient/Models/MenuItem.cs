using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic.CompilerServices;

namespace WebClient.Models
{
    public class MenuItem
    {
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int MenuItemId { get; set; }
        
        [Required, MaxLength(128)] 
        public string Name { get; set; }
        
        public decimal Price { get; set; }
        
        public IList<MenuItemsSelection> MenusItemsSelections { get; set; }
    }
}