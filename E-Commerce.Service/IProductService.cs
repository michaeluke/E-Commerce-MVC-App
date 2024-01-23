using E_Commerce.Data.Entities;
using E_Commerce.Model.Models;
using E_Commerce_CORE_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Services
{
	public interface IProductService
	{
		 Task <IEnumerable<Product>> GetAllProducts();
		Task<IEnumerable<ProductInStore>> GetAllProductsWithCategories();
		Task AddProduct(ProductInStore product);

		Task<IEnumerable<CategoryModel>> GetCategories();

		Task<ProductInStore?> GetProductById(int id);
	}
}
