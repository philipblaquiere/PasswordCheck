using System.Threading.Tasks;
using PasswordCheck.Applications;
using PasswordCheck.Applications.Options;
using PasswordCheck.Contracts;
using CommandLine;
using PasswordCheck.Data;

namespace PasswordCheck
{
	class Program
	{
		static async Task Main(string[] args)
		{
			IApplication application = null;

			Parser.Default.ParseArguments<CheckPasswordOptions, RuleSetsOptions, RankingsOptions>(args)
				.MapResult(
				(CheckPasswordOptions options) => 
				{

					// Get rule set to be tested upon
					RuleSet ruleSet = RuleSetProvider.GetRuleSet(options.RuleSetName);

					// Get ranking to be interpreted upon
					RankingSet rankingSet = RankingsProvider.GetRanking(options.RankingName);

					application = new CheckPasswordApplication(
						options.Password,
						ruleSet,
						rankingSet,
						options.IsDetailedOutput,
						options.IsHaveIBeenPWND);

					return 0;
				},
				(RuleSetsOptions options) =>
				{
					application = new RuleSetsApplication(
						options.ListRuleSets, 
						options.RuleSet);

					return 0;
				},
				(RankingsOptions options) =>
				{
					application = new RankingsApplication(
						options.ListRankings,
						options.Ranking);

					return 0;
				}, errs => 1);

			if(application != null)
			{
				await application.Run();
			}
		}
	}
}
