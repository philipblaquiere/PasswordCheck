using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordCheck.Contracts;

namespace PasswordCheck.Applications
{
	public class RankingsApplication : IApplication
	{
		public RankingsApplication(
			bool listRankings,
			string rankingDetails)
		{
			ListRankings = listRankings;
			RankingNameDetails = rankingDetails;
		}

		public bool ListRankings { get; }
		public string RankingNameDetails { get; }

		public Task Run()
		{
			return Task.Run(() =>
			{
				var sb = new StringBuilder();

				if (ListRankings || string.IsNullOrEmpty(RankingNameDetails))
				{
					// List all rule sets, quite simply
					sb.AppendJoin("\n", RankingsProvider
						.Rankings
						.Select(ranking => $"{ranking.Name}"));

					sb.AppendLine();
				}

				if (!string.IsNullOrEmpty(RankingNameDetails) && RankingsProvider.ContainsRanking(RankingNameDetails))
				{
					sb.AppendJoin("\n", RankingsProvider
						.GetRanking(RankingNameDetails)
						.Rankings
						.Select(ranking => $"{ranking.Key} => {ranking.Value}"));

					sb.AppendLine();
				}

				// Empty string builder to console
				Console.Write(sb);
			});
		}
	}
}
