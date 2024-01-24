using AutoMapper;
using E_Commerce.Data.DbInitializer;
using E_Commerce.Data.Repository;
using E_Commerce.Services;
using E_Commerce.ViewModels.AutoMapper;
using E_Commerce_CORE_MVC.MyDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<OnlineShopDbContext>(options =>
{
	options.UseSqlServer(
		builder.Configuration["ConnectionStrings:OnlineShopConnectionString"]
		);
});


//Start Auto Mapper Configurations
builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

OnlineShopDbInitializer.Unseed(app);

OnlineShopDbInitializer.Seed(app);
app.Run();
