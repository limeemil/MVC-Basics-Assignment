using Microsoft.EntityFrameworkCore;
using MVC_Basics__Assignment.Models;
using MVC_Basics__Assignment.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics__Assignment.Context
{
    public class PeopleDatabaseContext : DbContext
    {
        public PeopleDatabaseContext(DbContextOptions<PeopleDatabaseContext> options) : base(options) { }

        public DbSet<DBPersonModel> People { get; set; }

        public DbSet<CityModel> Cities { get; set; }

        public DbSet<CountryModel> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<DBPersonModel>()
                .HasOne(p => p.City)
                .WithMany(c => c.People)
                .HasForeignKey(p => p.CityId)
                .IsRequired();

            modelBuilder.Entity<CityModel>()
                .HasOne(co => co.Country)
                .WithMany(ci => ci.Cities)
                .HasForeignKey(co => co.CountryModelId)
                .IsRequired();

            /*var Boras = new CityModel
            {
                Id = 1,
                Name = "Borås",
            };

            var Goteborg = new CityModel
            {
                Id = 2,
                Name = "Göteborg",
            };

            var Stockholm = new CityModel
            {
                Id = 3,
                Name = "Stockholm",
            };*/

            /*modelBuilder.Entity<CityModel>().HasData(Boras);
            modelBuilder.Entity<CityModel>().HasData(Goteborg);
            modelBuilder.Entity<CityModel>().HasData(Stockholm);*/

            modelBuilder.Entity<CountryModel>().HasData(new CountryModel { Id = 1, Name = "Sverige" });
            modelBuilder.Entity<CountryModel>().HasData(new CountryModel { Id = 2, Name = "Norge" });

            modelBuilder.Entity<CityModel>().HasData(new CityModel { Id = 1, Name = "Borås", CountryModelId = 1});
            modelBuilder.Entity<CityModel>().HasData(new CityModel { Id = 2, Name = "Göteborg", CountryModelId = 1 });
            modelBuilder.Entity<CityModel>().HasData(new CityModel { Id = 3, Name = "Stockholm", CountryModelId = 1 });
            modelBuilder.Entity<CityModel>().HasData(new CityModel { Id = 4, Name = "Oslo", CountryModelId = 2 });


            

            modelBuilder.Entity<DBPersonModel>().HasData(new DBPersonModel { SSN = "0123456789", FirstName = "Andreas", LastName = "Lönnermark", PhoneNumber = "1234567890", CityId = 1});
            
        }

    }

    
}
