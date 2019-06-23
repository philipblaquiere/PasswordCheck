using System.Linq;
using PasswordCheck.Contracts;

namespace PasswordCheck.Data
{
	public class RuleSetTestResult : IScore
	{
		private int? score = null;

		public RuleSetTestResult(
			string password,
			Rule[] rulesPassed, 
			Rule[] rulesFailed)
		{
			Password = password;
			RulesPassed = rulesPassed;
			RulesFailed = rulesFailed?.Where(rule => !rule.IsOptional).ToArray();
			RulesRecommendations = rulesFailed?.Where(rule => rule.IsOptional).ToArray();
		}

		public int Score
		{
			get
			{
				if(score == null)
				{
					score = IsSuccess ? RulesPassed?
						.Select(rule => rule.GetScore(Password))
						.Sum() ?? 0 : 0;
				}

				return score.Value;
			}
		}

		public bool IsSuccess => !RulesFailed?.Any() ?? true;

		public string Password { get; }

		public Rule[] RulesPassed { get; }

		public Rule[] RulesFailed { get; }

		public Rule[] RulesRecommendations { get; }
	}
}
