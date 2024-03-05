using AutoMapper;
using E_Commerce.Data.DbInitializer;
using E_Commerce.Data.Repository;
using E_Commerce.Services;
using E_Commerce.ViewModels.AutoMapper;
using E_Commerce_CORE_MVC.MyDbContext;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
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



//if i wanted to use the razor pages i have to add it to services using ...
builder.Services.AddRazorPages();


// you can introduce a temporary .. second cookie..


//builder.Services.AddAuthentication("cookie")

//first configuring or setting up the authentication service..
builder.Services.AddAuthentication(o =>
{
	o.DefaultScheme = "cookie";

	o.DefaultChallengeScheme = "oidc";

})
	//very explicit way of coding...
	//first authentication handler that handles the session management..
	.AddCookie(authenticationScheme: "cookie", optionsInstance =>
	{
		optionsInstance.Cookie.Name = "demo";
		optionsInstance.ExpireTimeSpan = TimeSpan.FromHours(8);

		optionsInstance.LoginPath = "/Login/LoginRazor";

		optionsInstance.AccessDeniedPath = "/Login/AccessDenied";
		//optionsInstance.ReturnUrlParameter = "/";

	})
	// second authentication handler which adds the protocol we want to use...
	.AddOpenIdConnect("oidc" , o =>
	{
		o.Authority = "https://demo.duendesoftware.com/";
		//o.ClientId = "login";

		o.ClientId = "interactive.confidential";

		o.ClientSecret = "secret";

		o.ResponseType = "code";

		o.ResponseMode = "query";




		o.Scope.Clear();

		o.Scope.Add("openid");

		o.Scope.Add("profile");
		o.Scope.Add("email");
		o.Scope.Add("api");
		o.Scope.Add("offline_access");

		o.SaveTokens = true;
		//o.ClaimActions.Clear();

		//removes mapped values 
		o.MapInboundClaims = false;


		o.Events = new OpenIdConnectEvents()
		{
			//OnRedirectToIdentityProvider = "";
			//OnRedirectToIdentityProviderForSignOut = "";
		
			
		};


	});
	//.AddCookie("temp")
	//.AddGoogle("Google", o =>
	//{
	//	o.ClientId = "731422978590-tl0flhj10pvtm103uulqm86l72hs1dps.apps.googleusercontent.com";
	//	o.ClientSecret = "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";

//	//by default ths path will be (the callback path) => /signin-google

//	//you can change the value...
//	//o.CallbackPath = "/signin-google";


//	//how to validate and what comes back ,,, then start a session using our cookie handler...

//	//so basically the google handler will hand of the session management to another handler that is cookie handler..


//	// basically you are saying once you're done here... once you're done validating user from google.. add the cookie..

//	//the cookie handler is a way to start session but in the first demo we should've compared the values submitted by user in the form and compare it with thte database..

//	//if we comment it out it will configure whatever is the default scheme which is cookie..

//	o.SignInScheme = "temp";


//});




builder.Services.AddAuthorization(options =>
{
	options.AddPolicy("ManageCustomers", policy =>
	{
		policy.RequireAuthenticatedUser();

		policy.RequireClaim("department", "sales");

		policy.RequireClaim("status", "senior");

	});
});


//Start Auto Mapper Configurations
builder.Services.AddAutoMapper(typeof(MappingProfile));

//creating the application host..
var app = builder.Build();


//adding a bunch of middlewares...

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

//redirecting http request to https.
app.UseHttpsRedirection();




// uses a bunch of files. in wwwroot js , css etc..
app.UseStaticFiles();

//turn incoming urls to endpoints..
app.UseRouting();

// maps endpoints to the pages we have in the project... but again this is for razor pages.. (and since we're using mvc only (views) we don't need it)...
app.MapRazorPages()
	.RequireAuthorization();
//if i made this it will mean that all razorpages will require authroization
//app.MapRazorPages().RequireAuthorization();


//you have to use the app.UseAuthentication middleware before the authorization middleware.


//useAuthentication middleware gets the incoming request and tries to get a user object (claim)

app.UseAuthentication();
app.UseAuthorization();




app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

//OnlineShopDbInitializer.Unseed(app);

OnlineShopDbInitializer.Seed(app);
app.Run();
