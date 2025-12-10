using System.Security.Cryptography;

namespace ToolsSharp
{
	/// <summary>
	/// Set of helper methods to create secure hashes of strings
	/// Based on https://stackoverflow.com/a/10402129
	/// </summary>
	public static class HashingHelpers
	{
		/// <summary>
		/// Hash a given string
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string HashString(string value)
		{
			byte[] salt;
			RandomNumberGenerator.Create().GetBytes(salt = new byte[16]);
			var hash = Rfc2898DeriveBytes.Pbkdf2(value, salt, 100000, HashAlgorithmName.SHA3_512, 20);
			var hashBytes = new byte[36];
			Array.Copy(salt, 0, hashBytes, 0, 16);
			Array.Copy(hash, 0, hashBytes, 16, 20);
			var savedPasswordHash = Convert.ToBase64String(hashBytes);
			return savedPasswordHash;
		}

		/// <summary>
		/// Check if a hash created from <seealso cref="HashString(string)"/> is valid
		/// </summary>
		/// <param name="hashValue"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static bool VerifyHash(string hashValue, string value)
		{
			/* Extract the bytes */
			var hashBytes = Convert.FromBase64String(hashValue);
			/* Get the salt */
			var salt = new byte[16];
			Array.Copy(hashBytes, 0, salt, 0, 16);
			/* Compute the hash on the password the user entered */
			var hash = Rfc2898DeriveBytes.Pbkdf2(value, salt, 100000, HashAlgorithmName.SHA3_512, 20);
			/* Compare the results */
			for (var i = 0; i < 20; i++)
				if (hashBytes[i + 16] != hash[i])
					return false;
			return true;
		}
	}
}
