using SububanMedicalGroupSMGWebApp.Models.ExtensionMethods;

namespace SububanMedicalGroupSMGWebApp.Models.Grid
{
    // abstract base class for working with paging and sorting routes.
    public abstract class GridData
    {
        // model binding properties
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 4;
        public string SortDirection { get; set; } = "asc";
        public string SortField { get; set; } = string.Empty;

        // general purpose methods for paging and sorting
        public int GetTotalPages(int count) => (count + PageSize - 1) / PageSize;

        // make copy of self
        public virtual GridData Clone() => (GridData)MemberwiseClone();

        // return dictionary of route segments for URL building
        public virtual Dictionary<string, string> ToDictionary() =>
            new Dictionary<string, string> {
                { nameof(PageNumber), PageNumber.ToString() },
                { nameof(PageSize), PageSize.ToString() },
                { nameof(SortField), SortField },
                { nameof(SortDirection), SortDirection },
            };
    }
}
