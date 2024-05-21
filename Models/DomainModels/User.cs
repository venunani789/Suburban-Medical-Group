using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SububanMedicalGroupSMGWebApp.Models.DomainModels
{
    public class User: IdentityUser
    {
        [NotMapped]
        public IList<string> Rolename { get; set; } = null!;
    }
}
