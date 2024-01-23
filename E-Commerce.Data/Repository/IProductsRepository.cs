using E_Commerce.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Data.Repository
{
	public interface IProductsRepository
	{
		// properties and methods I want to use..

		Task<IEnumerable<Product>> AllProducts();

		Task<IEnumerable<Category>> GetCategories();

		Task<IEnumerable<Product>> AllProductsWithCategories();

		Task AddNewProduct(Product newProduct);

		Task <Product?> GetProductById(int id);
	}
}
