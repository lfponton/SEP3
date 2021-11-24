using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebClient.Models
{
    public class DeliveryAddress
    {
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than 0")]
        public int DeliveryAddressId { get; set; }

        [Required, MaxLength(30)] 
        public string City { get; set; }
        [Required]
        public string StreetName { get; set; }
        
        [Required]
        public string PostNumber { get; set; }
        [Required]
        public string AddressNumber { get; set; }
        [Required]
        public string Door { get; set; }
        


    }
    

}