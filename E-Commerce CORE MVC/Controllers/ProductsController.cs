using E_Commerce.Data.Entities;
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
				return RedirectToAction("Index", "Home");
			}

			// If the model state is not valid, redisplay the form
			var categories = await _productService.GetCategories();
			//this should be in services...
			var modelView = new AddNewProductViewModel(categories);
			return View(modelView);
		}




		[HttpGet]

		public async Task<IActionResult> EditProductPage(int id)
		{
			var product = await _productService.GetProductById(id);


			if(product != null) {

			

				var categories = await _productService.GetCategories();
				//this should be in services...
				var modelView = new AddNewProductViewModel(categories, product);

				return View(modelView);


			}
			else
			{
				return NotFound();
			}
		}




		[HttpPost]
		public async Task<IActionResult> EditProductInformation(ProductInStore newProduct)
		{

			if (ModelState.IsValid)
			{


				await _productService.EditProduct(newProduct);

				// Return a success message
				//return Ok("Product updated successfully");
				// After adding the item, redirect to another action (e.g., the index page)
				return RedirectToAction("Index", "Home");

			}
			else
			{

				foreach (var modelState in ModelState.Values)
				{
					foreach (var error in modelState.Errors)
					{
						Console.WriteLine(error.ErrorMessage);

					
					}
				}
				//return RedirectToAction("EditProducts", "Products");

				//return NotFound();
				return NotFound();
			}



		
		}
	}
}
