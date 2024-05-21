using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SububanMedicalGroupSMGWebApp.Models.DataLayer;
using SububanMedicalGroupSMGWebApp.Models.DomainModels;
using System.Data;

namespace SububanMedicalGroupSMGWebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class ClinicController : Controller
    {
        private SMGWebAppContext context;
        private List<OpenHours> OpenHours;
        private List<Speciality> Speciality;
        public ClinicController(SMGWebAppContext ctx)
        {
            context = ctx;
            Speciality = context.Specialities.OrderBy(c => c.SpecialityID).ToList();
            OpenHours = context.openHours.OrderBy(c => c.OpenHoursId).ToList();
        }
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }
        [Route("[area]/[controller]s/{id?}")]
        public IActionResult List(string id = "All")
        {
            List<Clinic> clinic;
            if ("All" == id)
            {
                clinic = context.Clinics.OrderBy(p => p.ClinicId).ToList();
            }
            else
            {
                clinic = context.Clinics.Where(p => p.OpenHours.Hours == id).OrderBy(p => p.ClinicId).ToList();
            }
            ViewBag.Clinic = context.Clinics.OrderBy(g => g.AddressTown).ToList();
            ViewBag.SpecialityTypes = Speciality;
            return View(clinic);
        }

        [HttpGet]
        public IActionResult Add()
        {
            Clinic clinic = new Clinic();
            ViewBag.Action = "Add";
            ViewBag.Clinic = context.Clinics.OrderBy(g => g.AddressTown).ToList();
            ViewBag.OpenHours = OpenHours;
            return View("AddUpdate", clinic);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Clinic clinic = context.Clinics.Include(p => p.OpenHours).FirstOrDefault(p => p.ClinicId == id) ?? new Clinic();
            ViewBag.Clinic = context.Clinics.OrderBy(g => g.AddressTown).ToList();
            ViewBag.OpenHours = OpenHours;
            ViewBag.SpecialityTypes = Speciality;
            ViewBag.Action = "Update";
            return View("AddUpdate", clinic);
        }

        [HttpPost]
        public IActionResult Update(Clinic clinic)
        {
            if (ModelState.IsValid)
            {
                if (clinic.ClinicId == 0) { 
                    context.Clinics.Add(clinic);
                    TempData["SuccessMessage"] = clinic.AddressTown + " Clinic " + "Added Successfully";
                    TempData["HeaderMessage"] = "Added!";
                }
                else { 
                    context.Clinics.Update(clinic);
                    TempData["SuccessMessage"] = clinic.AddressTown + " Clinic " + "Updated Successfully";
                    TempData["HeaderMessage"] = "Updated!";
                }
                context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Clinic = context.Clinics.OrderBy(g => g.AddressTown).ToList();
                ViewBag.OpenHours = OpenHours;
                ViewBag.SpecialityTypes = Speciality;
                ViewBag.Action = "Add";
                return View("AddUpdate", clinic);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var clinic1 = context.Clinics.Find(id);
            TempData["SuccessMessage"] = clinic1?.AddressTown+ " Clinic " + "Deleted Successfully";
            TempData["HeaderMessage"] = "Deleted!";
            Clinic clinic = context.Clinics.FirstOrDefault(p => p.ClinicId == id) ?? new Clinic();
            return View(clinic);
        }

        [HttpPost]
        public RedirectToActionResult Delete(Clinic clinic)
        {
            context.Clinics.Remove(clinic);
            context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
