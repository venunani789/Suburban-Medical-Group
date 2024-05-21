namespace SububanMedicalGroupSMGWebApp.Models
{
    public class Filters
    {
        public Filters(string filterstring)
        {
            FilterString = filterstring ?? "all-all-all";
            string[] filters = FilterString.Split('-');
            SpecialityId = filters[0];
            Gender = filters[1];
            ClinicId = filters[2];
        }
        public string FilterString { get; }
        public string SpecialityId { get; }
        public string Gender { get; }
        public string ClinicId { get; }

        public bool HasSpeciality => SpecialityId.ToString().ToLower() != "all";
        public bool HasGenders => Gender.ToLower() != "all";
        public bool HasClinic => ClinicId.ToString().ToLower() != "all";

        public static Dictionary<string, string> GenderFilterValues =>
            new Dictionary<string, string> {
                { "Male", "Male" },
                { "Female", "Female" }
            };
        public bool IsMale => Gender.ToLower() == "Male";
        public bool IsFemale => Gender.ToLower() == "Female";
    }
}
