using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Commerce_CORE_MVC.Pages.Login
{
    [AllowAnonymous]
    public class GoogleModel : PageModel
    {
        public IActionResult OnGet(string ReturnUrl)
        {
            //await HttpContext.ChallengeAsync("Google");

            //basically microsoft created action results for us..



            // 2 things  ... 1 => always check that returned url is local ..
            // second you can always add additional properties so that you can later use in the cookie session..

            if(!Url.IsLocalUrl(ReturnUrl))
            {
                throw new Exception("Invalid return url");
            }

            var props = new AuthenticationProperties
            {
                RedirectUri = ReturnUrl
            };

            //and then pass it to the challenge action method..
            return Challenge(props, "Google");
        }
    }
}
