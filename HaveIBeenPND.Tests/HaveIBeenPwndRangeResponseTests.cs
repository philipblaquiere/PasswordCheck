using System.Collections.Generic;
using System.Linq;
using HaveIBeenPND.Entities;
using HaveIBeenPND.Entities.Extensions;
using HaveIBeenPND.Tests.Stubs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HaveIBeenPND.Tests
{
	[TestClass]
	public class HaveIBeenPwndRangeResponseTests
	{
		[TestMethod]
		public void GetPNDPasswords_EmptyResponse_ReturnsEmptyArray()
		{
			// Arrange
			HaveIBeenPwndRangeResponse response = HaveIBeenPwndRangeResponseStubs.EmptyResponse;
			string prefix = "36DEB";

			// Act
			IEnumerable<PNDPassword> passwords = response.GetPNDPasswords(prefix);

			// Assert
			Assert.IsFalse(passwords.Any());
		}

		[TestMethod]
		public void GetPNDPasswords_ContainsResponse_ReturnsPNDPasswords()
		{
			// Arrange
			HaveIBeenPwndRangeResponse response = HaveIBeenPwndRangeResponseStubs.SampleResponse;
			string prefix = "36DEB";

			// Act
			IEnumerable<PNDPassword> passwords = response.GetPNDPasswords(prefix);

			// Assert
			Assert.IsTrue(passwords.Any());
		}

		[TestMethod]
		public void GetPNDPasswords_ContainsResponse_ContainCount()
		{
			// Arrange
			HaveIBeenPwndRangeResponse response = HaveIBeenPwndRangeResponseStubs.SampleResponse;
			string prefix = "36DEB";

			// Act
			IEnumerable<PNDPassword> passwords = response.GetPNDPasswords(prefix);

			// Assert
			Assert.IsTrue(passwords.All(password => password.PNDCount != null));
		}

		[TestMethod]
		public void GetPNDPasswords_ContainsResponse_ContainPassword()
		{
			// Arrange
			HaveIBeenPwndRangeResponse response = HaveIBeenPwndRangeResponseStubs.SampleResponse;
			string prefix = "36DEB";

			// Act
			IEnumerable<PNDPassword> passwords = response.GetPNDPasswords(prefix);

			// Assert
			Assert.IsTrue(passwords.All(password => !string.IsNullOrEmpty(password.SHA1Password)));
		}
	}
}
