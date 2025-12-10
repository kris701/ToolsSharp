using System.Reflection;

namespace ToolsSharp
{
	/// <summary>
	/// Helper methods to get embedded resources
	/// </summary>
	public static class ResourceHelpers
	{
		/// <summary>
		/// Gets the text content of an embedded file
		/// </summary>
		/// <param name="target"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static string GetAsText(string target)
		{
			using (Stream stream = GetAsStream(target))
			using (StreamReader reader = new StreamReader(stream))
				return reader.ReadToEnd();
		}

		/// <summary>
		/// Gets the content of an embedded file as a <seealso cref="Stream"/>
		/// </summary>
		/// <param name="target"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static Stream GetAsStream(string target)
		{
			var assembly = Assembly.GetExecutingAssembly();
			var fileStream = assembly.GetManifestResourceStream(target);
			if (fileStream == null)
				throw new ArgumentNullException($"Cannot read resource: {target}");
			return fileStream;
		}

		/// <summary>
		/// Checks if a given embedded resource exists
		/// </summary>
		/// <param name="target"></param>
		/// <returns></returns>
		public static bool Exists(string target)
		{
			var assembly = Assembly.GetExecutingAssembly();
			var fileStream = assembly.GetManifestResourceStream(target);
			if (fileStream == null)
				return false;
			return true;
		}
	}
}