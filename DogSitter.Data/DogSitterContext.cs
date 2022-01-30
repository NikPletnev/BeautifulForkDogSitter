using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DogSitter.DAL.Entity;
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

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Passport> Passports { get; set; }
    }
}
