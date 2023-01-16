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
                    Safety = 3,
                    Transport = "Accessible",
                    Countryname = "England"
                }
            );
        }
    }
}
