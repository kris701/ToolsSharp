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

		/// <summary>
		/// Copy all contents of a directory to another directory.
		/// https://stackoverflow.com/a/3822913
		/// </summary>
		/// <param name="sourcePath"></param>
		/// <param name="targetPath"></param>
		public static void CopyFilesRecursively(string sourcePath, string targetPath)
		{
			//Now Create all of the directories
			foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
			{
				Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
			}

			//Copy all the files & Replaces any files with the same name
			foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
			{
				File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
			}
		}
	}
}