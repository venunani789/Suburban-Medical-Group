using System.Text.Json.Serialization;
using SububanMedicalGroupSMGWebApp.Models.DomainModels;
using SububanMedicalGroupSMGWebApp.Models.ExtensionMethods;

namespace SububanMedicalGroupSMGWebApp.Models.Grid
{
    public class SMGGridData : GridData
    {
        // set initial sort field in constructor
        public SMGGridData() => SortField = nameof(Physician.LastName);

        // sort flags
        [JsonIgnore]
        public bool IsSortByLastName=>
            SortField.EqualsNoCase(nameof(Physician.LastName));
        [JsonIgnore]
        public bool IsSortByLocation =>
            SortField.EqualsNoCase(nameof(Physician.Clinic.AddressTown));
    }
}
