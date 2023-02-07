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
        private String[] transport = { "Very Accessible", "Acessible", "Inconvenient" };
    public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasData(
                new City
                {
                    CityID = 1,
                    Name = "Singapore",
                    Safety = 5,
                    Transport = transport[1],
                    Countryname = "Singapore"
                },
                new City
                {
                    CityID = 2,
                    Name = "London",
                    Safety = 4,
                    Transport = transport[1],
                    Countryname = "England"
                },
                new City
                {
                    CityID = 3,
                    Name = "Toronto",
                    Safety = 5,
                    Transport = transport[1],
                    Countryname = "Canada"
                },
                new City
                {
                    CityID = 4,
                    Name = "New York City",
                    Safety = 5,
                    Transport = transport[1],
                    Countryname = "United States"
                },
                new City
                {
                    CityID = 5,
                    Name = "San Francisco",
                    Safety = 5,
                    Transport = transport[1],
                    Countryname = "United States"
                }
            );
        }
    }
}
