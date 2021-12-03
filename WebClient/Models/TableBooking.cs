using System;
using System.Text.Json.Serialization;

namespace WebClient.Models
{
    public class TableBooking
    {
        
        public long TableBookingId { get; set; }
        public int People { get; set; }
        public string Description { get; set; }
        public Table Table { get; set; }
        [JsonInclude]
        public Customer? Customer { get; set; }
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