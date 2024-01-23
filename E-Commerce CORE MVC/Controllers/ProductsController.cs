using E_Commerce.Services;
using E_Commerce.ViewModels.ModelsView;
using E_Commerce_CORE_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_CORE_MVC.Controllers
{
    public class ProductsController : Controller
    {
        //use service here instead of repo
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {

            _productService = productService;

        }
        public async Task<IActionResult> AddNewProduct()
        {
            var categories = await _productService.GetCategories();
            //this should be in services...
            var modelView = new AddNewProductViewModel(categories);
            return View(modelView);

        }


		public async Task<IActionResult> EditProducts()
		{

			var products = await _productService.GetAllProductsWithCategories();

			var categories = await _productService.GetCategories();
			//this should be in services...
			var modelView = new EditProductsViewModel(products, categories);
		
			return View(modelView);

		}




		[HttpPost]
		public async Task<IActionResult> AddNewProduct(ProductInStore newProduct)
		{
			
			if (ModelState.IsValid)
			{

			
				await _productService.AddProduct(newProduct);
				// After adding the item, redirect to another action (e.g., the index page)
				return RedirectToAction("Index","Home");
			}

			// If the model state is not valid, redisplay the form
			var categories = await _productService.GetCategories();
			//this should be in services...
			var modelView = new AddNewProductViewModel(categories);
			return View(modelView);
		}
	}
}
