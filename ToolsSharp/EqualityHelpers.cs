namespace ToolsSharp
{
    /// <summary>
    /// Helper methods to check if the contents of two <seealso cref="IEnumerable{T}"/> instances are equal.
    /// </summary>
    public static class EqualityHelpers
    {
        /// <summary>
        /// Check if the elements in <paramref name="list1"/> is equal to the elements in <paramref name="list2"/>.
        /// Order is important.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public static bool Equals<T>(IEnumerable<T> list1, IEnumerable<T> list2)
        {
            if (list1 == null && list2 == null) return true;
            if (list1 == null && list2 != null) return false;
            if (list1 != null && list2 == null) return false;
            if (list1 != null && list2 != null)
            {
                if (list1.Count() != list2.Count()) return false;
                for (int i = 0; i < list1.Count(); i++)
                {
                    if (list1.ElementAt(i) == null && list2.ElementAt(i) == null) continue;
                    if (list1.ElementAt(i) == null && list2.ElementAt(i) != null) return false;
                    if (list1.ElementAt(i) != null && list2.ElementAt(i) == null) return false;
                    if (list1.ElementAt(i) != null && list2.ElementAt(i) != null)
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                        if (!list1.ElementAt(i).Equals(list2.ElementAt(i)))
                            return false;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                }
            }
            return true;
        }

        /// <summary>
        /// Check if the elements in <paramref name="list1"/> all exists in <paramref name="list2"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public static bool EqualsUnordered<T>(IEnumerable<T> list1, IEnumerable<T> list2)
        {
            if (list1 == null && list2 == null) return true;
            if (list1 == null && list2 != null) return false;
            if (list1 != null && list2 == null) return false;
            if (list1 != null && list2 != null)
            {
                if (list1.Count() != list2.Count()) return false;
                foreach (var item in list1)
                    if (!list2.Contains(item))
                        return false;
            }
            return true;
        }
    }
}