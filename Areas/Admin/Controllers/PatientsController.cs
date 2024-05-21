using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SububanMedicalGroupSMGWebApp.Models.DataLayer;
using SububanMedicalGroupSMGWebApp.Models.DomainModels;
using System.Data;

namespace SububanMedicalGroupSMGWebApp.Areas.Admin.Controllers
{

    [Authorize(Roles = "Admin")]

    [Area("Admin")]
    public class PatientsController : Controller
    {
        private SMGWebAppContext context;
        public PatientsController(SMGWebAppContext ctx)
        {
            context = ctx;
        }

        [Route("[area]/[controller]s/{id?}")]
        public IActionResult List()
        {
            List<PatientRegistration> patientRegistrations = new List<PatientRegistration>(); // Initialize here
            patientRegistrations = context.PatientRegistrations.OrderBy(p => p.ID).ToList();
            return View(patientRegistrations);
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }
        public IActionResult Patients()
        {
            return Content("AdminArea - Patient Controller - Patients");
        }
    }
}
