using HotelListing.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Configurations.Entities
{
    public class HotelConfiguration:IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(
                new Hotel
                {
                    Id = 1,
                    Address = "Bharatpur",
                    Name = "Global Hotel",
                    Rating = 3,
                    CountryId = 1
                },
                new Hotel
                {
                    Id = 2,
                    Address = "Mumbai",
                    Name = "Taj Hotel",
                    Rating = 4,
                    CountryId = 2
                },
                new Hotel
                {
                    Id = 3,
                    Address = "gonjhau",
                    Name = "sanchi Hotel",
                    Rating = 5,
                    CountryId = 3
                }
                );
            
        }
    }
}
