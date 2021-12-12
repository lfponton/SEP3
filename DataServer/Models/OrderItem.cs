using System.Text.Json.Serialization;

namespace DataServer.Models
{
    public class OrderItem
    {
        public long OrderId { get; set; }
        [JsonIgnore]
        public Order Order { get; set; }
        public long MenuId { get; set; }
        public Menu Menu { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

    }
}