using System;
using Microsoft.EntityFrameworkCore;
using MiniShopApi.Database.Entitites;

namespace MiniShopApi.Database
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) :base(dbContextOptions)
		{
		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<User>().Property(u => u.Id).HasDefaultValueSql("NEWID()");
        }

        public DbSet<Order> Orders { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<User> Users { get; set; }
	}
}

