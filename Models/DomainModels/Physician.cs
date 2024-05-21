using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace SububanMedicalGroupSMGWebApp.Models.DomainModels
{
    public class Physician
    {
        public int PhysicianID { get; set; }
        [Required(ErrorMessage = "Select the category.")]

        public int SpecialityID { get; set; }
        public int ClinicId { get; set; }

        [Required(ErrorMessage = "Enter FirstName.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Enter LastName.")]
        public string LastName { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Enter DOB.")]
        public DateTime DateofBirth { get; set; }

        [Required(ErrorMessage = "Select Gender.")]
        public string Gender { get; set; } = string.Empty;

        [Required(ErrorMessage = "Enter Languages.")]
        public string Language { get; set; } = string.Empty;
        [ValidateNever]
        public Clinic Clinic { get; set; } = null!;

        [ValidateNever]
        public Speciality Specialities { get; set; } = null!;
    }
}
