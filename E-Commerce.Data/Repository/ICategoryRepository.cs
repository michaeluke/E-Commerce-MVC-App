using E_Commerce.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Data.Repository
{
	public interface ICategoryRepository
	{
		public IEnumerable<Category> AllCategories {  get; }
	}
}
