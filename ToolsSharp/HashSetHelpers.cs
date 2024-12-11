namespace ToolsSharp
{
    /// <summary>
    /// Helper methods for <seealso cref="HashSet{T}"/>s
    /// </summary>
    public static class HashSetHelpers
    {
        /// <summary>
        /// Insert all the values from <paramref name="other"/> into <paramref name="set"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="set"></param>
        /// <param name="other"></param>
        public static void AddRange<T>(this HashSet<T> set, IEnumerable<T> other)
        {
            foreach (var item in other)
                set.Add(item);
        }

		/// <summary>
		/// Remove all the values from <paramref name="other"/> into <paramref name="set"/>.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="set"></param>
		/// <param name="other"></param>
		public static void RemoveRange<T>(this HashSet<T> set, IEnumerable<T> other)
		{
			foreach (var item in other)
				set.Remove(item);
		}
	}
}