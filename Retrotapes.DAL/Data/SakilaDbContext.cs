using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retrotapes.DAL.Models;
using Retrotapes.DAL.Configurations;

namespace Retrotapes.DAL.Data
{
    public class SakilaDbContext : DbContext
    {
        public SakilaDbContext(DbContextOptions<SakilaDbContext> options): base(options) { }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerList> CustomerLists { get; set; }
        public DbSet<CustomerSpendning> CustomerSpendnings { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<FilmActor> FilmActors { get; set; }
        public DbSet<FilmCategory> FilmCategories { get; set; }
        public DbSet<FilmList> FilmLists { get; set; }
        public DbSet<FilmText> FilmTexts { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<SalesByFilmCategory> SalesByFilmCategories { get; set; }
        public DbSet<SalesByStore> SalesByStores { get; set; }
        public DbSet<Staff> staff { get; set; }
        public DbSet<StaffList> StaffLists { get; set; }
        public DbSet<Store> Stores { get; set; }
       


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // This will pick up the configuration class above automatically
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SakilaDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
