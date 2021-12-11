using System.ComponentModel.DataAnnotations;

namespace WebClient.Models
{
    public class MenuItemsSelection
    {
        public long MenuId { get; set; }
        public Menu Menu { get; set; }
        public long MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; }
        public int Quantity { get; set; }
        [DataType(DataType.Currency)] 
        public decimal Price { get; set; }
    }
}