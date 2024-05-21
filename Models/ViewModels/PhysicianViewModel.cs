using SububanMedicalGroupSMGWebApp.Models.DomainModels;

namespace SububanMedicalGroupSMGWebApp.Models.ViewModels
{
    public class PhysicianViewModel
    {
        public string ActiveSpeciality { get; set; } = "all";
        public string ActiveClinic { get; set; } = "all";
        public List<Physician> Physicians { get; set; } = new List<Physician>();
        public List<Clinic> Clinics { get; set; } = new List<Clinic>();
        public List<Speciality> SpecialityTypes { get; set; } = new List<Speciality>();
        public string CheckActiveSpeciality(string c) =>
            c.ToLower() == ActiveSpeciality.ToLower() ? "active" : "";

        public string CheckActiveClinic(string d) =>
            d.ToLower() == ActiveClinic.ToLower() ? "active" : "";
    }
}
