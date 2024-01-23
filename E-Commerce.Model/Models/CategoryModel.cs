using E_Commerce.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Model.Models
{
	public class CategoryModel
	{

		public string Name { get; set; }

		public List<Product>? Products { get; set; }
	}
}
