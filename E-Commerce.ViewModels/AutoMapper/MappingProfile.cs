using AutoMapper;
using E_Commerce.Data.Entities;
using E_Commerce.Model.Models;
using E_Commerce_CORE_MVC.Models;

namespace E_Commerce.ViewModels.AutoMapper
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Product, ProductInStore>()
				 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
				  .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
				   .ForMember(dest => dest.InStock, opt => opt.MapFrom(src => src.InStock))
					.ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
				.ReverseMap();

			CreateMap<Category, CategoryModel>()
				 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
				  .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products))
				.ReverseMap();

			CreateMap<User, Customer>()
				.ReverseMap();
		}

	}
}
