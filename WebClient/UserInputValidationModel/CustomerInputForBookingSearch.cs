using System;
using System.ComponentModel.DataAnnotations;

namespace WebClient.UserInputValidationModel
{
    public class CustomerInputForBookingSearch
    {
        [Required]
        [Range(1, 20, ErrorMessage = "Please, for reservations bigger than 20 guests, contact us")]
        public int People { get; set; }
        [Required]
       
        public DateTime BookingDateTime { get; set; }
        
        
    }
}