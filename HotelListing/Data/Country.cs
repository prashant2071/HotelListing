using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Data
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public String ShortName { get; set; }
        public virtual IList<Hotel> Hotels { get; set; }



    }
}
