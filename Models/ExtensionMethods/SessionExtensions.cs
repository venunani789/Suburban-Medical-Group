using System.Text.Json;

namespace SububanMedicalGroupSMGWebApp.Models.ExtensionMethods
{
    public static class SessionExtensions
    {
        public static void SetObject<T>(this ISession session,
            string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T? GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return string.IsNullOrEmpty(value) ? default :
                JsonSerializer.Deserialize<T>(value);
        }
    }
}
