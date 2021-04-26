using FirstEFCoreApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstEFCoreApplication {
    class CareContext : DbContext {


        private readonly string connectionString;

        public CareContext() : base() {
            var builder = new ConfigurationBuilder();

            builder.AddJsonFile("appsettings.Development.json", optional: false);

            var configuration = builder.Build();

            connectionString = configuration.GetConnectionString("SQLConnection").ToString();
        }

        // Server=(localdb)\\mssqllocaldb;Database=EFCore;Trusted_Connection=True
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<ResidentCareTaker>().HasKey(rc => new { rc.CareTakerId, rc.ResidentId });
        }

        public DbSet<CareTaker> CareTakers { get; set; }
        public DbSet<Resident> Residents { get; set; }
        public DbSet<Room> Rooms { get; set; }
    }
}
