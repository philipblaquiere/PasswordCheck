using System.Linq;
using System.Threading.Tasks;
using PasswordCheck.Data;
using PasswordCheck.Services.Contracts;

namespace PasswordCheck.Services
{
	public class RuleSetService : IRuleSetService
	{
		public Task<RuleSet> GetRuleSet(string ruleSetName)
		{
			return Task.Run(() => RuleSetProvider.GetRuleSet(ruleSetName));
		}

		public Task<string[]> GetRuleSets()
		{
			return Task.Run(() => RuleSetProvider
				.RuleSets
				.Select(ruleSet => $"{ruleSet.Name}")
				.ToArray());
		}
	}
}
