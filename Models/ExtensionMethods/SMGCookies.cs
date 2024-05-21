using SububanMedicalGroupSMGWebApp.Models.DomainModels;

namespace SububanMedicalGroupSMGWebApp.Models.ExtensionMethods
{
    public class SMGCookies
    {
        private const string PhyKet = "myPhysicians";
        private const string Delimiter = "-";

        private IResponseCookies responseCookies { get; set; } = null!;
        private IRequestCookieCollection requestCookies { get; set; } = null!;

        public SMGCookies(IRequestCookieCollection cookies)
        {
            requestCookies = cookies;
        }
        public SMGCookies(IResponseCookies cookies)
        {
            responseCookies = cookies;
        }

        public void SetMyPhycIds(List<Physician> physicians)
        {
            List<string> ids = physicians.Select(t => t.PhysicianID.ToString()).ToList();
            string idsString = string.Join(Delimiter, ids);
            CookieOptions options = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(30)
            };
            RemoveMyPhycIds();     // delete old cookie first
            responseCookies.Append(PhyKet, idsString, options);
        }
        public void RemoveMyPhycIds()
        {
            responseCookies.Delete(PhyKet);
        }
        public string[] GetMyPhycIds()
        {
            string cookie = requestCookies[PhyKet] ?? string.Empty;
            if (string.IsNullOrEmpty(cookie))
                return Array.Empty<string>();   // empty string array
            else
                return cookie.Split(Delimiter);
        }


    }
}
