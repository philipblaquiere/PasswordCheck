using HaveIBeenPND.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HaveIBeenPND.Tests
{
	[TestClass]
	public class HashHelperTests
	{
		[TestMethod]
		public void SHA1Hash_String_ReturnsHash()
		{
			// Arrange
			string password = "Testing1234";
			string expectedHash = "36DEB936A7A7412AABF267542B5D2403DAF27602";
			
			// Act
			string hash = HashHelper.SHA1Hash(password);
			
			// Assert
			Assert.AreEqual(expectedHash, hash);
		}
	}
}
