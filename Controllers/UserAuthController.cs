
using AcademyMVC.Data;
using AcademyMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AcademyMVC.Controllers
{
    public class UserAuthController : Controller
    {
        private  readonly UserManager<ApplicationUser> _userManager;
        private  readonly SignInManager<ApplicationUser> _signManager;
        private readonly ApplicationDbContext _context;

        public UserAuthController(SignInManager<ApplicationUser> signManager, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _signManager = signManager;
            _context = context;
            _userManager = userManager;
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login( LoginModel loginModel)
        {
            loginModel.LoginInValid = "true";
            if (ModelState.IsValid)
            {
                var result = await _signManager.PasswordSignInAsync(loginModel.Email,loginModel.Password,loginModel.RememberMe,lockoutOnFailure:false);
                if (result.Succeeded)
                {
                    loginModel.LoginInValid = "";
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Login attemp");
                }

            }
            return PartialView("_UserLoginPartial",loginModel);
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await _signManager.SignOutAsync();
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
