using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace E_Commerce_CORE_MVC.Pages.Secure
{
    //manageCustomers is the policty we configured earlier..
    //[Authorize("ManageCustomers")]
    [Authorize]
    //[AllowAnonymous]
    
	public class SecuredPageModel : PageModel
    {

        public SessionData Session { get; set; }


        public async void OnGet()
        {
            //retrieve current session.. (after authentication is done through identity server...


            //authenticate async holds the current authentication request and returns the result..

            var authenticateResult = await HttpContext.AuthenticateAsync();

            var userClaims = authenticateResult.Principal.Claims;

            var metadata = authenticateResult.Properties.Items;


            Session = new SessionData(userClaims, metadata);


        }


        public record SessionData
        (
            IEnumerable<Claim> Claims,
            IDictionary<string, string> Metadata
        );
    }
}
