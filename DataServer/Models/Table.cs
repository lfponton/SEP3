using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DataServer.Models
{
    public class Table
    {
        public int TableId { get; set; }
        public int Capacity { get; set; }
        [JsonIgnore]
        public List<TableBooking> TableBookings { get; set; }
    }
}