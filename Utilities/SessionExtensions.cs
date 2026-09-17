using Newtonsoft.Json;

namespace NorthwindWithPagingExample.Utilities;

// Adapted from:
// https://learn.microsoft.com/en-au/aspnet/core/fundamentals/app-state?view=aspnetcore-10.0#set-and-get-session-values

public static class SessionExtensions
{
    extension(ISession session)
    {
        public void SetObject<T>(string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public T GetObject<T>(string key)
        {
            var value = session.GetString(key);

            return value == null ? default : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
