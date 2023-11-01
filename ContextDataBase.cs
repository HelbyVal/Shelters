using Microsoft.EntityFrameworkCore;
using Shelters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelters
{
    internal class ContextDataBase : DbContext
    {
        private bool active = false;
        public ContextDataBase()
        {
            if (!active)
                active = true;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("host=localhost;port=5432;Database=SheltersAnimals;username=postgres;password=1234;Include Error Detail=true");
        }

        public DbSet<Animal> Animal { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Contract> Contract { get; set; }
        public DbSet<Shelter> Shelter { get; set; }
        public DbSet<Keeping> Keeping { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
    }
}
