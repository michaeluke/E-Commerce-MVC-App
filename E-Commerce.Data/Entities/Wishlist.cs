using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Data.Entities
{
	public class Wishlist
	{
		public int Id { get; set; }

		public List<Product>? Products { get; set; }

		//public Wishlist()
		//{
		//	Products = new List<Product>();
		//}


		public int UserId { get; set; }



		public User User { get; set; }




	}
}
