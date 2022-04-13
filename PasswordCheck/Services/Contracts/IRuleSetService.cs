using PasswordCheck.Data;
using System.Threading.Tasks;

namespace PasswordCheck.Services.Contracts
{
	public interface IRuleSetService
	{
		/// <summary>
		/// Lists rule sets sets by name
		/// </summary>
		/// <returns></returns>
		Task<string[]> GetRuleSets();

		/// <summary>
		/// Gets the details of a rule set by name
		/// </summary>
		/// <param name="ruleSetName"></param>
		/// <returns></returns>
		Task<RuleSet> GetRuleSet(string? ruleSetName);
	}
}
