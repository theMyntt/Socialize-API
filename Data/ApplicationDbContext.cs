using System;
using Microsoft.EntityFrameworkCore;
using Socialize.Models;

namespace Socialize.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{

		}

		public DbSet<Publication> Publication { get; set; }
		public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<User>()
				.HasIndex(e => e.Email)
				.IsUnique();

			modelBuilder.Entity<User>()
				.HasIndex(e => e.Code)
				.IsUnique();
        }
    }
}

