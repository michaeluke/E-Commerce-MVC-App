using E_Commerce.Data.Entities;
using E_Commerce_CORE_MVC.MyDbContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Data.DbInitializer
{
	public class OnlineShopDbInitializer
	{
		public static void Seed(IApplicationBuilder applicationBuilder)
		{
			OnlineShopDbContext context = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<OnlineShopDbContext>();

			if (!context.Categories.Any())
			{
				context.Categories.AddRange(Categories.Select(c => c.Value));
				context.SaveChanges();
			}

			if (!context.Products.Any())
			{
				var sportsCategory = context.Categories.FirstOrDefault(c => c.Name == "Sports");
				var kitchenCategory = context.Categories.FirstOrDefault(c => c.Name == "Kitchen");
				var furnitureCategory = context.Categories.FirstOrDefault(c => c.Name == "Furniture");

			
				context.AddRange
				(
					new Product { Name = "Bike", Price = 1000, ImageUrl = "/media/Bike_.jpg", InStock = true, CategoryId = sportsCategory.Id },

						new Product { Name = "Pan", Price = 60, ImageUrl = "/media/pan.jpg", InStock = true, CategoryId = kitchenCategory.Id },

							new Product {  Name = "Couch", Price = 2200, ImageUrl = "/media/Couch.jpg", InStock = true, CategoryId = furnitureCategory.Id}
				);
			}

			context.SaveChanges();

		}

		public static void Unseed(IApplicationBuilder applicationBuilder)
		{
			OnlineShopDbContext context = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<OnlineShopDbContext>();

			// Remove seeded products
			var seededProducts = context.Products.Where(p => p.Name == "Bike" || p.Name == "Pan" || p.Name == "Couch");
			context.Products.RemoveRange(seededProducts);

			// Remove seeded products
			var seededCategoires = context.Categories.Where(c => c.Name == "Sports" || c.Name == "Kitchen" || c.Name == "Furniture");
			context.Categories.RemoveRange(seededCategoires);

			context.SaveChanges();
		}


		private static Dictionary<string, Category>? categories;

		public static Dictionary<string, Category> Categories
		{
			get
			{
				if (categories == null)
				{
					var genresList = new Category[]
					{
						new Category { Name = "Sports" },
						new Category { Name = "Kitchen"  },
						new Category { Name = "Furniture"  }
					};

					categories = new Dictionary<string, Category>();

					foreach (Category genre in genresList)
					{
						categories.Add(genre.Name, genre);
					}
				}

				return categories;
			}
		}
	}
}
