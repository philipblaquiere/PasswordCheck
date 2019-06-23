using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordCheck.Contracts;
using PasswordCheck.Data;
using PasswordCheck.Tests.Data;
using PasswordCheck.Tests.Stubs;
using System;

namespace PasswordCheck.Tests
{
	[TestClass]
	public class ScoreNormalizerTests
	{
		[TestMethod]
		public void Normalize_NullScore_ReturnsZero()
		{
			// Arrange
			ScoreNormalizer scoreNormalizer = new ScoreNormalizer();
			IScore maxScore = new MockScore(5);
			RankingSet rankingSet = new RankingSet("", null);

			// Act
			int normalizedScore = scoreNormalizer.Normalize(null, maxScore, rankingSet);
			// Assert
			Assert.AreEqual(0, normalizedScore);
		}

		[TestMethod]
		public void Normalize_ZeroScore_ReturnsZero()
		{
			// Arrange
			ScoreNormalizer scoreNormalizer = new ScoreNormalizer();
			IScore score = new MockScore(0);
			IScore maxScore = new MockScore(5);
			RankingSet rankingSet = new RankingSet("", null);

			// Act
			int normalizedScore = scoreNormalizer.Normalize(score, maxScore, rankingSet);
			// Assert
			Assert.AreEqual(0, normalizedScore);
		}

		[TestMethod]
		public void Normalize_NegativeScore_ReturnsZero()
		{
			// Arrange
			ScoreNormalizer scoreNormalizer = new ScoreNormalizer();
			IScore score = new MockScore(-1);
			IScore maxScore = new MockScore(5);
			RankingSet rankingSet = new RankingSet("", null);

			// Act
			int normalizedScore = scoreNormalizer.Normalize(score, maxScore, rankingSet);
			// Assert
			Assert.AreEqual(0, normalizedScore);
		}

		[TestMethod]
		public void Normalize_NullMaxScore_ReturnsZero()
		{
			// Arrange
			ScoreNormalizer scoreNormalizer = new ScoreNormalizer();
			IScore score = new MockScore(-1);
			RankingSet rankingSet = new RankingSet("", null);

			// Act
			int normalizedScore = scoreNormalizer.Normalize(score, null, rankingSet);
			// Assert
			Assert.AreEqual(0, normalizedScore);
		}

		[TestMethod]
		public void Normalize_NullRankingSet_ReturnsZero()
		{
			// Arrange
			ScoreNormalizer scoreNormalizer = new ScoreNormalizer();
			IScore score = new MockScore(-1);
			IScore maxScore = new MockScore(5);
			RankingSet rankingSet = null;

			// Act
			int normalizedScore = scoreNormalizer.Normalize(score, maxScore, rankingSet);
			// Assert
			Assert.AreEqual(0, normalizedScore);
		}


		[TestMethod]
		public void Normalize_RankingMax5ScoreMax5Score3_Returns3()
		{
			// Arrange
			ScoreNormalizer scoreNormalizer = new ScoreNormalizer();
			IScore score = new MockScore(3);
			IScore maxScore = new MockScore(5);
			RankingSet rankingSet = StubRankingsSets.ZeroToFive;

			// Act
			int normalizedScore = scoreNormalizer.Normalize(score, maxScore, rankingSet);
			// Assert
			Assert.AreEqual(3, normalizedScore);
		}

		[TestMethod]
		public void Normalize_RankingMax7ScoreMax5Score2_Returns3()
		{
			// Arrange
			ScoreNormalizer scoreNormalizer = new ScoreNormalizer();
			IScore score = new MockScore(2);
			IScore maxScore = new MockScore(5);
			RankingSet rankingSet = StubRankingsSets.OddsToSeven;

			// Act
			int normalizedScore = scoreNormalizer.Normalize(score, maxScore, rankingSet);

			// Assert
			Assert.AreEqual(3, normalizedScore);
		}

		[TestMethod]
		public void Normalize_RankingMax7ScoreMax3Score2_Returns5()
		{
			// Arrange
			ScoreNormalizer scoreNormalizer = new ScoreNormalizer();
			IScore score = new MockScore(2);
			IScore maxScore = new MockScore(3);
			RankingSet rankingSet = StubRankingsSets.OddsToSeven;

			// Act
			int normalizedScore = scoreNormalizer.Normalize(score, maxScore, rankingSet);

			// Assert
			Assert.AreEqual(5, normalizedScore);
		}

		[TestMethod]
		public void Normalize_RankingMax3ScoreMax10Score4_Returns2()
		{
			// Arrange
			ScoreNormalizer scoreNormalizer = new ScoreNormalizer();
			IScore score = new MockScore(4);
			IScore maxScore = new MockScore(10);
			RankingSet rankingSet = StubRankingsSets.ZeroToThree;

			// Act
			int normalizedScore = scoreNormalizer.Normalize(score, maxScore, rankingSet);

			// Assert
			Assert.AreEqual(2, normalizedScore);
		}
	}
}
