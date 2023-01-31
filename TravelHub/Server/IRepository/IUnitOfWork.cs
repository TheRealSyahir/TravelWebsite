using TravelHub.Shared.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelHub.Server.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save(HttpContext httpContext);
        IGenericRepository<City> Cities { get; }
        IGenericRepository<Location> Locations { get; }
        IGenericRepository<Staff> Staffs { get; }
        IGenericRepository<Customer> Customers { get; }
        IGenericRepository<Itinerary> Itineraries { get; }
        IGenericRepository<Activity> Activities { get; }
        IGenericRepository<ActivitySelection> ActivitySelections { get; }
    }
}