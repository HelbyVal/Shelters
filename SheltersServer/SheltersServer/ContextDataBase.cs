using Microsoft.EntityFrameworkCore;
using SheltersServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheltersServer
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
            //Database.EnsureDelete();
            //Database.EnsureCreate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("host=localhost;port=5432;Database=SheltersAnimals;username=postgres;password=1234;Include Error Detail=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shelter>().HasIndex(c => c.INN).IsUnique();
            modelBuilder.Entity<Shelter>().HasIndex(c => c.KPP).IsUnique();
            modelBuilder.Entity<Shelter>().HasIndex(c => c.Name).IsUnique();

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRole)
                .HasForeignKey(ur => ur.Id_User);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRole)
                .HasForeignKey(ur => ur.Id_Role);

            modelBuilder.Entity<Shelter>()
                .HasOne(ur => ur.City)
                .WithMany(r => r.Shelters)
                .HasForeignKey(ur => ur.Id_City);

            modelBuilder.Entity<User>()
                .HasOne(ur => ur.Shelter)
                .WithMany(x => x.Users)
                .HasForeignKey(ur => ur.Id_Shelter);

            modelBuilder.Entity<Contract>()
                .HasOne(ur => ur.Shelter)
                .WithMany(x => x.Contracts)
                .HasForeignKey(ur => ur.Id_Shelter);

            modelBuilder.Entity<Keeping>()
                .HasOne(ur => ur.Contract)
                .WithMany(u => u.Keepings)
                .HasForeignKey(ur => ur.Number);

            modelBuilder.Entity<Keeping>()
                .HasOne(ur => ur.Animal)
                .WithMany(u => u.Keepings)
                .HasForeignKey(ur => ur.ChipNum);
        }
    }
}
