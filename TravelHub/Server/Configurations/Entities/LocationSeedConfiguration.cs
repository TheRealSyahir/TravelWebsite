using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelHub.Shared.Domain;

namespace TravelHub.Server.Configurations.Entities
{
    public class LocationSeedConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasData(
                new Location
                {
                    LocationID = 1,
                    Name = "Marina Bay Sands",
                    Address = "10 Bayfront Avenue, Singapore",
                    Safety = 5,
                    CityID = 1
                },
                new Location
                {
                    LocationID = 2,
                    Name = "Buckingham Palace",
                    Address = " London SW1A 1AA, United Kingdom",
                    Safety = 5,
                    CityID = 2
                },
                new Location
                {
                    LocationID = 3,
                    Name = "Royal Ontario Museum",
                    Address = "100 Queens Park, Toronto, ON M5S 2C6, Canada",
                    Safety = 5,
                    CityID = 3
                },
                new Location
                {
                    LocationID = 4,
                    Name = "Empire State Building",
                    Address = "20 W 34th St., New York, NY 10001, United States",
                    Safety = 4,
                    CityID = 4
                },
                new Location
                {
                    LocationID = 5,
                    Name = "Golden Gate Bridge",
                    Address = "Golden Gate Bridge, San Francisco, CA, United States",
                    Safety = 4,
                    CityID = 5
                }
            );
        }
    }
}
