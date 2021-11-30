using System.ComponentModel.DataAnnotations;

namespace WebClient.Models
{
    public class OrderItem
    {
        [Range(1, maximum:5, ErrorMessage = "Please enter a value between 1 and 5")]
        public long OrderId { get; set; }
        public Order Order { get; set; }
        public long MenuId { get; set; }
        public Menu Menu { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than 0")]
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        
        public decimal Total { get { return this.Price * this.Quantity; } }

      
    }
    
   
}