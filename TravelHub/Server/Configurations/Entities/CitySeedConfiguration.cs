using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelHub.Shared.Domain;

namespace TravelHub.Server.Configurations.Entities
{
    public class CitySeedConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasData(
                new City
                {
                    CityID = 1,
                    Name = "Singapore",
                    Safety = 5,
                    Transport = "Accessible",
                    Countryname = "Singapore"
                },
                new City
                {
                    CityID = 2,
                    Name = "London",
                    Safety = 4,
                    Transport = "Accessible",
                    Countryname = "England"
                },
                new City
                {
                    CityID = 3,
                    Name = "Toronto",
                    Safety = 5,
                    Transport = "Accessible",
                    Countryname = "Canada"
                },
                new City
                {
                    CityID = 4,
                    Name = "New York City",
                    Safety = 5,
                    Transport = "Accessible",
                    Countryname = "United States"
                },
                new City
                {
                    CityID = 5,
                    Name = "San Francisco",
                    Safety = 5,
                    Transport = "Accessible",
                    Countryname = "United States"
                }
            );
        }
    }
}
