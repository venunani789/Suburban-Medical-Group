using SububanMedicalGroupSMGWebApp.Models.DataLayer;

namespace SububanMedicalGroupSMGWebApp.Models
{
    public static class Check
    {
        public static string SocialSecurityNumberExists(SMGWebAppContext ctx, string SocialSecurityNumber)
        {
            string msg = string.Empty;
            if (!string.IsNullOrEmpty(SocialSecurityNumber))
            {
                var user = ctx.PatientRegistrations.FirstOrDefault(
                    c => c.SocialSecurityNumber.ToLower() == SocialSecurityNumber.ToLower());
                if (user != null)
                    msg = $"SocialSecurityNumber {SocialSecurityNumber} already in use.";
            }
            return msg;
        }
        public static string EmailExists(SMGWebAppContext ctx, string email)
        {
            string msg = string.Empty;
            if (!string.IsNullOrEmpty(email)) {
                var user = ctx.PatientRegistrations.FirstOrDefault(
                    c => c.EmailAddress.ToLower() == email.ToLower());
                if (user != null) 
                    msg = $"Email address {email} already in use.";
            }
            return msg;
        }
        
    }
}