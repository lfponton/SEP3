using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DataServer.Models
{
    public class MenuItem
    {
        public long MenuItemId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        [JsonIgnore]

        public IList<MenuItemsSelection> MenuItemsSelections
        {
            get;
            set;
        }
        // TESTING
        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }
        


    }
}