using System.Collections.Generic;
using System.Linq;

namespace PasswordCheck.Data
{
    public static class RankingSetExtensions
    {
        public static int GetMaxScore(this RankingSet rankingSet)
        {
            return rankingSet
                .Rankings?
                .Select(ranking => ranking.Key)
                .Max() ?? 0;
        }

        /// <summary>
        /// Gets the closest score in the ranking, such that a non-existant score
        /// in rankings will return a score in nearest-low basis
        /// </summary>
        /// <param name="normalizedScore"></param>
        /// <param name="rankingSet"></param>
        /// <returns></returns>
        public static KeyValuePair<int, string> GetClosestRanking(
            this RankingSet rankingSet,
            int normalizedScore)
        {
            var equivalentScore = 0;

            if(rankingSet.Rankings == null)
            {
                return new KeyValuePair<int, string>();
            }

            foreach (var ranking in rankingSet.Rankings.OrderBy(ranking => ranking.Key))
            {
                if (normalizedScore >= ranking.Key)
                {
                    equivalentScore = ranking.Key;
                }
            }

            return rankingSet.Rankings.FirstOrDefault(ranking => ranking.Key == equivalentScore);
        }
    }
}
