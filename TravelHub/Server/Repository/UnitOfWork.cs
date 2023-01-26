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
        private IGenericRepository<Activity> _activities;

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
        public IGenericRepository<Activity> GetActivitives()
        {
            return _activities ??= new GenericRepository<Activity>(_context);
        }

        public IGenericRepository<City> Cities => _cities ??= new GenericRepository<City>(_context);
        public IGenericRepository<Location> Locations => _locations ??= new GenericRepository<Location>(_context);
        public IGenericRepository<Staff> Staffs => _staffs ??= new GenericRepository<Staff>(_context);
        public IGenericRepository<Activity> Activities => _activities ??= new GenericRepository<Activity>(_context);

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