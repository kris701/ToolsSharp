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
    }
}