using System;
using System.Collections.Generic;
using Models;

namespace WebClient.Models
{
    public class Order
    {
        public long OrderId { get; set; }
        public DateTime OrderDateTime { get; set; }
        public DateTime DeliveryTime { get; set; }
        public decimal Price { get; set; }
        public IList<OrderItem> OrderItems { get; set; } 
        public Customer Customer { get; set; }
        public string Status { get; set; }
        
        public DeliveryAddress DeliveryAddress{ get; set; }

        public Order()
        {
            OrderItems = new List<OrderItem>();
        }
    }
}