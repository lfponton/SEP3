using System.ComponentModel.DataAnnotations;

namespace WebClient.Models
{
    public class DeliveryAddress
    {
        public int DeliveryAddressId { get; set; }

        [Required, MaxLength(30)] public string City { get; set; }
        [Required, MaxLength(30)] public string StreetName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than 0")]
        public string PostNumber { get; set; }

        [Required, MaxLength(10)] public string AddressNumber { get; set; }
        [Required, MaxLength(10)] public string Door { get; set; }


        public override string ToString()
        {
            return $"{StreetName} {AddressNumber} {Door}, {PostNumber} {City}";
        }
    }
}