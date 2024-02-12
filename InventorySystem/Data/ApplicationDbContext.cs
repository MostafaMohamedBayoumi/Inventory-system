using InventorySystem.Models;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.Data
{
	public class ApplicationDbContext: DbContext
	{
		
		public ApplicationDbContext(DbContextOptions options) : base(options) { }

		public DbSet<Product> Products { get; set; }

		public DbSet<Purchase> purchase { get; set; }
		public DbSet<Sale> Sales { get; set;}
		

	}
}
