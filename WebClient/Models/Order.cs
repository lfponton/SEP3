using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Models;

namespace WebClient.Models
{
    public class Order
    {
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than 0")]
        public long OrderId { get; set; }
        
        [Required]
        public DateTime OrderDateTime { get; set; }
        public DateTime DeliveryTime { get; set; }
        public decimal Price { get; set; }
        public IList<OrderItem> OrderItems { get; set; } 
        public Customer Customer { get; set; }
        public string Status { get; set; }
        public bool IsDelivery { get; set; }
        
        public DeliveryAddress DeliveryAddress{ get; set; }

        public Order()
        {
            OrderItems = new List<OrderItem>();
        }
    }
}