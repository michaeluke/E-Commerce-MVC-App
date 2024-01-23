using E_Commerce.Data.Entities;
using E_Commerce.Model.Models;
using E_Commerce_CORE_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.ViewModels.ModelsView
{
    public class AddNewProductViewModel
    {

   
       
        public IEnumerable<CategoryModel?> Categories { get; set; }

        
        public ProductInStore? NewProduct { get; set; }

        public AddNewProductViewModel(IEnumerable<CategoryModel> categories)
        {

            Categories = categories;
        
                
        }
        public AddNewProductViewModel()
        {

            
        }

    }
}
