using PasswordCheck.Data;
using System.Collections.Generic;

namespace PasswordCheck.Tests.Stubs
{
	public static class StubRankingsSets
	{
		public static RankingSet ZeroToThree => new RankingSet(
			name: nameof(ZeroToThree),
			rankings: new[]
			{
				new KeyValuePair<int, string>(0, "No Ranking"),
				new KeyValuePair<int, string>(1, "Very Poor"),
				new KeyValuePair<int, string>(2, "Poor"),
				new KeyValuePair<int, string>(3, "Medium")
			});

		public static RankingSet ZeroToFive => new RankingSet(
			name: nameof(ZeroToFive),
			rankings: new[]
			{
				new KeyValuePair<int, string>(0, "No Ranking"),
				new KeyValuePair<int, string>(1, "Very Poor"),
				new KeyValuePair<int, string>(2, "Poor"),
				new KeyValuePair<int, string>(3, "Medium"),
				new KeyValuePair<int, string>(4, "Sufficient"),
				new KeyValuePair<int, string>(5, "Excellent")
			});

		public static RankingSet OddsToSeven => new RankingSet(
			name: nameof(ZeroToFive),
			rankings: new[]
			{
				new KeyValuePair<int, string>(0, "No Ranking"),
				new KeyValuePair<int, string>(1, "Very Poor"),
				new KeyValuePair<int, string>(3, "Medium"),
				new KeyValuePair<int, string>(5, "Excellent"),
				new KeyValuePair<int, string>(7, "Insane")
			});

	}
}
