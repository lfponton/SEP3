using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Models;

namespace WebClient.Models
{
    public class Order
    {
        [Range(1, maximum:5, ErrorMessage = "Please enter a value between 1 and 5")]
       public long OrderId { get; set; }
        
       
        public DateTime OrderDateTime { get; set; }
        [DataType(DataType.Date)]
        public DateTime DeliveryTime { get; set; }
        [DataType(DataType.Currency)]
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