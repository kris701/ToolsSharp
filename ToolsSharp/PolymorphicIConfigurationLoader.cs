using Microsoft.Extensions.Configuration;

namespace ToolsSharp
{
	/// <summary>
	/// Helper to get a IConfiguration section as a polymorhpic deserialization
	/// </summary>
	public static class PolymorphicIConfigurationLoader
	{
		/// <summary>
		/// Deserialize a list of polymophic items
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="config"></param>
		/// <param name="typeMap"></param>
		/// <param name="discriminator"></param>
		/// <returns></returns>
		public static List<T> GetListAsPolymorphic<T>(this IConfiguration config, Dictionary<string, Func<T>> typeMap, string discriminator = "$type")
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

		/// <summary>
		/// Deserialize a polymorphic item
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="config"></param>
		/// <param name="typeMap"></param>
		/// <param name="discriminator"></param>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
		public static T GetAsPolymorphic<T>(this IConfiguration config, Dictionary<string, Func<T>> typeMap, string discriminator = "$type")
		{
			// null value = the item doesn't exist in the array => exit loop
			var typeName = config.GetValue<string>($"{discriminator}");
			if (typeName == null)
				throw new Exception("Invalid type to be deserialized!");

			if (!typeMap.ContainsKey(typeName))
				throw new Exception("Invalid type to be deserialized!");
			T conf = typeMap[typeName]();

			// bind the config to the instance
			config.Bind(conf);

			return conf;
		}
	}
}
