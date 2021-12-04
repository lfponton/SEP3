using System.Collections.Generic;

namespace WebClient.Models
{
    public class Table
    {
        public int TableId { get; set; }
        public int Capacity { get; set; }
        public bool IsBooked { get; set; }
        public List<TableBooking> TableBookings { get; set; }
    }
}