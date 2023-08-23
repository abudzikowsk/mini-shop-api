using System;
using Microsoft.EntityFrameworkCore;
using Trening6.Database.Entitites;

namespace Trening6.Database
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) :base(dbContextOptions)
		{
		}

		public DbSet<Order> Orders { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<User> Users { get; set; }
	}
}

