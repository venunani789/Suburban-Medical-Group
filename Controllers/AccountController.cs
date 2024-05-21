using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SububanMedicalGroupSMGWebApp.Models.DomainModels;
using SububanMedicalGroupSMGWebApp.Models.ViewModels;

namespace SububanMedicalGroupSMGWebApp.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> _user;
        private SignInManager<User> _signIn;
        public AccountController(UserManager<User> user, SignInManager<User> signIn)
        {
            _user = user;
            _signIn = signIn;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login(string returnURL = "")
        {
            var login = new LoginViewModel
            {
                ReturnUrl = returnURL 
            };
            return View(login);
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                var res = await _signIn.PasswordSignInAsync(
                    login.Username,
                    login.Password, 
                    isPersistent: login.RememberMe,
                    lockoutOnFailure: false
                );

                if (res.Succeeded)
                {
                    if (!string.IsNullOrEmpty(login.ReturnUrl) && Url.IsLocalUrl(login.ReturnUrl))
                    {
                        return Redirect(login.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid username/password.");
            return View(login);
        }

        public ViewResult AccessDenied()
        {
            return View();
        }

        public IActionResult ChangePassword()
        {
            var change = new ChangePasswordViewModel
            {
                Username = User.Identity?.Name ?? ""
            };
            return View(change);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel change)
        {
            if (ModelState.IsValid)
            {
                User USER = await _user.FindByNameAsync(change.Username);
                var res = await _user.ChangePasswordAsync(USER,
                    change.OldPassword, change.NewPassword);

                if (res.Succeeded)
                {
                    TempData["message"] = "Password changed successfully";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (IdentityError error in res.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(change);
        }
    }
}
