using PasswordCheck.Data;
using System.Collections.Generic;
using System.Linq;

namespace PasswordCheck
{
    public static class RankingSetProvider
    {
        public static RankingSet GetRanking(string? rankingName = "")
        {
            if (string.IsNullOrEmpty(rankingName))
            {
                return Default;
            }

            return Rankings.FirstOrDefault(ranking => ranking.Name == rankingName) ?? Default;
        }

        public static bool ContainsRanking(string rankingName = "")
        {
            if (string.IsNullOrEmpty(rankingName))
            {
                return false;
            }

            return Rankings.Any(ranking => ranking.Name == rankingName);
        }

        public static RankingSet Default => new(
            name: nameof(Default),
            rankings: new[]
            {
                new KeyValuePair<int, string>(0, "No Ranking"),
                new KeyValuePair<int, string>(1, "Very Poor"),
                new KeyValuePair<int, string>(2, "Poor"),
                new KeyValuePair<int, string>(3, "Medium"),
                new KeyValuePair<int, string>(4, "Sufficient"),
                new KeyValuePair<int, string>(5, "Excellent"),
                new KeyValuePair<int, string>(6, "Exceptional"),
            });

        public static RankingSet CustomRankingSet1 => new(
            name: nameof(CustomRankingSet1),
            rankings: new[]
            {
                new KeyValuePair<int, string>(0, "No Ranking"),
                new KeyValuePair<int, string>(1, "Poor"),
                new KeyValuePair<int, string>(2, "Medium"),
                new KeyValuePair<int, string>(4, "Excellent"),
            });


        public static List<RankingSet> Rankings => new()
        {
            Default,
            CustomRankingSet1
        };
    }
}
