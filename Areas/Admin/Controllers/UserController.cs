using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SububanMedicalGroupSMGWebApp.Areas.Admin.Models;
using SububanMedicalGroupSMGWebApp.Models.DomainModels;

namespace SububanMedicalGroup.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class UserController : Controller
    {

        private UserManager<User> _user;
        private RoleManager<IdentityRole> _role;


        public UserController(UserManager<User> userM,
           RoleManager<IdentityRole> roleM)
        {
            _user = userM;
            _role = roleM;
        }

       


        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            User USER = await _user.FindByIdAsync(id);
            if (USER != null)
            {
                IdentityResult res = await _user.DeleteAsync(USER);
                if (!res.Succeeded)
                {
                    string errMsg = "";
                    foreach (IdentityError err in res.Errors)
                    {
                        errMsg += err.Description + " | ";
                    }
                    TempData["message"] = errMsg;
                }
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> RemoveRole(string id, string roleid)
        {
            User USER = await _user.FindByIdAsync(id);
            var res = await _user.RemoveFromRoleAsync(USER, roleid);
            if (res.Succeeded) 
            { 
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Index()
        {
            List<User> USER = new List<User>();
            foreach (User u in _user.Users)
            {
                u.Rolename = await _user.GetRolesAsync(u);
                USER.Add(u);
            }
            Userviewmodel user = new Userviewmodel
            {
                Users = USER,
                Roles = _role.Roles
            };
            return View(user);
        }
        
        public async Task<IActionResult> addOtherRole(string UserID, string RoleId)
        {
            IdentityRole AdminROle = await _role.FindByIdAsync(RoleId);
            User USER = await _user.FindByIdAsync(UserID);
            await _user.AddToRoleAsync(USER, AdminROle.Name);
            return RedirectToAction("Index");
        }
        public IActionResult AddRole(string id)
        {
            ViewBag.ROLE = _role.Roles;
            ViewBag.USERUID = id;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id)
        {
            IdentityRole ROLE = await _role.FindByIdAsync(id);
            var res = await _role.DeleteAsync(ROLE);
            if (res.Succeeded)
            {
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> CreateAdminRole()
        {
            var res = await _role.CreateAsync(new IdentityRole("Admin"));
            if (res.Succeeded)
            {
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> SaveRole(string RoleName)
        {
            var res = await _role.CreateAsync(new IdentityRole(RoleName));
            if (res.Succeeded) 
            {
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Add(Registers register)
        {
            if (ModelState.IsValid)
            {
                var USER = new User { UserName = register.Username };
                var res = await _user.CreateAsync(USER, register.Password);

                if (res.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var err in res.Errors)
                    {
                        ModelState.AddModelError("", err.Description);
                    }
                }
            }
            return View(register);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        
    }
}
