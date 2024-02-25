using E_Commerce.Data.Repository;
using E_Commerce.Services;
using E_Commerce.ViewModels.ModelsView;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_CORE_MVC.Controllers
{
    [AllowAnonymous]
	public class HomeController : Controller
	{
        //use service here instead of repo
        private readonly IProductService _productService;

        public HomeController(IProductService productService)
        {

            _productService = productService;

        }


		//Home page
        public async Task<IActionResult> Index()
        {

			var products = await _productService.GetAllProductsWithCategories();
			//this should be in services...
			var modelView = new HomeViewModel(products);
			return View(modelView);
		}


      


    }
}
