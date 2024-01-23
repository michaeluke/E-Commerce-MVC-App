using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Data.Entities
{
	public class User
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Email { get; set; }

		public string phoneNumber { get; set; }

		public string location { get; set; }

		public decimal Wallet {  get; set; }
		public int WishlistId { get; set; }
		public Wishlist? WishList { get; set; }

	}
}
