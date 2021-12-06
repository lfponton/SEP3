using System.Text.Json;

namespace DataServer.Models
{
    public class Employee : Person
    {
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