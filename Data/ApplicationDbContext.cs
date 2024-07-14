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
	}
}

