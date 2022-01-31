﻿using DogSitter.DAL.Entity;
using Microsoft.EntityFrameworkCore;


namespace DogSitter.DAL
{
    public class DogSitterContext : DbContext
    {
        private const string _conectionString = @"Data Source = 80.78.240.16; Initial Catalog = DogSitterDB; 
        Persist Security Info=True;User ID = student; Password=qwe!23; Pooling=False; MultipleActiveResultSets=False; 
        Connect Timeout = 60; Encrypt=False; TrustServerCertificate=False";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_conectionString);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Sitter> Sitters { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Passport> Passports { get; set; }
        public DbSet<Serviсe> Services { get; set; }
        public DbSet<SubwayStation> SubwayStations { get; set; }
        public DbSet<WorkTime> WorkTimes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().ToTable("Admin");
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Sitter>().ToTable("Sitter");

            modelBuilder.Entity<SubwayStation>().OwnsOne(s => s.Name).HasData(
                new { Id = 1, Name = "" },
                new { Id = 2, Name = "" },
                new { Id = 3, Name = "" },
                new { Id = 4, Name = "" },
                new { Id = 5, Name = "" },
                new { Id = 6, Name = "" },
                new { Id = 7, Name = "" },
                new { Id = 8, Name = "" },
                new { Id = 9, Name = "" },
                new { Id = 10, Name = "" },
                new { Id = 11, Name = "" },
                new { Id = 12, Name = "" },
                new { Id = 13, Name = "" },
                new { Id = 14, Name = "" },
                new { Id = 15, Name = "" },
                new { Id = 16, Name = "" },
                new { Id = 17, Name = "" },
                new { Id = 18, Name = "" },
                new { Id = 19, Name = "" },
                new { Id = 20, Name = "" },
                new { Id = 21, Name = "" },
                new { Id = 22, Name = "" },
                new { Id = 23, Name = "" },
                new { Id = 24, Name = "" },
                new { Id = 25, Name = "" },
                new { Id = 26, Name = "" },
                new { Id = 27, Name = "" },
                new { Id = 28, Name = "" },
                new { Id = 29, Name = "" },
                new { Id = 30, Name = "" },
                new { Id = 31, Name = "" },
                new { Id = 32, Name = "" },
                new { Id = 33, Name = "" },
                new { Id = 34, Name = "" },
                new { Id = 35, Name = "" },
                new { Id = 36, Name = "" },
                new { Id = 37, Name = "" },
                new { Id = 38, Name = "" },
                new { Id = 39, Name = "" },
                new { Id = 40, Name = "" },
                new { Id = 41, Name = "" },
                new { Id = 42, Name = "" },
                new { Id = 43, Name = "" },
                new { Id = 44, Name = "" },
                new { Id = 45, Name = "" },
                new { Id = 46, Name = "" },
                new { Id = 47, Name = "" },
                new { Id = 48, Name = "" },
                new { Id = 49, Name = "" },
                new { Id = 50, Name = "" },
                new { Id = 51, Name = "" },
                new { Id = 52, Name = "" },
                new { Id = 53, Name = "" },
                new { Id = 54, Name = "" },
                new { Id = 55, Name = "" },
                new { Id = 56, Name = "" },
                new { Id = 57, Name = "" },
                new { Id = 58, Name = "" },
                new { Id = 59, Name = "" },
                new { Id = 60, Name = "" },
                new { Id = 61, Name = "" },
                new { Id = 62, Name = "" },
                new { Id = 63, Name = "" },
                new { Id = 64, Name = "" },
                new { Id = 65, Name = "" },
                new { Id = 66, Name = "" },
                new { Id = 67, Name = "" },
                new { Id = 68, Name = "" },
                new { Id = 69, Name = "" },
                new { Id = 70, Name = "" },
                new { Id = 71, Name = "" },
                new { Id = 72, Name = "" }

                );

        }

    }
}
