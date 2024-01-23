using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }

 
        public required string Name { get; set; }

		
		public Decimal Price { get; set; }

		public bool InStock { get; set; }

        public string ImageUrl { get; set; }


		public int CategoryId { get; set; }

		////navigational property (Relationship M:1)
		public Category Category { get; set; }

		public List<Wishlist>? WishList { get; set; }

    }
}
