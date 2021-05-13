using HotelListing.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Models
{
    public class CreateHotelsDTO
    {
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = " Name is too long")]
        public String Name { get; set; }

        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "Address Name is too long")]
        public String Address { get; set; }
        [Required]
        [Range(1,5)]
        public int Rating { get; set; }
        public int CountryId { get; set; }
    
    }
    public class HotelDTO : CreateHotelsDTO
    {
        public int Id { get; set; }
        public CountryDTO Country { get; set; }
    }
}
