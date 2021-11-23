namespace WebClient.Models
{
    public class OrderItem
    {
        public long OrderItemId { get; set; }
        public Order Order { get; set; }
        public Menu Menu { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

      
    }
}