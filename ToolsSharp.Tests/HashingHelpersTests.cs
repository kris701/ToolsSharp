using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToolsSharp.Tests
{
	[TestClass]
	public class HashingHelpersTests
	{
		[TestMethod]
		[DataRow("abba")]
		[DataRow("asfagdaad")]
		[DataRow("0+5490udgfiohj2590uge")]
		[DataRow("super_secret_password")]
		public void Can_Hash(string value)
		{
			// ARRANGE

			// ACT
			var actual = HashingHelpers.HashString(value, System.Security.Cryptography.HashAlgorithmName.SHA1);

			// ASSERT
			Assert.IsTrue(HashingHelpers.VerifyHash(actual, value, System.Security.Cryptography.HashAlgorithmName.SHA1));
		}
	}
}
