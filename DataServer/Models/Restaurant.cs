using System.Collections.Generic;

namespace DataServer.Models
{
    public class Restaurant
    {
        public long RestaurantId { get; set; }
        public int Capacity { get; set; }
        public List<Table> Tables { get; set; }

        public Restaurant()
        {
            Tables = new List<Table>();
        }
    }
}