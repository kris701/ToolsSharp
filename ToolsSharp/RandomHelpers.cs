namespace ToolsSharp
{
    /// <summary>
    /// Helper methods for creating random values
    /// </summary>
    public static class RandomHelpers
    {
        private static readonly Random random = new Random();

        /// <summary>
        /// Create a random string, consisting of letters and numbers
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}