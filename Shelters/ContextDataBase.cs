using Microsoft.EntityFrameworkCore;
using Shelters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelters
{
    public class ContextDataBase : DbContext
    {
        static public ContextDataBase DB = new ContextDataBase();
        public DbSet<Animal> Animal { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Contract> Contract { get; set; }
        public DbSet<Shelter> Shelter { get; set; }
        public DbSet<Keeping> Keeping { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserRole> UserRole { get; set; }

        public ContextDataBase() 
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("host=localhost;port=5432;Database=SheltersAnimals;username=postgres;password=1234;Include Error Detail=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
