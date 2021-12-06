using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using COFRS;

namespace WebClient.Models
{
    public class TableBooking
    {
        
        public long TableBookingId { get; set; }
        [Required]
        [Range(1, 20, ErrorMessage = "Please, for reservations bigger than 20 guests, contact us")]
        public int People { get; set; }
        public string Description { get; set; }
        public Table Table { get; set; }
        [JsonInclude]
        public Customer? Customer { get; set; }
         [JsonFormat("yyyy-MM-dd'T'HH:mm:ss.SSSX")]
        public DateTime BookingDateTime { get; set; }
        [JsonIgnore]
        public bool IsSelected { get; set; }

        public TableBooking()
        {
            Table = new Table();
            Customer = new Customer();
        }
        
        
    }
}