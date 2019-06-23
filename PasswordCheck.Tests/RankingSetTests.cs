using System.Collections.Generic;
using PasswordCheck.Data;
using PasswordCheck.Tests.Stubs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PasswordCheck.Tests
{
	[TestClass]
	public class RankingSetTests
	{
		[TestMethod]
		public void MaxScore_Returns3()
		{
			// Arrange
			RankingSet rankingSet = StubRankingsSets.ZeroToThree;

			// Act
			int maxScore = rankingSet.GetMaxScore();

			// Assert
			Assert.AreEqual(3, maxScore);
		}

		[TestMethod]
		public void GetClosestRanking_RankingSetMax3Score5_Returns3()
		{
			// Arrange
			RankingSet rankingSet = StubRankingsSets.ZeroToThree;
			int normalizedScore = 5;

			// Act
			KeyValuePair<int, string> closestRanking = rankingSet.GetClosestRanking(normalizedScore);

			// Assert
			Assert.AreEqual(3, closestRanking.Key);
		}

		[TestMethod]
		public void GetClosestRanking_RankingSetMax3Score3_Returns3()
		{
			// Arrange
			RankingSet rankingSet = StubRankingsSets.ZeroToThree;

			int normalizedScore = 3;

			// Act
			KeyValuePair<int, string> closestRanking = rankingSet.GetClosestRanking(normalizedScore);

			// Assert
			Assert.AreEqual(3, closestRanking.Key);
		}
	}
}
