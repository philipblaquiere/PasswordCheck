using System.Linq;

namespace PasswordCheck.Data
{
	public static class RuleSetTestExtensions
	{
		public static RuleSetTestResult Test(this RuleSet ruleSet, string password)
		{
			var ruleGroups = ruleSet
				.Rules
				.Select(rule => new { isMatch = rule.IsMatch(password), rule })
				.GroupBy(ruleGroup => ruleGroup.isMatch, ruleMatch => ruleMatch.rule);

			return new RuleSetTestResult(
				password,
				rulesPassed: ruleGroups.FirstOrDefault(ruleGroup => ruleGroup.Key)?.ToArray(),
				rulesFailed: ruleGroups.FirstOrDefault(ruleGroup => !ruleGroup.Key)?.ToArray());
		}
	}
}
