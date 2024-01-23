using E_Commerce.Data.Entities;
using E_Commerce_CORE_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.ViewModels.ModelsView
{
	public class HomeViewModel
	{
		public IEnumerable <ProductInStore> AllProducts { get; set; }

		public HomeViewModel(IEnumerable<ProductInStore> allProducts)
		{
			AllProducts = allProducts;
		}

	}
}
