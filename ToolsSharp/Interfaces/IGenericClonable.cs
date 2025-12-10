namespace ToolsSharp.Interfaces
{
	/// <summary>
	/// A version of <seealso cref="ICloneable"/> where the output type is known at compile time
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IGenericClonable<T>
	{
		/// <summary>
		/// Clone the given object
		/// </summary>
		/// <returns>A clones instance of the current object of type <typeparamref name="T"/></returns>
		public T Clone();
	}
}
