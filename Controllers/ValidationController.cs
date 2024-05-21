using Microsoft.AspNetCore.Mvc;
using SububanMedicalGroupSMGWebApp.Models;
using SububanMedicalGroupSMGWebApp.Models.DataLayer;

namespace SububanMedicalGroupSMGWebApp.Controllers
{
    public class ValidationController : Controller
    {
        private SMGWebAppContext context;
        public ValidationController(SMGWebAppContext ctx) => context = ctx;

        public JsonResult CheckEmail(string emailAddress)
        {
            string msg = Check.EmailExists(context, emailAddress);
            if (string.IsNullOrEmpty(msg))
            {
                TempData["okEmail"] = true;
                return Json(true);
            }
            else return Json(msg);
        }
        public JsonResult SocialSecurityNumberRemote(string SocialSecurityNumber)
        {
            string msg = Check.SocialSecurityNumberExists(context, SocialSecurityNumber);
            if (string.IsNullOrEmpty(msg))
            {
                TempData["okSocialSecurityNumber"] = true;
                return Json(true);
            }
            else return Json(msg);
        }
    }
}
