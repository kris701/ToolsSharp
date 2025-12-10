using System.Security.Cryptography;
using System.Text;

namespace ToolsSharp
{
	/// <summary>
	/// Helper methods for <seealso cref="Guid"/>s
	/// </summary>
	public static class GuidHelpers
	{
		/// <summary>
		/// A method to convert <seealso href="https://weblogs.asp.net/haithamkhedre/generate-guid-from-any-string-using-c">strings to guids</seealso>
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static Guid StringToGUID(string value)
		{
			// Create a new instance of the MD5CryptoServiceProvider object.
			MD5 md5Hasher = MD5.Create();
			// Convert the input string to a byte array and compute the hash.
			byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(value));
			return new Guid(data);
		}

		/// <summary>
		/// Convert a input to a <seealso cref="Guid"/>.
		/// Returns null if <paramref name="input"/> is empty
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public static Guid? GuidOrNull(string input)
		{
			if (input != "")
				return new Guid(input);

			return null;
		}
	}
}