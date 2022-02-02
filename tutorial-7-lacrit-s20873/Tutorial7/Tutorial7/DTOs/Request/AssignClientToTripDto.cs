using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Tutorial7.DTOs.Request
{
    public class AssignClientToTripDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Telephone { get; set; }
        [Required]
        public string Pesel { get; set; }
        [Required]
        public int IdTrip { get; set; }
        [Required]
        public string TripName { get; set; }
        public DateTime? PaymentDate { get; set; }


    }
}
