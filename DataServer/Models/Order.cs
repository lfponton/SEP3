using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using DataServer.Models;

namespace DataServer.Models
{
    public class Order
    {
        public long OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryTime { get; set; }
        public decimal Price { get; set; }
        [JsonIgnore]
        public IList<OrderItem> OrderItems { get; set; }
        public Customer Customer { get; set; }
        public string Status { get; set; }
        
        public Address DeliveryAddress { get; set; }
        public Order()
        {
            OrderItems = new List<OrderItem>();
        }
        
        // TESTING
        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }

    }
}