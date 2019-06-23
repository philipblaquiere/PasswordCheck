using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordCheck.Contracts;

namespace PasswordCheck.Applications
{
	public class RuleSetsApplication : IApplication
	{
		public RuleSetsApplication(
			bool listRuleSets, 
			string ruleSetDetails)
		{
			ListRuleSets = listRuleSets;
			RuleSetDetails = ruleSetDetails;
		}

		public bool ListRuleSets { get; }
		public string RuleSetDetails { get; }

		public Task Run()
		{
			return Task.Run(() =>
			{
				var sb = new StringBuilder();

				if (ListRuleSets || string.IsNullOrEmpty(RuleSetDetails))
				{
					// List all rule sets, quite simply
					sb.AppendJoin("\n", RuleSetProvider.RuleSets.Select(ruleSet => $"{ruleSet.Name}"));
					sb.AppendLine();
				}

				if(!string.IsNullOrEmpty(RuleSetDetails) && RuleSetProvider.ContainsRuleSet(RuleSetDetails))
				{
					sb.AppendJoin("\n", RuleSetProvider.GetRuleSet(RuleSetDetails).Rules.Select(rule => rule.Name));
					sb.AppendLine();
				}

				// Empty string builder to console
				Console.Write(sb);
			});
		}
	}
}
