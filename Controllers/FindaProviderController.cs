using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using SububanMedicalGroupSMGWebApp.Models;
using SububanMedicalGroupSMGWebApp.Models.DataLayer;
using SububanMedicalGroupSMGWebApp.Models.DataLayer.Repositories;
using SububanMedicalGroupSMGWebApp.Models.DomainModels;
using SububanMedicalGroupSMGWebApp.Models.ExtensionMethods;
using SububanMedicalGroupSMGWebApp.Models.Grid;
using SububanMedicalGroupSMGWebApp.Models.ViewModels;

namespace SububanMedicalGroupSMGWebApp.Controllers
{
    public class FindaProviderController : Controller
    {
        private SMGWebAppContext context;
        private List<Speciality> speciality;
        private Repository<Physician> data { get; set; }

        public FindaProviderController(SMGWebAppContext ctx)
        {
            context = ctx;
            speciality = context.Specialities
                .OrderBy(c => c.SpecialityID)
                .ToList();
            data = new Repository<Physician>(ctx);
        }
        //public IActionResult List(string id)
        //{
        //    var filter = new Filters(id);
        //    ViewBag.Filter = filter;
        //    ViewBag.Specialities = context.specialities.ToList();
        //    ViewBag.Clinics = context.Clinics.ToList();
        //    ViewBag.Filterds = Filter.Filterds;

        //    IQueryable<Physician> query = context.physicians.Include(t => t.Speciality).Include(t => t.Clinic);

        //    if (filter.HasSpecialities)
        //    {
        //        query = query.Where(t => t.SpecialitiesID.ToString() == filter.SpecialitiesID);
        //    }

        //    if (filter.HasClinics)
        //    {
        //        query = query.Where(t => t.ClinicID.ToString() == filter.clinicID);
        //    }

        //    if (filter.HasGenders)
        //    {
        //        if (filter.Genders == "Male") query = query.Where(t => t.Gender == filter.Genders);
        //        else if (filter.Genders == "Female") query = query.Where(t => t.Gender == filter.Genders);
        //    }
        //    var physicians = query.OrderBy(t => t.Gender).ToList();
        //    var wbAppViewModel = new WbAppViewModel
        //    {
        //        Physicians = physicians,
        //        Clinics = ViewBag.Clinics,
        //        Specialities = ViewBag.Specialities
        //    };
        //    return View(wbAppViewModel);
        //}
        public ViewResult Index(SMGViewModel model, SMGGridData values)
        {
            string combinedValues = $"{model.ActiveSpecs},{model.ActiveGens},{model.ActiveTowns}";
            string[] filter = combinedValues.Split(',');
            string id = string.Join('-', filter);
            var filters = new Filters(id);
            ViewBag.Filter = filters;
            // store active conference and division in session
            var session = new SMGSession(HttpContext.Session);
            session.SetActiveSpecs(model.ActiveSpecs);
            session.SetActiveGens(model.ActiveGens);
            session.SetActiveTowns(model.ActiveTowns);

            // if no count value in session, use data in cookie
            // to restore fave teams in session 
            int? count = session.GetMyPhycCount();
            if (!count.HasValue)
            {
                var cookies = new SMGCookies(Request.Cookies);
                string[] ids = cookies.GetMyPhycIds();

                if (ids.Length > 0)
                {
                    var myteams = context.Physician
                        .Include(t => t.Clinic)
                        .Include(t => t.Specialities)
                        .Where(t => ids.Contains(t.PhysicianID.ToString()))
                        .ToList();
                    session.SetMyPhyc(myteams);
                }
            }

            // get conferences and divisions from database
            //model.Physicians = context.physicians.ToList();
            //model.Clinics = context.Clinics.ToList();
            //model.Specialities = context.Specialities.ToList();
            ViewBag.GenderFilterValues = Filters.GenderFilterValues;
            var options = new QueryOptions<Physician>
            {
                Includes = "Specialities, Clinic",
                OrderByDirection = values.SortDirection,
                PageNumber = values.PageNumber,
                PageSize = values.PageSize
            };
            if (model.ActiveSorter == "Loc")
            {
                if (values.IsSortByLocation)
                {
                    options.OrderBy = b => b.Clinic.AddressTown;
                    options.OrderByDirection = "asc";
                }
            }
            else if (model.ActiveSorter == "A-Z")
            {
                if (values.IsSortByLastName)
                {
                    options.OrderBy = b => b.LastName;
                    options.OrderByDirection = "asc";
                }
            }
            else if (model.ActiveSorter == "Z-A")
            {
                if (values.IsSortByLastName)
                {
                    options.OrderBy = b => b.LastName;
                    options.OrderByDirection = "desc";

                }
            }
            // get teams from database - filter by conference and division
            //IQueryable<Physician> query = context.physicians.OrderBy(t => t.FirstName);
            IQueryable<Physician> query = context.Physician.Include(t => t.Specialities).Include(t => t.Clinic);
            if (model.ActiveSpecs != "all" && model.ActiveTowns != "all")
            {
                options.Where = t => t.Specialities.SpecialityID.ToString() == model.ActiveSpecs.ToLower() && t.Clinic.ClinicId.ToString() == model.ActiveTowns.ToLower();
            }
            if (model.ActiveSpecs != "all")
            {
                options.Where = t => t.Specialities.SpecialityID.ToString() == model.ActiveSpecs.ToLower();
            }
            if (model.ActiveTowns != "all")
            {
                options.Where = t => t.Clinic.ClinicId.ToString() == model.ActiveTowns.ToLower();
            }

            if (filters.HasGenders)
            {
                options.Where = t => t.Gender == filters.Gender;
            }

            //model.Physicians = query.ToList();
            model.Physicians = query.OrderBy(t => t.Gender).ToList();

            SMGViewModel sMGViewModel = new SMGViewModel
            {
                Physic = data.List(options),
                Clinics = context.Clinics.ToList(),
                Specialities = context.Specialities.ToList(),
                CurrentRoute = values,
                TotalPages = values.GetTotalPages(data.Count),
                ActiveSpecs = model.ActiveSpecs,
                ActiveGens = model.ActiveGens,
                ActiveTowns = model.ActiveTowns,
                ActiveSorter = model.ActiveSorter
            };
            //model.Physicians = query.OrderBy(t => t.Gender).ToList();
            return View(sMGViewModel);
        }
        
        public IActionResult Details(string id)
        {
            var session = new SMGSession(HttpContext.Session);
            var model = new SMGViewModel
            {
                Physician = context.Physician
                    .Include(t => t.Specialities)
                    .Include(t => t.Clinic)
                    //.Include(t => t.Gender)
                    .FirstOrDefault(t => t.PhysicianID.ToString() == id) ?? new Physician(),
                ActiveSpecs = session.GetActiveSpecs(),
                ActiveGens = session.GetActiveGens(),
                ActiveTowns = session.GetActiveTowns()
            };
            return View(model);
        }

    }
}
