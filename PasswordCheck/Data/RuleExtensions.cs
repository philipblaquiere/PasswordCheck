using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PasswordCheck.Data
{
	public static class RuleExtensions
	{
		public static IEnumerable<Match> Matches(this Rule rule, string input)
		{
			return Regex.Matches(
				input,
				rule.Pattern,
				RegexOptions.Singleline);
		}

		public static bool IsMatch(this Rule rule, string input)
		{
			return (rule.Matches(input)?.Count() ?? -1) >= rule.MinimumMatchCount;
		}

		public static int GetScore(this Rule rule, string input)
		{
			return rule.IsMatch(input) ? rule.Weight : 0;
		}
	}
}
