using DAL.EF.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL.EF
{
    public class EfContext : DbContext
    {
		public EfContext()
		{
		}

		public EfContext(DbContextOptions<EfContext> options) : base(options)
		{
		}

		public DbSet<Parking> ParkingRepository { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			if (!options.IsConfigured)
			{
				options.UseSqlServer("Server=localhost;Database=parkings;Trusted_Connection=True;MultipleActiveResultSets=true");
			}
			base.OnConfiguring(options);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Parking>().ToTable("Parking");
			modelBuilder.Entity<Parking>().HasData(
				new Parking { CreationDate = DateTime.Now, Description = "Initial Parking", Name = "Parking Number 1" }
			);
		}
	}
}
