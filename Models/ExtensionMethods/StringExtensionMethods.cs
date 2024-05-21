using System.Text;

namespace SububanMedicalGroupSMGWebApp.Models.ExtensionMethods
{
    // a series of extension methods that make it easier to create slugs, compare strings, capitalize strings, 
    // and cast a string to an int. Note that the EqualsNoCase() method doesn't work in EF Core code such as
    // 'Where(b => b.GenreId.EqualsNoCase("novel"))' In that case, must use old fashioned equality operator.

    public static class StringExtensions
    {
        public static bool EqualsNoCase(this string str, string tocompare) =>
            str?.ToLower() == tocompare?.ToLower();

    }
}