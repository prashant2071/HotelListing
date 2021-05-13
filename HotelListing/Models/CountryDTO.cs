using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Models
{
    public class CreateCountryDTO
    {
        [Required]
        [StringLength(maximumLength:50,ErrorMessage ="Country Name is too long")]
        public String Name { get; set; }
        [Required]
        [StringLength(maximumLength: 3, ErrorMessage = "Country Name is too long")]
        [DisplayName("Short Name")]
        public String ShortName { get; set; }
    }
    public class CountryDTO : CreateCountryDTO
    {
        public int Id { get; set; }
        public IList<HotelDTO> Hotels { get; set; }


    }
}
