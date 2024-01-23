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
            _onlineShopDb.Products.Add(newProduct);

            await _onlineShopDb.SaveChangesAsync();
        }

    }






}
