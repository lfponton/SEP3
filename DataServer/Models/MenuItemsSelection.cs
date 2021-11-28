using System.Text.Json;
using System.Text.Json.Serialization;

namespace DataServer.Models
{
    public class MenuItemsSelection
    {
        public long MenuId { get; set; }
        [JsonIgnore]
        public Menu Menu { get; set; }
        public long MenuItemId { get; set; }
        [JsonIgnore]
        public MenuItem MenuItem { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
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