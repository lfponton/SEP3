using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace WebClient.Models
{
    public class OrderItem
    {
        public long OrderId;
        public Order Order { get; set; }
        public long MenuId { get; set; }
        public Menu Menu { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than 0")]
        public int Quantity { get; set; }

        [DataType(DataType.Currency)] 
        public decimal Price { get; set; }
    }
}