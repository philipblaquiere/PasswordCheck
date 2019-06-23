using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordCheck.Data;

namespace PasswordCheck.Tests
{
	[TestClass]
	public class RuleTests
	{
		[TestMethod]
		public void IsMatch_MeetsMatchCount_ReturnsTrue()
		{
			// Arrange
			Rule rule = Rules.AtLeast4CapitalLetters;
			string input = "JJJJ";

			// Act
			bool isMatch = rule.IsMatch(input);

			// Assert
			Assert.IsTrue(isMatch);
		}

		[TestMethod]
		public void IsMatch_MissMatchCount_ReturnsFalse()
		{
			// Arrange
			Rule rule = Rules.AtLeast4CapitalLetters;
			string input = "JJJjjj";

			// Act
			bool isMatch = rule.IsMatch(input);

			// Assert
			Assert.IsFalse(isMatch);
		}

		[TestMethod]
		public void GetScore_IsMatch_ReturnsScore()
		{
			// Arrange
			Rule rule = Rules.AtLeast4CapitalLetters;
			string input = "JJJJjjj";

			// Act
			int score = rule.GetScore(input);

			// Assert
			Assert.AreEqual(rule.Weight, score);
		}

		[TestMethod]
		public void GetScore_IsNotMatch_ReturnsZero()
		{
			// Arrange
			Rule rule = Rules.AtLeast4CapitalLetters;
			string input = "JJJjjj";

			// Act
			int score = rule.GetScore(input);

			// Assert
			Assert.AreEqual(0, score);
		}
	}
}
