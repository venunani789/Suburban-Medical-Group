using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace SububanMedicalGroupSMGWebApp.Models.DomainModels
{
    public class Clinic
    {
        public int ClinicId { get; set; }
        [Required(ErrorMessage = "Please enter the AddressStreet.")]
        public string AddressStreet { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter the AddressTown.")]
        public string AddressTown { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter the AddressState.")]
        public string AddressState { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter the AddressPostCode.")]
        public string AddressPostCode { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter the PhoneNumber.")]
        public string PhoneNumber { get; set; } = string.Empty;
        public int OpenHoursId { get; set; }
        [ValidateNever]
        public OpenHours OpenHours { get; set; } = null!;
    }
}
