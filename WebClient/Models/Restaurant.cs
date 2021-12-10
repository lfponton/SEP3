using System.Collections.Generic;

namespace WebClient.Models
{
    public class Restaurant
    {
      
            public long RestaurantId { get; set; }
            public int Capacity { get; set; }
            public List<Table> Tables { get; set; }

        
    }
}