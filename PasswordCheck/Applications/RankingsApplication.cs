using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordCheck.Contracts;
using PasswordCheck.Data;
using PasswordCheck.Services;
using PasswordCheck.Services.Contracts;

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

		public async Task Run()
		{
			StringBuilder sb = new StringBuilder();
			IRankingSetService rankingSetService = new RankingSetService();

			if (ListRankings || string.IsNullOrEmpty(RankingNameDetails))
			{
				// List all rankings
				string[] rankingSetNames = await rankingSetService.GetRankingSets();
				sb.AppendJoin("\n", rankingSetNames);

				sb.AppendLine();
			}

			if (!string.IsNullOrEmpty(RankingNameDetails))
			{
				RankingSet rankingSet = await rankingSetService.GetRankingSet(RankingNameDetails);

				sb.AppendJoin("\n", rankingSet
					.Rankings
					.Select(ranking => $"{ranking.Key} => {ranking.Value}"));

				sb.AppendLine();
			}

			// Empty string builder to console
			Console.Write(sb);
		}
	}
}
