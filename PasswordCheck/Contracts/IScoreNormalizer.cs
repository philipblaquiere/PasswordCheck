using PasswordCheck.Data;

namespace PasswordCheck.Contracts
{
	public interface IScoreNormalizer
	{
		/// <summary>
		/// Normalizes a score
		/// </summary>
		/// <param name="score"></param>
		/// <param name="maxScore"></param>
		/// <param name="ranking"></param>
		/// <returns></returns>
		int Normalize(
			IScore score,
			IScore maxScore,
			RankingSet ranking = null);
	}
}
