using System.Numerics;

namespace ToolsSharp
{
	/// <summary>
	/// Helper methods for <seealso cref="IDictionary{TKey, TValue}"/> instances
	/// </summary>
	public static class DictionaryHelper
	{
		/// <summary>
		/// A simple method to add a new value or increment an existing value in a given generic dictionary.
		/// Can only be used with dictionaries where <typeparamref name="U"/> is additive.
		/// </summary>
		/// <typeparam name="T">The type of the Key</typeparam>
		/// <typeparam name="U">The type of the Value</typeparam>
		/// <param name="dict">The given dictionary</param>
		/// <param name="key">The key to check for</param>
		/// <param name="by">By how much the value should be incremented by</param>
		public static void AddOrIncrement<T, U>(IDictionary<T, U> dict, T key, U by)
			where T : notnull
			where U : IAdditionOperators<U, U, U>
		{
			if (dict.ContainsKey(key))
				dict[key] += by;
			else
				dict.Add(key, by);
		}
	}
}