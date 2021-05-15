using HotelListing.Configurations.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Data
{
    public class DatabaseContext : IdentityDbContext<ApiUser>
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        { }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);  //base vaneko baseclass ho tyo vaneko aahile IdentityDBcontext

            builder.ApplyConfiguration(new RolesConfiguration());
            builder.ApplyConfiguration(new CountryConfiguration());
            builder.ApplyConfiguration(new HotelConfiguration());
            //    builder.Entity<Hotel>().HasData(
            //        new Hotel
            //        {
            //            Id = 1,
            //            Address = "Bharatpur",
            //            Name = "Global Hotel",
            //            Rating = 3,
            //            CountryId=1
            //        },
            //        new Hotel
            //        {
            //            Id = 2,
            //            Address = "Mumbai",
            //            Name = "Taj Hotel",
            //            Rating = 4,
            //            CountryId=2
            //        },
            //        new Hotel
            //        {
            //            Id = 3,
            //            Address = "gonjhau",
            //            Name = "sanchi Hotel",
            //            Rating = 5,
            //            CountryId=3
            //        }
            //        );
        }

    }
}
