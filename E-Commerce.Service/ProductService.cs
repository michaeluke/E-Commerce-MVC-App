using AutoMapper;
using E_Commerce.Data.Entities;
using E_Commerce.Data.Repository;
using E_Commerce.Model.Models;
using E_Commerce_CORE_MVC.Models;

namespace E_Commerce.Services
{
	public class ProductService : IProductService
	{
		private readonly IMapper _mapper;

		public IProductsRepository _productsRepository;

		public ProductService(IMapper mapper, IProductsRepository productRepository)
		{

			_mapper = mapper;
			_productsRepository = productRepository;

		}

		public async Task<IEnumerable<Product>> GetAllProducts()
		{
			var products = await _productsRepository.AllProducts();
			return products.ToList();
		}

		public async Task<IEnumerable<CategoryModel>> GetCategories()
		{
			var categories = await _productsRepository.GetCategories();
			var mappedCategories = _mapper.Map<IEnumerable<CategoryModel>>(categories);
			return mappedCategories;
		}

		public async Task<IEnumerable<ProductInStore>> GetAllProductsWithCategories()
		{

			var productListFromRepo = await _productsRepository.AllProductsWithCategories();
			var mappedProducts = _mapper.Map<IEnumerable<ProductInStore>>(productListFromRepo);
			return mappedProducts;
		}

		public async Task AddProduct(ProductInStore newProduct)
		{
			var mappedProduct = _mapper.Map<Product>(newProduct);

			await _productsRepository.AddNewProduct(mappedProduct);
			

		}

		public async Task<ProductInStore?> GetProductById (int id)
		{

			var SelectedProduct = _mapper.Map<ProductInStore>(await _productsRepository.GetProductById(id));
			
			return SelectedProduct;
		}

		public async Task EditProduct(ProductInStore Selectedproduct)
		{

			var mappedProduct = _mapper.Map<Product>(Selectedproduct);




			await _productsRepository.EditProduct(mappedProduct);


		}
	}
}
