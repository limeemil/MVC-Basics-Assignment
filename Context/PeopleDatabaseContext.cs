using Microsoft.EntityFrameworkCore;
using MVC_Basics__Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics__Assignment.Context
{
    public class PeopleDatabaseContext : DbContext
    {
        public PeopleDatabaseContext(DbContextOptions<PeopleDatabaseContext> options) : base(options) { }

        public DbSet<Person> People { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<Person>().HasData(new Person { ID=1, FirstName = "Andreas", LastName = "Lönnermark", PhoneNumber = "1234567890", City = "Borås" });
        }

    }

    
}
