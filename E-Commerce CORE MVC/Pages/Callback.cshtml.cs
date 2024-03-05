using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;


//note a cookie session has claims principal and other metadata that we care about..
namespace E_Commerce_CORE_MVC.Pages
{
	[AllowAnonymous]
	public class CallbackModel : PageModel
	{
		public async Task<IActionResult> OnGet()
		{

			//read the outcome of external authN

			var result = await HttpContext.AuthenticateAsync("temp"); //sending the scheme as an argument

			//someone outside our app called this attempt..
			if (!result.Succeeded)
			{
				throw new Exception("ext authN failed");
			}

			var externalUser = result.Principal;

			var sub = externalUser.FindFirst(ClaimTypes.NameIdentifier).Value;



			var name = externalUser.FindFirst(ClaimTypes.Name).Value;
			var email = externalUser.FindFirst(ClaimTypes.Email).Value;

			//issuer is the validation issuer. which is the temp cookie.
			var issuer = result.Properties.Items["scheme"];


			//run our logic..

			//first time user vs returning user.

			//sign-in the user into our app..

			var claims = new List<Claim>
			{
				new("sub" , "123"),
				new("name", name),
				new("email", email),
				new("role", "Admin")
			};




			var CIdentity = new ClaimsIdentity(claims, issuer, "name", "role");

			// Wrap the claims identity into a claims principal...

			var cp = new ClaimsPrincipal(CIdentity);

			await HttpContext.SignInAsync(cp);

			await HttpContext.SignOutAsync("temp");


			// ultimate returnUrl
			var uru = result.Properties.Items["uru"];

			return Redirect(uru);
	
		}
	}
}
