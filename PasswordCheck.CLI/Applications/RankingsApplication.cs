using PasswordCheck.Contracts;
using PasswordCheck.Data;
using PasswordCheck.Services;
using PasswordCheck.Services.Contracts;
using System.Text;

namespace PasswordCheck.Applications
{
    public class RankingsApplication : IApplication
    {
        public RankingsApplication(
            bool listRankings,
            string? rankingDetails)
        {
            if (rankingDetails == null)
            {
                throw new InvalidOperationException("Must specify ranking details");
            }

            ListRankings = listRankings;
            RankingNameDetails = rankingDetails;
        }

        public bool ListRankings { get; }
        public string RankingNameDetails { get; }

        public async Task Run()
        {
            StringBuilder sb = new();
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

                if (rankingSet.Rankings == null)
                {
                    return;
                }

                if (rankingSet.Rankings.Length > 0)
                {
                    IEnumerable<string>? values = rankingSet
                        .Rankings?
                        .Select(ranking => $"{ranking.Key} => {ranking.Value}");

                    if (values != null)
                    {
                        sb.AppendJoin("\n", values);
                    }
                }

                sb.AppendLine();
            }

            // Empty string builder to console
            Console.Write(sb);
        }
    }
}
