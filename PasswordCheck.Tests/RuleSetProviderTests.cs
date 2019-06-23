using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordCheck.Tests
{
	[TestClass]
	public class RuleSetProviderTests
	{
		[TestMethod]
		public void Contains_EmptyString_ReturnsFalse()
		{
			// Arrange
			var ruleSetName = "";
			// Act
			var containsRanking = RuleSetProvider.ContainsRuleSet(ruleSetName);
			// Assert
			Assert.IsFalse(containsRanking);
		}

		[TestMethod]
		public void Contains_UnknownRuleSet_ReturnsFalse()
		{
			// Arrange
			var ruleSetName = "this_ruleset_is_unkown";
			// Act
			var containsRanking = RuleSetProvider.ContainsRuleSet(ruleSetName);
			// Assert
			Assert.IsFalse(containsRanking);
		}

		[TestMethod]
		public void Contains_KnownRuleSet_ReturnsTrue()
		{
			// Arrange
			var ruleSetName = "Default";
			// Act
			var containsRanking = RuleSetProvider.ContainsRuleSet(ruleSetName);
			// Assert
			Assert.IsTrue(containsRanking);
		}

		[TestMethod]
		public void Get_KnownRuleSet_ReturnsRanking()
		{
			// Arrange
			var ruleSetName = "Default";
			// Act
			var ruleSet = RuleSetProvider.GetRuleSet(ruleSetName);
			// Assert
			Assert.AreEqual(ruleSetName, ruleSet.Name);
		}

		[TestMethod]
		public void Get_UnknownRuleSet_ReturnsDefault()
		{
			// Arrange
			var unknownRankingName = "this_ruleset_is_unkown";
			var defaultRankingName = "Default";
			// Act
			var ruleSet = RuleSetProvider.GetRuleSet(unknownRankingName);
			// Assert
			Assert.AreEqual(defaultRankingName, ruleSet.Name);
		}

		[TestMethod]
		public void Get_EmptyString_ReturnsDefault()
		{
			// Arrange
			var defaultRankingName = "Default";
			// Act
			var ruleSet = RuleSetProvider.GetRuleSet("");
			// Assert
			Assert.AreEqual(defaultRankingName, ruleSet.Name);
		}
	}
}
