using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelHub.Shared.Domain;

namespace TravelHub.Server.Configurations.Entities
{
    public class ActivitySelectionSeedConfiguration : IEntityTypeConfiguration<ActivitySelection>
    {
        public void Configure(EntityTypeBuilder<ActivitySelection> builder)
        {
            builder.HasData(
                new ActivitySelection
                {
                    ActivitySelectionID = 1,
                    Date = DateTime.Now,
                    ItineraryID = 2,
                    ActivityID = 1 
                },
                new ActivitySelection
                {
                    ActivitySelectionID = 2,
                    Date = new DateTime(2023, 5, 1, 8, 30, 00),
                    ItineraryID = 1,
                    ActivityID = 2
                }
            );
        }
    }
}
