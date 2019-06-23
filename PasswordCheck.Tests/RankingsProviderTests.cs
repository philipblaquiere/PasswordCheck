using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordCheck.Data;

namespace PasswordCheck.Tests
{
	[TestClass]
	public class RankingsProviderTests
	{
		[TestMethod]
		public void Contains_EmptyString_ReturnsFalse()
		{
			// Arrange
			var rankingName = "";
			// Act
			var containsRanking = RankingSetProvider.ContainsRanking(rankingName);
			// Assert
			Assert.IsFalse(containsRanking);
		}

		[TestMethod]
		public void Contains_UnknownRanking_ReturnsFalse()
		{
			// Arrange
			var rankingName = "this_ranking_is_unkown";
			// Act
			var containsRanking = RankingSetProvider.ContainsRanking(rankingName);
			// Assert
			Assert.IsFalse(containsRanking);
		}

		[TestMethod]
		public void Contains_KnownRanking_ReturnsTrue()
		{
			// Arrange
			var rankingName = "Default";
			// Act
			var containsRanking = RankingSetProvider.ContainsRanking(rankingName);
			// Assert
			Assert.IsTrue(containsRanking);
		}

		[TestMethod]
		public void Get_KnownRanking_ReturnsRanking()
		{
			// Arrange
			var rankingName = "Default";
			// Act
			var ranking = RankingSetProvider.GetRanking(rankingName);
			// Assert
			Assert.AreEqual(rankingName, ranking.Name);
		}

		[TestMethod]
		public void Get_UnknownRanking_ReturnsDefault()
		{
			// Arrange
			var unknownRankingName = "this_ranking_is_unkown";
			var defaultRankingName = "Default";
			// Act
			var ranking = RankingSetProvider.GetRanking(unknownRankingName);
			// Assert
			Assert.AreEqual(defaultRankingName, ranking.Name);
		}

		[TestMethod]
		public void Get_EmptyString_ReturnsDefault()
		{
			// Arrange
			var defaultRankingName = "Default";
			// Act
			var ranking = RankingSetProvider.GetRanking("");
			// Assert
			Assert.AreEqual(defaultRankingName, ranking.Name);
		}
	}
}
