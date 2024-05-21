using System.ComponentModel.DataAnnotations;

namespace SububanMedicalGroupSMGWebApp.Models.DomainModels
{
    public class Speciality
    {
        [Key]
        public int SpecialityID { get; set; }

        [Required(ErrorMessage = "Please enter a Speciality.")]
        public string Specialities { get; set; } = string.Empty;
    }
}
