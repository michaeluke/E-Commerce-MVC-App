using E_Commerce.Data.Entities;
using E_Commerce.Model.Models;

namespace E_Commerce_CORE_MVC.Models
{
	public class ProductInStore
	{
	
		public int Id { get; set; }
		public string Name { get; set; }

		public Decimal Price { get; set; }

		public bool InStock { get; set; }

		public string ImageUrl { get; set; }


		public Wishlist? Wishlist { get; set; }

		public Category Category { get; set; }





    }
}
