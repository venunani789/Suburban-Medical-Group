using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SububanMedicalGroupSMGWebApp.Models.DataLayer;
using SububanMedicalGroupSMGWebApp.Models.DomainModels;
using SububanMedicalGroupSMGWebApp.Models.ExtensionMethods;
using SububanMedicalGroupSMGWebApp.Models.ViewModels;

namespace SububanMedicalGroupSMGWebApp.Controllers
{
    public class FavoritesController : Controller
    {
        private SMGWebAppContext context;
        public FavoritesController(SMGWebAppContext ctx) => context = ctx;

        [HttpGet]
        public ViewResult Index()
        {
            var session = new SMGSession(HttpContext.Session);
            var model = new SMGViewModel
            {
                ActiveSpecs = session.GetActiveSpecs(),
                ActiveGens = session.GetActiveGens(),
                ActiveTowns = session.GetActiveTowns(),
                Physicians = session.GetMyPhyc()
            };

            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Add(Physician physician)
        {
            // get full team data from database
            physician = context.Physician
                 .Include(t => t.Specialities)
                 .Include(t => t.Clinic)
                 //.Include(t => t.Gender)
                 .Where(t => t.PhysicianID == physician.PhysicianID)
                 .FirstOrDefault() ?? new Physician();

            // add team to favorite teams in session and cookie
            var session = new SMGSession(HttpContext.Session);
            var cookies = new SMGCookies(Response.Cookies);

            var teams = session.GetMyPhyc();
            teams.Add(physician);
            session.SetMyPhyc(teams);        
            cookies.SetMyPhycIds(teams);

            // set add message
            TempData["message"] = $"{physician.FirstName} added to your favorites";

            // redirect to Home page
            return RedirectToAction("Index", "FindaProvider", 
                new {
                    ActiveSpecialities = session.GetActiveSpecs(),
                    ActiveGender = session.GetActiveGens(),
                    ActiveTowns = session.GetActiveTowns()
                });
        }

        [HttpPost]
        public RedirectToActionResult Delete()
        {
            // delete favorite teams from session and cookie
            var session = new SMGSession(HttpContext.Session);
            var cookies = new SMGCookies(Response.Cookies);

            session.RemoveMyPhyc();
            cookies.RemoveMyPhycIds();

            // set delete message
            TempData["message"] = "Favorite physicians cleared";

            // redirect to Home page
            return RedirectToAction("Index", "FindaProvider",
                new {
                    ActiveSpecs = session.GetActiveSpecs(),
                    ActiveGens = session.GetActiveGens(),
                    ActiveTowns = session.GetActiveTowns()
                });
        }
    }
}