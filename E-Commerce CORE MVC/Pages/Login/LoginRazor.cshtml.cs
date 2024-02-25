using E_Commerce.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace E_Commerce_CORE_MVC.Pages.Login
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {


        private readonly IProductService _productService;


        [BindProperty]
        public string UserName { get; set; }


        [BindProperty]
        public string Password { get; set; }


        [BindProperty(SupportsGet = true)]
        public string ReturnUrl { get; set; }

        public LoginModel(IProductService productService)
        {
            _productService = productService;
        }

        public void OnGet()
        {
        }

        //task is just an asynchronous operation  .. Iactionresult represents the result of the action method...
        public async Task<IActionResult> OnPostAsync()
        {

            //IF CONDITION HERE GO COMPARE DATA ENTERED BY USER BY DATA EXISTING IN DATABASE...
            if (ModelState.IsValid)
            {
                //CREATE IDENTITY FOR USER BY CREATING CLAIMS..
                //

                //JOB HERE IS TO SIGN IN USER.. MEANING START A SESSION..

                //MOST IMPORTANT CLAIM IS SUBJECT IDENTIFIER ( UNIQUE IDENTIFIER FOR THE USER..


                var Claims = new List<Claim>
                {
					//here you define the guide or the identifiers you want to use in app.

					//to get from database.. credentials
					new(type: "sub", value: "123"),


					//name to greet inside the app..

					new(type:"name", value:"Michael"),

                    new(type:"role", value: "Admin")





                };

                //now how to make it persistent by assigning the session values to a cookie...

                //there's better way to do this . don't put permissions into the session

                //use constructor before arguments

                //first argument is the list of claims..
                //second argument is the name of authentication

                //third is the claim that represents the name of the user.. 


                var CIdentity = new ClaimsIdentity(Claims, "pwd", "name", "role");

                // Wrap the claims identity into a claims principal...

                var cp = new ClaimsPrincipal(CIdentity);


                //OK THE QUESTION NOW IS... HOW TO START THE SESSION?

                //THERE'S AN ABSTRACTION LAYER THAT DIFFERENTIATES BETWEEN ALL AUTHENTICAN METHODS

                //THAT IS DEFINED IN THE PROGRAM.CS.... IT'S IN THE IAuthenticationService..


                //SO IM PASSING THE CLAIMSPRINCIPAL TO THE SIGNINASYNC WHICH IS THE IAUTHENTICATIONHTTPCONTEXTEXTENSIONS CLASS USING THE IAuthnticationService..

                //so this creates the cookie...
                await HttpContext.SignInAsync(cp);


                //after successfully creating the cookie we should re-direct the user to the page they tried to access in the first place...


                //it's very tempting to do that (redirect user this way) :: Don't do that! why?

                //you're opening your application for phishing attacks!!

                //vulenarability would be open redirect attack .. redirect user to a scam webpage..


                //how would an attacker exploit this??

                //They will send an email to your employees (click here on the link)..

                //https:/yourcompany/account/login?returnUrl=https:/evilAttacker.com/StealPassword etc..

                //they will login and login page will redirect them to evil.com to steal password 

                //saying invalid credentials so user will type credentials again..

                // SO WHAT TO DO? VALIDATE THAT THE RETURNURL BELONGS TO YOUR APPLICAITON

                // YOU DONT HAVE TO IMPLEMENT IT YOURSELF.. ASP.NET HAS YOU COVERED..


                return LocalRedirect(ReturnUrl);

                //return Redirect(returnUrl);


            }
            return Page();

        }
    }

}
