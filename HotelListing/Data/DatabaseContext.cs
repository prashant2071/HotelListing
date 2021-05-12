using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        { }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1,
                    Name = "Nepal",
                    ShortName = "NP"
                },
                new Country
                {
                    Id = 2,
                    Name = "India",
                    ShortName = "IND"
                },
                new Country
                {
                    Id = 3,
                    Name = "China",
                    ShortName = "Ch"
                }
            );
            builder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = 1,
                    Address = "Bharatpur",
                    Name = "Global Hotel",
                    Rating = 3,
                    CountryId=1
                },
                new Hotel
                {
                    Id = 2,
                    Address = "Mumbai",
                    Name = "Taj Hotel",
                    Rating = 4,
                    CountryId=2
                },
                new Hotel
                {
                    Id = 3,
                    Address = "gonjhau",
                    Name = "sanchi Hotel",
                    Rating = 5,
                    CountryId=3
                }
                );
        }

    }
}
