using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordCheck.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PasswordCheck.Tests
{
	[TestClass]
	public class RuleSetTests
	{

		[TestMethod]
		public void TestPassword_EmptyPassword_ScoreZero()
		{
			// Arrange
			RuleSet defaultRuleSet = RuleSetProvider.Default;
			string password = "";

			// Act
			RuleSetTestResult result = defaultRuleSet.Test(password);

			// Assert
			Assert.AreEqual(0, result.Score);

		}

		[TestMethod]
		public void TestPassword_EmptyPassword_IsSuccessFalse()
		{
			// Arrange
			RuleSet defaultRuleSet = RuleSetProvider.Default;
			string password = "";

			// Act
			RuleSetTestResult result = defaultRuleSet.Test(password);

			// Assert
			Assert.IsFalse(result.IsSuccess);
		}

		[TestMethod]
		public void TestPassword_FailingPassword_IsSuccessFalse()
		{
			// Arrange
			RuleSet defaultRuleSet = RuleSetProvider.Default;
			string password = "aaaaaaaaaaaaaa";

			// Act
			RuleSetTestResult result = defaultRuleSet.Test(password);

			// Assert
			Assert.IsFalse(result.IsSuccess);
		}

		[TestMethod]
		public void TestPassword_PassingPassword_IsSuccessTrue()
		{
			// Arrange
			RuleSet defaultRuleSet = RuleSetProvider.Default;
			string password = "aaaaAAAA;;;;1111";

			// Act
			RuleSetTestResult result = defaultRuleSet.Test(password);

			// Assert
			Assert.IsTrue(result.IsSuccess);
		}

		[TestMethod]
		public void TestPassword_PassingPassword_MaxScore()
		{
			// Arrange
			RuleSet defaultRuleSet = RuleSetProvider.Default;
			string password = "aaaaAAAA;;;;1111iiiii";

			// Act
			RuleSetTestResult result = defaultRuleSet.Test(password);

			// Assert
			Assert.AreEqual(defaultRuleSet.Score, result.Score);
		}

		[TestMethod]
		public void TestPassword_PassingPassword_HasRecommendations()
		{
			// Arrange
			RuleSet defaultRuleSet = RuleSetProvider.Default;
			string password = "aaaaAAAA;;;;1111iii";

			// Act
			RuleSetTestResult result = defaultRuleSet.Test(password);

			// Assert
			Assert.IsTrue(result.RulesRecommendations?.Any() ?? false);
		}


		[TestMethod]
		public void TestPassword_FailingPassword_HasRulesFailed()
		{
			// Arrange
			RuleSet defaultRuleSet = RuleSetProvider.Default;
			string password = "aaaaAAAA;;;;";

			// Act
			RuleSetTestResult result = defaultRuleSet.Test(password);

			// Assert
			Assert.IsTrue(result.RulesFailed?.Any() ?? false);
		}

		[TestMethod]
		public void TestPassword_FailingPartiallyPassword_HasRulesPassed()
		{
			// Arrange
			RuleSet defaultRuleSet = RuleSetProvider.Default;
			string password = "aaaaAAAA;;;;";

			// Act
			RuleSetTestResult result = defaultRuleSet.Test(password);

			// Assert
			Assert.IsNotNull(result.RulesPassed);
		}

		[TestMethod]
		public void TestPassword_PassingPassword_HasNoRulesFailed()
		{
			// Arrange
			RuleSet defaultRuleSet = RuleSetProvider.Default;
			string password = "aaaaAAAA;;;;98237lkasjdf";

			// Act
			RuleSetTestResult result = defaultRuleSet.Test(password);

			// Assert
			Assert.IsNull(result.RulesFailed);
		}

		[TestMethod]
		public void TestPassword_FailingPartiallyPassword_HasRecommendations()
		{
			// Arrange
			RuleSet defaultRuleSet = RuleSetProvider.Default;
			string password = "aaaaAAAA;;;;9";

			// Act
			RuleSetTestResult result = defaultRuleSet.Test(password);

			// Assert
			Assert.IsTrue(result.RulesRecommendations?.Any() ?? false);
		}

		[TestMethod]
		public void TestPassword_FailingPassword_HasZeroScore()
		{
			// Arrange
			RuleSet defaultRuleSet = RuleSetProvider.Default;
			string password = "a";

			// Act
			RuleSetTestResult result = defaultRuleSet.Test(password);

			// Assert
			Assert.AreEqual(0, result.Score);
		}

		[TestMethod]
		public void TestPassword_FailingPartiallyPassword_HasZeroScore()
		{
			// Arrange
			RuleSet defaultRuleSet = RuleSetProvider.Default;
			string password = "aaaaAAAA;;;;";

			// Act
			RuleSetTestResult result = defaultRuleSet.Test(password);

			// Assert
			Assert.IsFalse(result.IsSuccess);
			Assert.AreEqual(0 , result.Score);
		}

		[TestMethod]
		public void TestPassword_PassingPassword_HasScoreHigherThanZero()
		{
			// Arrange
			RuleSet defaultRuleSet = RuleSetProvider.Default;
			string password = "aaaaAAAA;;;;9999slkd";

			// Act
			RuleSetTestResult result = defaultRuleSet.Test(password);

			// Assert
			Assert.IsTrue(result.IsSuccess);
			Assert.IsTrue(result.Score > 0);
		}
	}
}
