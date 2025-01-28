using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RCH_HIS.Models;

namespace RCH_HIS.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new();

        public string? ReturnUrl { get; set; }

        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            ReturnUrl = returnUrl;

            if (!ModelState.IsValid)
            {
                // Return the view with validation errors
                return Page();
            }

            // Attempt to sign in the user
            var result = await _signInManager.PasswordSignInAsync(Input.NumberField.ToString(), Input.Password, Input.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                // Redirect to the return URL or a default page
                return LocalRedirect(returnUrl ?? "/");
            }

            // Handle login failures
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return Page();
        }
    }
}
