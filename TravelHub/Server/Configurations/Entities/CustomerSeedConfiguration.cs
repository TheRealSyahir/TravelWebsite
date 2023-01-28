using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelHub.Shared.Domain;

namespace TravelHub.Server.Configurations.Entities
{
    public class CustomerSeedConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(
                new Customer
                {
                    CustomerID = 1,
                    Name = "Oliver Queen",
                    Address = "Star City",
                    Number = 81275892                
                },
                new Customer
                {
                    CustomerID = 2,
                    Name = "Barry Allen",
                    Address = "Central City",
                    Number = 81265794
                }
            );
        }
    }
}
