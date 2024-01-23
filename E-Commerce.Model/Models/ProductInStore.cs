using E_Commerce.Data.Entities;
using E_Commerce.Model.Models;

namespace E_Commerce_CORE_MVC.Models
{
	public class ProductInStore
	{
		public string Name { get; set; }

		public Decimal Price { get; set; }

		public bool InStock { get; set; }

		public string ImageUrl { get; set; }


		public Wishlist? Wishlist { get; set; }
		public CategoryModel Category { get; set; }
		public Product? NewProduct { get; }

	

		
	}
}
