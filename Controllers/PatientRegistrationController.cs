using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using SububanMedicalGroupSMGWebApp.Models;
using SububanMedicalGroupSMGWebApp.Models.DataLayer;
using SububanMedicalGroupSMGWebApp.Models.DomainModels;
using SububanMedicalGroupSMGWebApp.Models.ViewModels;

namespace SububanMedicalGroupSMGWebApp.Controllers
{
    public class PatientRegistrationController : Controller
    {
        private SMGWebAppContext context;
        private UserManager<User> _user;
        private SignInManager<User> _signIn;
        public PatientRegistrationController(SMGWebAppContext ctx, UserManager<User> user, SignInManager<User> signIn)
        {
            context = ctx;
            _user = user;
            _signIn = signIn;
        }
        [HttpGet]
        public IActionResult Index() => View();
        
        public IActionResult Login() => View();
        [HttpGet]
        public IActionResult Registration() => View();

        [HttpPost]
        public async Task<IActionResult> Registration(PatientRegistration patientRegistration)
        {
            if (TempData["okEmail"] == null)
            {
                string msg = Check.EmailExists(context, patientRegistration.EmailAddress);
                if (!String.IsNullOrEmpty(msg))
                {
                    ModelState.AddModelError(nameof(patientRegistration.EmailAddress), msg);
                }
            }

            if (ModelState.IsValid)
            {
                string IsdefaultUserId = $"{patientRegistration.FirstName}{patientRegistration.LastName}";
                string IsdefaultPassword = $"{patientRegistration.FirstName}{patientRegistration.LastName}123";
                var USER = new User { UserName = IsdefaultUserId, Email = patientRegistration.EmailAddress };
                var res = await _user.CreateAsync(USER, IsdefaultPassword);
                if (res.Succeeded)
                {
                    await _signIn.SignInAsync(USER, isPersistent: false);
                    context.PatientRegistrations.Add(patientRegistration);
                    context.SaveChanges();
                    TempData["RegitrationSuccessMessage"] = "Your registration has been received. We will assess your application and email you the notification with login ID and temporary password";
                    return RedirectToAction("Registration");
                }
                else
                {
                    foreach (var error in res.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                return View(patientRegistration);
            }
            else
            {
                return View(patientRegistration);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                var result = await _signIn.PasswordSignInAsync(
                    login.Username, login.Password, isPersistent: login.RememberMe,
                    lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(login.ReturnUrl) &&
                        Url.IsLocalUrl(login.ReturnUrl))
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
        public IActionResult Welcome() => View();
        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _signIn.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Login(string returnURL = "")
        {
            var login = new LoginViewModel 
            { ReturnUrl = returnURL };
            return View(login);
        }
    }
}
