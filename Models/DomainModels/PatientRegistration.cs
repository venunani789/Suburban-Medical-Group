using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;                      // for Remote attribute

namespace SububanMedicalGroupSMGWebApp.Models.DomainModels
{
    public class PatientRegistration
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Please enter your first name.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your last name.")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a username.")]
        [RegularExpression("^[a-zA-Z ]+$")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter an email address.")]
        [Remote("CheckEmail", "Validation")]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a date of birth.")]
        [Age(150, ErrorMessage = "DOB must be a past date and no more than 150 years past.")]
        public DateTime? DOB { get; set; }

        [RegularExpression(@"^\d{3}[-.]\d{3}[-.]\d{4}$", ErrorMessage = "Please enter a valid phone number(should contain digit and delimiter of “-“ or “.” only)")]
        public string PhoneNumber { get; set; } = string.Empty;

        [RegularExpression("^[a-zA-Z0-9 ]+$", ErrorMessage = "Please enter a valid home address(should contain letters in lower or upper case, digit, space only)")]
        public string HomeAddress { get; set; } = string.Empty;

        [RegularExpression(@"^\d{3}-\d{2}-\d{4}$", ErrorMessage = "Please enter a valid Social Security Number(should contain delimiter of “-“ only)")]
        [Remote("SocialSecurityNumberRemote", "Validation")]
        public string SocialSecurityNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a MedicalInsurance")]
        public string MedicalInsurance { get; set; } = string.Empty;
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public PatientStatus Status { get; set; } = PatientStatus.Pending;

    }
    public enum PatientStatus
    {
        Pending,
        Approved,
        Rejected
    }
}