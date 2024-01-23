using E_Commerce.Model.Models;
using E_Commerce_CORE_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.ViewModels.ModelsView
{
	public class EditProductsViewModel
	{
		public IEnumerable<ProductInStore> Products { get; set; }

		public IEnumerable<CategoryModel> Categories { get; set; }

		public EditProductsViewModel(IEnumerable<ProductInStore> products, IEnumerable<CategoryModel> categories)
		{
			Products = products;

			Categories = categories;
		}

	}
}
