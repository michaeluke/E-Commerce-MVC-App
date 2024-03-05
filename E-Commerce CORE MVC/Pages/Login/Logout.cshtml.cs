using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Commerce_CORE_MVC.Pages.Login
{
	public class LogoutModel : PageModel
	{
		public async Task<IActionResult> OnGet()
		{
			//await HttpContext.SignOutAsync();



			//return Redirect("/");

			//var token = await HttpContext.GetTokenAsync("access_token");

			//then call your api...



			return SignOut("cookie", "oidc");
		}
	}
}
