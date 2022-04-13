using System.Linq;
using System.Threading.Tasks;
using PasswordCheck.Data;
using PasswordCheck.Services.Contracts;

namespace PasswordCheck.Services
{
	public class RankingSetService : IRankingSetService
	{
		public Task<RankingSet> GetRankingSet(string? rankingSetName)
		{
			return Task.Run(() => RankingSetProvider.GetRanking(rankingSetName));
		}

		public Task<string[]> GetRankingSets()
		{
			return Task.Run(() => RankingSetProvider
				.Rankings
				.Select(ranking => $"{ranking.Name}")
				.ToArray());
		}
	}
}
