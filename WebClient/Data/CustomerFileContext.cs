using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Models;
using WebClient.Models;

namespace WebClient.Data {
    public class CustomerFileContext:DbContext {
        public DbSet<Customer> Customers { get; set; }
        
      
    }
}