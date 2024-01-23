using E_Commerce.Data.Entities;
using E_Commerce_CORE_MVC.MyDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Data.Repository
{
	public class CategoryRepository : ICategoryRepository
	{
		//dbcontext 
		private readonly OnlineShopDbContext _onlineShopDb;

		public CategoryRepository(OnlineShopDbContext onlineShopDb)
		{
			_onlineShopDb = onlineShopDb;
		}

		public IEnumerable<Category> AllCategories
		{
			get
			{
				return _onlineShopDb.Categories;
			}
		}
	}
}
