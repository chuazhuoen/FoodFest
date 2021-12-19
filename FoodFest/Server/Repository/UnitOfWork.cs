using FoodFest.Server.Data;
using FoodFest.Server.IRepository;
using FoodFest.Server.Models;
using FoodFest.Shared.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FoodFest.Server.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IGenericRepository<Cuisine> _cuisines;
        private IGenericRepository<Customer> _customers;
        private IGenericRepository<FivePeopleReservation> _fivepeoplereservations;
        private IGenericRepository<FivePeopleTable> _fivepeopletables;
        private IGenericRepository<Reservation> _reservations;
        private IGenericRepository<Restaurant> _restaurants;
        private IGenericRepository<Review> _reviews;
        private IGenericRepository<TwoPeopleReservation> _twopeoplereservations;
        private IGenericRepository<TwoPeopleTable> _twopeopletables;

        private UserManager<ApplicationUser> _userManager;

        public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IGenericRepository<Cuisine> Cuisines
            => _cuisines ??= new GenericRepository<Cuisine>(_context);
        public IGenericRepository<Customer> Customers
            => _customers ??= new GenericRepository<Customer>(_context);
        public IGenericRepository<FivePeopleReservation> FivePeopleReservations
            => _fivepeoplereservations ??= new GenericRepository<FivePeopleReservation>(_context);
        public IGenericRepository<FivePeopleTable> FivePeopleTables
            => _fivepeopletables ??= new GenericRepository<FivePeopleTable>(_context);
        public IGenericRepository<Reservation> Reservations
            => _reservations ??= new GenericRepository<Reservation>(_context);
        public IGenericRepository<Restaurant> Restaurants
              => _restaurants ??= new GenericRepository<Restaurant>(_context);
        public IGenericRepository<Review> Reviews
            => _reviews ??= new GenericRepository<Review>(_context);
        public IGenericRepository<TwoPeopleReservation> TwoPeopleReservations
            => _twopeoplereservations ??= new GenericRepository<TwoPeopleReservation>(_context);

        public IGenericRepository<TwoPeopleTable> TwoPeopleTables
             => _twopeopletables ??= new GenericRepository<TwoPeopleTable>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save(HttpContext httpContext)
        {
            //To be implemented
            string user = "System";

            var entries = _context.ChangeTracker.Entries()
                .Where(q => q.State == EntityState.Modified ||
                    q.State == EntityState.Added);



            await _context.SaveChangesAsync();
        }
    }
}