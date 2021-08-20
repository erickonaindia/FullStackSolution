using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model
{
    public class DataContext : DbContext
    {
		public DataContext()
		{

		}

		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{
		}

		public DbSet<Parking> ParkingRepository { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Parking>().ToTable("Parkings");

			modelBuilder.Entity<Parking>().HasData(
				new Parking { Id = 1, Name = "Parking #1", Description = "Parking Description", CreationDate = DateTime.Now }
			);
		}
	}
}
