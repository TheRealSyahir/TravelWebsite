using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TravelHub.Server.Data;
using TravelHub.Server.IRepository;
using TravelHub.Server.Models;
using TravelHub.Shared.Domain;

namespace TravelHub.Server.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IGenericRepository<City> _cities;
        private IGenericRepository<Location> _locations;
        private IGenericRepository<Staff> _staffs;
        private IGenericRepository<Customer> _customers;
        private IGenericRepository<Itinerary> _itineraries;
        private IGenericRepository<ActivitySelection> _activityselections;

        private UserManager<ApplicationUser> _userManager;

        public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IGenericRepository<City> GetCities()
        {
            return _cities ??= new GenericRepository<City>(_context);
        }
        public IGenericRepository<Location> GetLocations()
        {
            return _locations ??= new GenericRepository<Location>(_context);
        }
        public IGenericRepository<Staff> GetStaffs()
        {
            return _staffs ??= new GenericRepository<Staff>(_context);
        }
        public IGenericRepository<Customer> GetCustomers()
        {
            return _customers ??= new GenericRepository<Customer>(_context);
        }
        public IGenericRepository<Itinerary> GetItineraries()
        {
            return _itineraries ??= new GenericRepository<Itinerary>(_context);
        }
        public IGenericRepository<ActivitySelection> GetActivitySelections()
        {
            return _activityselections ??= new GenericRepository<ActivitySelection>(_context);
        }


        public IGenericRepository<City> Cities => _cities ??= new GenericRepository<City>(_context);
        public IGenericRepository<Location> Locations => _locations ??= new GenericRepository<Location>(_context);
        public IGenericRepository<Staff> Staffs => _staffs ??= new GenericRepository<Staff>(_context);
        public IGenericRepository<Customer> Customers => _customers ??= new GenericRepository<Customer>(_context);
        public IGenericRepository<Itinerary> Itineraries => _itineraries ??= new GenericRepository<Itinerary>(_context);
        public IGenericRepository<ActivitySelection> ActivitySelections => _activityselections ??= new GenericRepository<ActivitySelection>(_context);
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save(HttpContext httpContext)
        {

            var entries = _context.ChangeTracker.Entries()
                .Where(q => q.State == EntityState.Modified ||
                    q.State == EntityState.Added);

            await _context.SaveChangesAsync();
        }
    }
}