using PasswordCheck.Data;
using System.Threading.Tasks;

namespace PasswordCheck.Services.Contracts
{
	public interface IRankingSetService
	{
		/// <summary>
		/// Lists ranking sets by name
		/// </summary>
		/// <returns></returns>
		Task<string[]> GetRankingSets();

		/// <summary>
		/// Gets the details of a ranking set by name
		/// </summary>
		/// <param name="rankingName"></param>
		/// <returns></returns>
		Task<RankingSet> GetRankingSet(string rankingName);
	}
}
