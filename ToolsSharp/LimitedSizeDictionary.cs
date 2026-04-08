namespace ToolsSharp
{
	/// <summary>
	/// A dictionary with a fixed size.
	/// When adding more keys than its size allows, the oldest keyvalue is ejected
	/// </summary>
	/// <typeparam name="TKey"></typeparam>
	/// <typeparam name="TValue"></typeparam>
	public class LimitedSizeDictionary<TKey, TValue> where TKey : notnull
	{
		private Dictionary<TKey, TValue> _dict;
		private Queue<TKey> _queue;
		private int _size;

		/// <summary>
		/// Get a dictionary value by its key
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public TValue this[TKey key] => _dict[key];

		/// <summary>
		/// Check if a given key exists in the dictionary
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public bool ContainsKey(TKey key) => _dict.ContainsKey(key);

		/// <summary>
		/// Main constructor
		/// </summary>
		/// <param name="size"></param>
		public LimitedSizeDictionary(int size)
		{
			_size = size;
			_dict = new Dictionary<TKey, TValue>(size + 1);
			_queue = new Queue<TKey>(size);
		}

		/// <summary>
		/// Add a element to the dictionary
		/// </summary>
		/// <param name="key"></param>
		/// <param name="value"></param>
		public void Add(TKey key, TValue value)
		{
			_dict.Add(key, value);
			if (_queue.Count == _size)
				_dict.Remove(_queue.Dequeue());
			_queue.Enqueue(key);
		}

		/// <summary>
		/// Remove an element from the dictionary
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public bool Remove(TKey key)
		{
			if (_dict.Remove(key))
			{
				Queue<TKey> newQueue = new Queue<TKey>(_size);
				foreach (TKey item in _queue)
					if (!_dict.Comparer.Equals(item, key))
						newQueue.Enqueue(item);
				_queue = newQueue;
				return true;
			}
			else
				return false;
		}
	}
}
