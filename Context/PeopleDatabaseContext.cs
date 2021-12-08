using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC_Basics__Assignment.Models;
using MVC_Basics__Assignment.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics__Assignment.Context
{
    public class PeopleDatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public PeopleDatabaseContext(DbContextOptions<PeopleDatabaseContext> options) : base(options)
        {

        }

        public DbSet<DBPersonModel> People { get; set; }

        public DbSet<CityModel> Cities { get; set; }

        public DbSet<CountryModel> Countries { get; set; }

        public DbSet<LanguageModel> Languages { get; set; }

        public DbSet<PersonLanguageModel> PersonLanguages { get; set; }

        public override DbSet<ApplicationUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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

            modelBuilder.Entity<PersonLanguageModel>().HasKey(pl => new { pl.LanguageId, pl.PersonSSN });

            modelBuilder.Entity<PersonLanguageModel>()
                .HasOne(pl => pl.Person)
                .WithMany(p => p.PersonLanguages)
                .HasForeignKey(pl => pl.PersonSSN);

            modelBuilder.Entity<PersonLanguageModel>()
                .HasOne(pl => pl.Language)
                .WithMany(l => l.PersonLanguages)
                .HasForeignKey(pl => pl.LanguageId);

            modelBuilder.Entity<CountryModel>().HasData(new CountryModel { Id = 1, Name = "Sverige" });
            modelBuilder.Entity<CountryModel>().HasData(new CountryModel { Id = 2, Name = "Norge" });

            modelBuilder.Entity<CityModel>().HasData(new CityModel { Id = 1, Name = "Borås", CountryModelId = 1});
            modelBuilder.Entity<CityModel>().HasData(new CityModel { Id = 2, Name = "Göteborg", CountryModelId = 1 });
            modelBuilder.Entity<CityModel>().HasData(new CityModel { Id = 3, Name = "Stockholm", CountryModelId = 1 });
            modelBuilder.Entity<CityModel>().HasData(new CityModel { Id = 4, Name = "Oslo", CountryModelId = 2 });


            modelBuilder.Entity<DBPersonModel>().HasData(new DBPersonModel { SSN = "0123456789", FirstName = "Andreas", LastName = "Lönnermark", PhoneNumber = "1234567890", CityId = 1});
            modelBuilder.Entity<DBPersonModel>().HasData(new DBPersonModel { SSN = "9876543210", FirstName = "Martin", LastName = "Nielsen", PhoneNumber = "1111111111", CityId = 4 });

            modelBuilder.Entity<LanguageModel>().HasData(new LanguageModel { Id = 1, Name = "Svenska" });
            modelBuilder.Entity<LanguageModel>().HasData(new LanguageModel { Id = 2, Name = "Norsk" });
            modelBuilder.Entity<LanguageModel>().HasData(new LanguageModel { Id = 3, Name = "English" });

            modelBuilder.Entity<PersonLanguageModel>().HasData(new PersonLanguageModel { PersonSSN = "0123456789", LanguageId = 1 });
            modelBuilder.Entity<PersonLanguageModel>().HasData(new PersonLanguageModel { PersonSSN = "0123456789", LanguageId = 3 });
            modelBuilder.Entity<PersonLanguageModel>().HasData(new PersonLanguageModel { PersonSSN = "9876543210", LanguageId = 2 });
            modelBuilder.Entity<PersonLanguageModel>().HasData(new PersonLanguageModel { PersonSSN = "9876543210", LanguageId = 3 });

            //string roleId = Guid.NewGuid().ToString();
            //string userRoleId = Guid.NewGuid().ToString();

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                //Id = roleId,
                Name = "Admin",
                NormalizedName = "ADMIN"
            });

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                //Id = userRoleId,
                Name = "User",
                NormalizedName = "USER"
            });
        }

    }

    
}
