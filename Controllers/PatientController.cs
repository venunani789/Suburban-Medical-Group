using Microsoft.AspNetCore.Mvc;

namespace SububanMedicalGroupSMGWebApp.Controllers
{
    public class PatientController : Controller
    {
        
        public IActionResult ScheduletheAppointment()
        {
            return Content("MainHomePage - Patient Controller - Schedule the Appointment");
        }
        public IActionResult MessagingPhysician()
        {
            return Content("MainHomePage - Patient Controller -  Messaging Physician");
        }
        public IActionResult TestResults()
        {
            return Content("MainHomePage - Patient Controller - TestResults");
        }
        public IActionResult FillPrescription()
        {
            return Content("MainHomePage - Patient Controller - Fill Prescription");
        }
        public IActionResult RequestmedicalRecord()
        {
            return Content("MainHomePage -  Patient Controller - Request medical Record");
        }
        public IActionResult PayBill()
        {
            return Content("MainHomePage - Patient Controller - PayBill");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
