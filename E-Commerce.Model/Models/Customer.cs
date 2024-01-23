
using E_Commerce.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_CORE_MVC.Models
{
	public class Customer
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string phoneNumber { get; set; }

		public string location { get; set; }

		public decimal Wallet { get; set; }
		public Wishlist? wishList { get; set; }
	}
}
