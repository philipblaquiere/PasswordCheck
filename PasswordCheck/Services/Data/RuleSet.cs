using System.Linq;
using PasswordCheck.Contracts;

namespace PasswordCheck.Data
{
	public class RuleSet : IScore
	{
		public RuleSet(
			string ruleSetName, 
			Rule[] rules)
		{
			Name = ruleSetName;
			Rules = rules;
		}

		public string Name { get; }

		public Rule[] Rules { get; }

		public int Score => Rules
			.Select(rule => rule.Weight)
			.Sum();
	}
}
