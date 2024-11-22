using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PROG_POE.Models;
using System.Threading.Tasks;

//    Aman Adams
//    ST10290748
//    Prog2B POE PART 3
//    Reference: Used W3 Schools for Format and Style
namespace PROG_POE.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        // Login page
        public IActionResult Login() => View();

        // Handle Login
        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, password, isPersistent: false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    if (roles.Contains("Lecturer"))
                        return RedirectToAction("SubmitClaim", "LecturerDashboard", "Lecturer");
                    if (roles.Contains("Coordinator"))
                        return RedirectToAction( "ApproveClaim","CoordinatorDashboard", "Coordinator");
                    if (roles.Contains("HR"))
                        return RedirectToAction("ApproveClaim","HRDashboard", "HR");
                }
            }

            ModelState.AddModelError("", "Invalid login attempt.");
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        //{
        //    returnUrl ??= Url.Content("~/");

        //    if (ModelState.IsValid)
        //    {
        //        var user = await _userManager.FindByNameAsync(model.Username);
        //        if (user != null)
        //        {
        //            var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);

        //            if (result.Succeeded)
        //            {
        //                return RedirectToAction("Dashboard", "Lecturer"); // Redirect to the lecturer dashboard
        //            }
        //        }

        //        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        //    }

        //    return View(model);
        //}

        // Logout page
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home"); // Redirect to home page after logout
        }

        // Register page
        public IActionResult Register() => View();

        // Handle Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Username, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, model.Role); // Assign role to the user (Lecturer, Coordinator, etc.)

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Dashboard", "Lecturer"); // Redirect after successful registration
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }
    }
}

