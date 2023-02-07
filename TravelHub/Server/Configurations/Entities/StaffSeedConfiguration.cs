using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelHub.Shared.Domain;

namespace TravelHub.Server.Configurations.Entities
{
    public class StaffSeedConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.HasData(
                new Staff
                {
                    StaffID = 1,
                    Name = "Leroy Jenkins",
                    Number = 81265792,
                    Address = "Bedok St 21"
                },
                new Staff
                {
                    StaffID = 2,
                    Name = "Ben Clarke",
                    Number = 90293212,
                    Address = "Pasir Ris St 21"
                },   
                new Staff
                {
                    StaffID = 3,
                    Name = "Lebron James",
                    Number = 90299132,
                    Address = "Tampines St 4"  
                },
                new Staff
                {
                    StaffID = 4,
                    Name = "Jeff Hopkins",
                    Number = 81264932,
                    Address = "Tampines St 5"
                },
                new Staff
                {
                    StaffID = 5,
                    Name = "Emelia Clark",
                    Number = 90221012,
                    Address = "Tampines St 6"
                }
            );
        }
    }
}
