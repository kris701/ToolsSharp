using System.Text.Json;

namespace ToolsSharp
{
    /// <summary>
    /// Json serialization helpers
    /// </summary>
    public static class JsonSerializerHelpers
    {
        /// <summary>
        /// Deserialize a given text as a type.
        /// If it cannot be deserialized, you can set a "default" return result instead.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="text"></param>
        /// <param name="defaultResult"></param>
        /// <returns></returns>
        public static T DeserializeOrDefault<T>(string text, Func<T> defaultResult)
        {
            try
            {
                var deserialized = JsonSerializer.Deserialize<T>(text);
                if (deserialized != null)
                    return deserialized;
            }
            catch { }
            return defaultResult();
        }
    }
}