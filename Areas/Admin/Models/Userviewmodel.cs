using Microsoft.AspNetCore.Identity;
using SububanMedicalGroupSMGWebApp.Models.DomainModels;

namespace SububanMedicalGroupSMGWebApp.Areas.Admin.Models
{
    public class Userviewmodel
    {
        public IEnumerable<User> Users { get; set; } = null!;
        public IEnumerable<IdentityRole> Roles { get; set; } = null!;
    }
}
