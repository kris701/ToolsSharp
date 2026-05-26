namespace ToolsSharp
{
	/// <summary>
	/// Helper methods for directories
	/// </summary>
	public static class DirectoryHelper
	{
		/// <summary>
		/// Roots a path, if it is not rooted
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public static string RootPath(string path)
		{
			if (!Path.IsPathRooted(path))
				path = Path.Join(Directory.GetCurrentDirectory(), path);
			path = path.Replace("\\", "/");
			return path;
		}

		/// <summary>
		/// Force delete an entire directory
		/// </summary>
		/// <param name="path"></param>
		public static void DeleteDirectory(string path)
		{
			var dirInfo = new DirectoryInfo(path);
			try
			{
				SetAttributesNormal(dirInfo);
				Directory.Delete(path, true);
			}
			catch (Exception e)
			{
				Console.WriteLine($"Error: {e.Message}");
			}
		}

		private static void SetAttributesNormal(DirectoryInfo dir)
		{
			foreach (var subDir in dir.GetDirectories())
				SetAttributesNormal(subDir);
			foreach (var file in dir.GetFiles())
			{
				file.Attributes = FileAttributes.Normal;
			}
			dir.Attributes = FileAttributes.Normal;
		}
	}
}