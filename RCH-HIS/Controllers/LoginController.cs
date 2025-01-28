using Microsoft.AspNetCore.Mvc;

namespace RCH_HIS.Controllers
{
    public class LoginController : Controller
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SubmitForm(InputModel input)
        {
            if (ModelState.IsValid)
            {
                // Process the valid data (e.g., save to database)
                return RedirectToAction("Success");
            }

            // If validation fails, return the form with validation messages
            return View(input);
        }
    }
}
