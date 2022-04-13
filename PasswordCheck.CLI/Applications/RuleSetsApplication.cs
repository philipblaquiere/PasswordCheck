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
	public class RuleSetsApplication : IApplication
	{
		public RuleSetsApplication(
			bool listRuleSets,
			string? ruleSetDetails)
		{
			ListRuleSets = listRuleSets;
			RuleSetDetails = ruleSetDetails;
		}

		public bool ListRuleSets { get; }
		public string? RuleSetDetails { get; }

		public async Task Run()
		{
			StringBuilder sb = new();
			IRuleSetService ruleSetService = new RuleSetService();

			if (ListRuleSets || string.IsNullOrEmpty(RuleSetDetails))
			{
				// List all rule sets, quite simply
				string[] ruleSetNames = await ruleSetService.GetRuleSets();
				sb.AppendJoin("\n", ruleSetNames);
				sb.AppendLine();
			}

			if (!string.IsNullOrEmpty(RuleSetDetails))
			{
				RuleSet ruleSet = await ruleSetService.GetRuleSet(RuleSetDetails);

				sb.AppendJoin("\n", ruleSet.Rules.Select(rule => rule.Name));
				sb.AppendLine();
			}

			// Empty string builder to console
			Console.Write(sb);
		}
	}
}
