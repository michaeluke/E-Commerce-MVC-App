using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Commerce_CORE_MVC.Pages.Secure
{
    //manageCustomers is the policty we configured earlier..
    //[Authorize("ManageCustomers")]
	[Authorize]
	public class SecuredPageModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
