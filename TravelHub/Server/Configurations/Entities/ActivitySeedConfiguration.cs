using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelHub.Shared.Domain;

namespace TravelHub.Server.Configurations.Entities
{
    public class ActivitySeedConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.HasData(
                new Activity
                {
                    ActivityID = 1,
                    Name = "Tour of Buckingham Palace",
                    Type = "Sight Seeing",
                    Price = 5,
                    Rating = 8,
                    StaffID = 1,
                    LocationID = 2
                },
                new Activity
                {
                    ActivityID = 2,
                    Name = "Tour at Empire State Building",
                    Type = " Sight Seeing",
                    Price = 10,
                    Rating = 9,
                    StaffID = 2,
                    LocationID = 4
                }
            );
        }
    }
}
