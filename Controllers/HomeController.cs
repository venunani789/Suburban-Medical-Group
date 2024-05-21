using Microsoft.AspNetCore.Mvc;
using SububanMedicalGroupSMGWebApp.Models;
using System.Diagnostics;

namespace SububanMedicalGroupSMGWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LoginPage()
        {
            return View();
        }
        public IActionResult Service()
        {
            return Content("MainHomePage - Home Controller - Service");
        }
        public IActionResult FindAProvider()
        {
            return Content("MainHomePage - Home Controller - FindProvider");
        }
        public IActionResult Resources()
        {
            return Content("MainHomePage - Home Controller - Resources");
        }
        public IActionResult ImmediateCare()
        {
            return Content("MainHomePage - Home Controller - ImmediateCare");
        }
    }
}