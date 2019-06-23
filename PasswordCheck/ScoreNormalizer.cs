using System;
using PasswordCheck.Contracts;
using PasswordCheck.Data;

namespace PasswordCheck
{
	public class ScoreNormalizer : IScoreNormalizer
	{
		public int Normalize(
			IScore score,
			IScore maxScore,
			RankingSet rankingSet)
		{
			// We don't want to deal with null, negative, or zero values, return early
			if(rankingSet == null || score == null || score.Score <= 0 || maxScore == null)
			{
				return 0;
			}

			// Normalize Score
			var normalizedScore = (int) Math.Ceiling((double)Math.Min(score.Score, maxScore.Score) / maxScore.Score * rankingSet.GetMaxScore());

			return normalizedScore;
		}
	}
}
