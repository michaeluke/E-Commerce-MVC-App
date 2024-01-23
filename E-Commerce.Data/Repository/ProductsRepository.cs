using E_Commerce.Data.Entities;
using E_Commerce_CORE_MVC.MyDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Data.Repository
{
    public class ProductsRepository : IProductsRepository
    {

        //dbcontext 
        private readonly OnlineShopDbContext _onlineShopDb;


        public ProductsRepository(OnlineShopDbContext onlineShopDb)
        {
            _onlineShopDb = onlineShopDb;
        }

        public async Task<IEnumerable<Product>> AllProducts()
        {
            return await _onlineShopDb.Products.ToListAsync();
        }

        public async Task<IEnumerable<Product>> AllProductsWithCategories()
        {
            return await _onlineShopDb.Products.Include(p => p.Category).ToListAsync();

        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _onlineShopDb.Categories.ToListAsync();
        }


        public async Task AddNewProduct(Product newProduct)
        {

			// Check if the category already exists
			var category = await _onlineShopDb.Categories
				.FirstOrDefaultAsync(c => c.Name == newProduct.Category.Name);

			// If the category doesn't exist, create a new one
			if (category == null)
			{
				category = new Category { Name = newProduct.Name };
				_onlineShopDb.Categories.Add(category);
				await _onlineShopDb.SaveChangesAsync();
			}

			// Add the product to the category
			newProduct.Category = category;

			// Add the product to the database
			_onlineShopDb.Products.Add(newProduct);

			await _onlineShopDb.SaveChangesAsync();
        }


        public async Task<Product?> GetProductById(int id)
        {
            var SelectedProduct = await _onlineShopDb.Products.FindAsync(id);
            if (SelectedProduct != null)
            {
                return SelectedProduct;

			}
            else
            {
                //TODO Change to not found..
                return null;
            }
			
        }

    }






}
