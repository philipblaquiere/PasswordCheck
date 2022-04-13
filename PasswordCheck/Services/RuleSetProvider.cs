using System.Collections.Generic;
using System.Linq;
using PasswordCheck.Data;

namespace PasswordCheck
{
	/// <summary>
	/// Acts as a data provider for the sake of the program.
	/// </summary>
	public static class RuleSetProvider
	{
		public static bool ContainsRuleSet(string ruleSetName)
		{
			if(string.IsNullOrEmpty(ruleSetName))
			{
				return false;
			}

			return RuleSets.Any(ruleSet => ruleSet.Name == ruleSetName);
		}

		public static RuleSet Default => new(
			nameof(Default),
			new[]
			{
				Rules.LengthMaximumSixtyFour,
				Rules.AtLeastOneCapitalLetter,
				Rules.AtLeastOneDigit,
				Rules.AtLeastOneSpecialCharacter,
				Rules.LengthMinimumSix,
				Rules.LengthMinimumEleven,
				Rules.LengthMinimumSixteen,
				Rules.LengthMinimumTwentyOne,
				Rules.AtLeast4SpecialCharacters,
				Rules.AtLeast4Digits,
				Rules.AtLeast4CapitalLetters
			});

		public static RuleSet CustomRuleSet1 => new(
			nameof(CustomRuleSet1),
			new[]
			{
				Rules.LengthMaximumSixtyFour,
				Rules.AtLeastOneCapitalLetter,
				Rules.LengthMinimumSix,
				Rules.LengthMinimumEleven,
				Rules.AtLeast4Digits,
				Rules.AtLeast4CapitalLetters
			});

		public static RuleSet GetRuleSet(string? ruleSetName = null)
		{
			if (string.IsNullOrEmpty(ruleSetName?.Trim() ?? string.Empty))
			{
				return Default;
			}

			return RuleSets
				.FirstOrDefault(ruleSet => ruleSet.Name.ToLowerInvariant() == ruleSetName?.Trim().ToLowerInvariant()) ?? Default;
		}

		public static HashSet<RuleSet> RuleSets => new()
        {
			Default,
			CustomRuleSet1
		};
	}
}
