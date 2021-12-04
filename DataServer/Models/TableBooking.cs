using System;

namespace DataServer.Models
{
    public class  TableBooking
    {
        public long TableBookingId { get; set; }
        public int People { get; set; }
        public string Description { get; set; }
        public Table Table { get; set; }
        public Customer Customer { get; set; }
        public DateTime BookingDateTime { get; set; }

       
    }
}