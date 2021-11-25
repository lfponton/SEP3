using System.Collections.Generic;
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


    }
}