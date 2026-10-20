using Microsoft.Extensions.Configuration;

namespace ToolsSharp
{
	/// <summary>
	/// Helper to get a IConfiguration section as a polymorhpic deserialization
	/// </summary>
	public static class PolymorphicIConfigurationLoader
	{
		/// <summary>
		/// Overload method
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="config"></param>
		/// <param name="typeMap"></param>
		/// <param name="discriminator"></param>
		/// <returns></returns>
		public static List<T> GetAsPolymorphic<T>(this IConfiguration config, Dictionary<string, Func<T>> typeMap, string discriminator = "$type")
		{
			var result = new List<T>();

			for (var i = 0; ; i++)
			{
				// read the section of the nth item of the array
				var root = $"{i}";

				// null value = the item doesn't exist in the array => exit loop
				var typeName = config.GetValue<string>($"{root}:{discriminator}");
				if (typeName == null)
					break;

				if (!typeMap.ContainsKey(typeName))
					continue;
				T conf = typeMap[typeName]();

				// bind the config to the instance
				config.GetSection($"{root}").Bind(conf);
				result.Add(conf);
			}

			return result;
		}
	}
}
