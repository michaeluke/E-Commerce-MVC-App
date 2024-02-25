using E_Commerce.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_CORE_MVC.MyDbContext
{
	public class OnlineShopDbContext : DbContext
	{
		public OnlineShopDbContext(DbContextOptions<OnlineShopDbContext> options) : base(options)
		{

		}



		//DbSets represents tables...
		public DbSet<Product> Products { get; set; }

		public DbSet<Category> Categories { get; set; }

		public DbSet<User> Users { get; set; }

		public DbSet<Wishlist> Wishlists { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			//using fluent api to establish relationships between entities


			modelBuilder.Entity<User>()
			.HasOne(u => u.WishList)
			.WithOne(w => w.User)
			.HasForeignKey<Wishlist>(w => w.UserId);


			modelBuilder.Entity<Product>()
			 .HasOne(p => p.Category)
			 .WithMany(c => c.Products);

			modelBuilder.Entity<Wishlist>()
				.HasMany(w => w.Products)
				.WithMany(p => p.WishList);



		}

		
	}
}
