﻿using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelHub.Server.Configurations.Entities;
using TravelHub.Server.Models;
using TravelHub.Shared.Domain;

namespace TravelHub.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        public DbSet<City> City { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Itinerary> Itinerary { get; set; }
        public DbSet<Activity> Activity { get; set; }
        public DbSet<ActivitySelection> ActivitySelection { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new CitySeedConfiguration());
            builder.ApplyConfiguration(new CustomerSeedConfiguration());
            builder.ApplyConfiguration(new LocationSeedConfiguration());
            builder.ApplyConfiguration(new StaffSeedConfiguration());   
            builder.ApplyConfiguration(new ActivitySeedConfiguration());
            builder.ApplyConfiguration(new ActivitySelectionSeedConfiguration());
            builder.ApplyConfiguration(new ItinerarySeedConfiguration());
        }

    }

}
