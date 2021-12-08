using System.Collections.Generic;

namespace DataServer.Models
{
    public class Restaurant
    {
        public int Capacity { get; set; }
        public List<Table> Tables { get; set; }

    }
}