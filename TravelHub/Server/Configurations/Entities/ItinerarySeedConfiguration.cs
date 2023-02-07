using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelHub.Shared.Domain;

namespace TravelHub.Server.Configurations.Entities
{
    public class ItinerarySeedConfiguration : IEntityTypeConfiguration<Itinerary>
    {
        public void Configure(EntityTypeBuilder<Itinerary> builder)
        {
            builder.HasData(
                new Itinerary
                {
                    ItineraryID = 1,
                    Description = "NYC Trip",
                    Duration = 5,
                    Budget = 500,
                    CustomerID = 1
                },
                new Itinerary
                {
                    ItineraryID = 2,
                    Description = "Explore London",
                    Duration = 4,
                    Budget = 250,
                    CustomerID = 2

                }
            );
        }
    }
}
