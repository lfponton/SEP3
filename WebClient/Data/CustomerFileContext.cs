using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Models;
using WebClient.Models;

namespace WebClient.Data {
    public class CustomerFileContext {
        private const string customersFile = "Data/customer.json";
        public IList<Customer> Customers { get; private set; }
        
        public CustomerFileContext() {
            if (!File.Exists(customersFile)) {
                Seed();
                WriteCustomersToFile();
            }
            else {
                string content = File.ReadAllText(customersFile);
                Customers = JsonSerializer.Deserialize<List<Customer>>(content);
            }
        }

        private void Seed() {
            Customers = new List<Customer>();
            Customers.Add(new Customer() {
                Email = "Admin",
                Password = "1234",
                Role = Role.Admin
            });
        }
        
        public void WriteCustomersToFile() {
            string customersAsJson = JsonSerializer.Serialize(Customers, new JsonSerializerOptions() {
                WriteIndented = true
            });
            File.WriteAllText(customersFile, customersAsJson);
        }
    }
}