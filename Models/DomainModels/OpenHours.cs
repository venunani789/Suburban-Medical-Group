using System.ComponentModel.DataAnnotations;

namespace SububanMedicalGroupSMGWebApp.Models.DomainModels
{
    public class OpenHours
    {
        public int OpenHoursId { get; set; }
        [Required(ErrorMessage = "Please Select OpenHours.")]
        public string Hours { get; set; } = string.Empty;
        //public ICollection<Clinic> Clinics { get; set; } = null!;
    }
}
