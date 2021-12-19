using FoodFest.Shared.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodFest.Server.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save(HttpContext httpContext);
        IGenericRepository<Cuisine> Cuisines { get; }
        IGenericRepository<Customer> Customers { get; }
        IGenericRepository<FivePeopleReservation> FivePeopleReservations { get; }
        IGenericRepository<FivePeopleTable> FivePeopleTables { get; }
        IGenericRepository<Reservation> Reservations { get; }
        IGenericRepository<Restaurant> Restaurants { get; }
        IGenericRepository<Review> Reviews { get; }
        IGenericRepository<TwoPeopleReservation> TwoPeopleReservations { get; }
        IGenericRepository<TwoPeopleTable> TwoPeopleTables { get; }
    }
}