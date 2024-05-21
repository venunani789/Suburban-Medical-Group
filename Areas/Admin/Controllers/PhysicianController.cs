using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SububanMedicalGroupSMGWebApp.Models;
using SububanMedicalGroupSMGWebApp.Models.DataLayer;
using SububanMedicalGroupSMGWebApp.Models.DomainModels;
using SububanMedicalGroupSMGWebApp.Models.ViewModels;
using System.Data;

namespace SububanMedicalGroupSMGWebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]

    [Area("Admin")]
    public class PhysicianController : Controller
    {
        private SMGWebAppContext context;
        private List<Speciality> Speciality;
        public PhysicianController(SMGWebAppContext ctx)
        {
            context = ctx;
            Speciality = context.Specialities.OrderBy(c => c.SpecialityID).ToList();
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("[area]/[controller]s/{id?}")]
        public IActionResult List(string id)
        {
            var filters = new Filters(id);
            ViewBag.Filters = filters;
            ViewBag.Specialities = context.Specialities.ToList();
            ViewBag.Clinics = context.Clinics.ToList();
            ViewBag.GenderFilters = Filters.GenderFilterValues;

            IQueryable<Physician> query = context.Physician
                .Include(t => t.Specialities)
                .Include(t => t.Clinic);

            if (filters.HasSpeciality)
            {
                query = query.Where(t => t.SpecialityID.ToString() == filters.SpecialityId);
            }

            if (filters.HasClinic)
            {
                query = query.Where(t => t.ClinicId.ToString() == filters.ClinicId);
            }

            if (filters.HasGenders)
            {
                if (filters.Gender == "Male")
                    query = query.Where(t => t.Gender == filters.Gender);
                else if (filters.Gender == "Female")
                    query = query.Where(t => t.Gender == filters.Gender);
            }

            var physicians = query.OrderBy(t => t.Gender).ToList();

            var viewModel = new PhysicianViewModel
            {
                Physicians = physicians,
                Clinics = ViewBag.Clinics, // Set the list of clinics from ViewBag
                SpecialityTypes = ViewBag.Specialities // Assuming you have a property for SpecialityTypes in your ViewModel
                                                       // Add other properties as needed
            };

            return View(viewModel);
            //var viewModel = new PhysicianViewModel
            //{
            //    Clinics = context.Clinics.OrderBy(g => g.AddressTown).ToList(),
            //    SpecialityTypes = Speciality
            //};

            //if (id == "all")
            //{
            //    viewModel.Physicians = context.Physician.OrderBy(p => p.PhysicianID).ToList();
            //}
            //else
            //{
            //    viewModel.Physicians = context.Physician
            //        .Where(p => p.Specialities.Specialities == id)
            //        .OrderBy(p => p.PhysicianID)
            //        .ToList();
            //}

            //viewModel.Physicians = context.Physician.OrderBy(p => p.PhysicianID).ToList();
            //ViewBag.Clinic = context.Clinics.OrderBy(g => g.AddressTown).ToList();
            //ViewBag.SelectedSpecialityName = Speciality;

        }
        [HttpPost]
        public RedirectToActionResult Filter(string[] filter)
        {
            string id = string.Join('-', filter);
            return RedirectToAction("List", new { ID = id });
        }
        [HttpGet]
        public IActionResult Add()
        {
            Physician physician = new Physician();
            ViewBag.Action = "Add";
            ViewBag.Clinic = context.Clinics.OrderBy(g => g.AddressTown).ToList();
            ViewBag.SpecialityTypes = Speciality;
            return View("AddUpdate", physician);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Physician physician = context.Physician.Include(p => p.Specialities).FirstOrDefault(p => p.PhysicianID == id) ?? new Physician();
            ViewBag.Clinic = context.Clinics.OrderBy(g => g.AddressTown).ToList();
            ViewBag.SpecialityTypes = Speciality;
            ViewBag.Action = "Update";
            return View("AddUpdate", physician);
        }

        [HttpPost]
        public IActionResult Update(Physician physician)
        {
            if (ModelState.IsValid)
            {
                if (physician.PhysicianID == 0){
                    context.Physician.Add(physician);
                    TempData["SuccessMessage"] = physician.FirstName + physician.LastName + " " + "Added Successfully";
                    TempData["HeaderMessage"] = "Added!";
                }
                else{
                    context.Physician.Update(physician);
                    TempData["SuccessMessage"] = physician.FirstName + physician.LastName + " " + "Updated Successfully";
                    TempData["HeaderMessage"] = "Updated";
                }
                
                context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Clinic = context.Clinics.OrderBy(g => g.AddressTown).ToList();
                ViewBag.SpecialityTypes = Speciality;
                ViewBag.Action = "Add";
                return View("AddUpdate", physician);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var physician1 = context.Physician.Find(id);
            TempData["SuccessMessage"] = physician1?.FirstName + physician1?.LastName + "Deleted Successfully";
            TempData["HeaderMessage"] = "Deleted!";
            Physician physician = context.Physician.FirstOrDefault(p => p.PhysicianID == id) ?? new Physician();
            return View(physician);
        }

        [HttpPost]
        public RedirectToActionResult Delete(Physician physician)
        {
            context.Physician.Remove(physician);
            context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
