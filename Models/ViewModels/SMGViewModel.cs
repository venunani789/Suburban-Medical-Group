using SububanMedicalGroupSMGWebApp.Models.DomainModels;
using SububanMedicalGroupSMGWebApp.Models.Grid;

namespace SububanMedicalGroupSMGWebApp.Models.ViewModels
{
    public class SMGViewModel
    {
        public string ActiveSpecs { get; set; } = "all";
        public string ActiveGens { get; set; } = "all";
        public string ActiveTowns { get; set; } = "all";
        public string ActiveSorter { get; set; } = "all";
        public Physician Physician { get; set; } = new Physician();
        public List<Clinic> Clinics { get; set; } = new List<Clinic>();
        public List<Speciality> Specialities { get; set; } = new List<Speciality>();
        public List<Physician> Physicians { get; set; } = new List<Physician>();
        public IEnumerable<Physician> Physic { get; set; } = new List<Physician>();
        public SMGGridData CurrentRoute { get; set; } = new SMGGridData();
        public int TotalPages { get; set; }

        public string CheckActiveSpecs(string c) =>
            c.ToLower() == ActiveSpecs.ToLower() ? "active" : "";
        public string CheckActiveTowns(string d) =>
           d.ToLower() == ActiveTowns.ToLower() ? "active" : "";
        public string CheckActiveGens(string d) =>
            d.ToLower() == ActiveGens.ToLower() ? "active" : "";

    }
}
