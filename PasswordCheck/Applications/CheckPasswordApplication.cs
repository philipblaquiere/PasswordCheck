using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaveIBeenPND;
using HaveIBeenPND.Entities;
using PasswordCheck.Contracts;
using PasswordCheck.Data;

namespace PasswordCheck.Applications
{
	public class CheckPasswordApplication : IApplication
	{
		public CheckPasswordApplication(
			string password,
			RuleSet ruleSet,
			RankingSet rankingSet,
			bool isDetailedOutput,
			bool isCheckHaveIBeenPwned)
		{
			Password = password;
			RuleSet = ruleSet;
			RankingSet = rankingSet;
			IsDetailedOutput = isDetailedOutput;
			IsCheckHaveIBeenPwned = isCheckHaveIBeenPwned;
		}

		public string Password { get; }

		public RuleSet RuleSet { get; }

		public RankingSet RankingSet { get; }

		public bool IsDetailedOutput { get; }

		public bool IsCheckHaveIBeenPwned { get; }

		public async Task Run()
		{
			StringBuilder sb = new StringBuilder();

			if (RuleSet == null || RankingSet == null)
			{
				sb.Append($"Missing {nameof(RuleSet)} or {nameof(RankingSet)}");
				Console.WriteLine(sb);
				return;
			}

			// Test Password
			RuleSetTestResult ruleSetTestResults = RuleSet.Test(Password);

			ScoreNormalizer scoreInterpreter = new ScoreNormalizer();

			// Normalize Score
			int normalizedScore = scoreInterpreter.Normalize(
				ruleSetTestResults.IsSuccess ? ruleSetTestResults : null,
				RuleSet,
				RankingSet);

			// Interpret
			KeyValuePair<int, string> interpretedRanking = RankingSet.GetClosestRanking(normalizedScore);

			sb.AppendLine("PASSWORD CHECK: " + (ruleSetTestResults.IsSuccess ? "PASSED" : "FAILED"));
			sb.AppendLine($"STRENGTH: {interpretedRanking.Value} ({ruleSetTestResults.Score})");

			if (IsDetailedOutput)
			{
				sb.AppendLine($"RULE SET [{RuleSet.Name}]");

				if (ruleSetTestResults.RulesPassed?.Any() ?? false)
				{
					sb.AppendLine($"PASSED:");
					sb.AppendJoin("\n", ruleSetTestResults.RulesPassed?.Select(rule => rule.Message));
					sb.AppendLine();
				}

				if (!ruleSetTestResults.IsSuccess)
				{
					sb.AppendLine("FAILED:");
					sb.AppendJoin("\n", ruleSetTestResults.RulesFailed?.Select(rule => rule.Message));
					sb.AppendLine();
				}

				if (ruleSetTestResults.RulesRecommendations?.Any() ?? false)
				{
					sb.AppendLine("RECOMMENDATIONS:");
					sb.AppendJoin("\n", ruleSetTestResults.RulesRecommendations.Select(rule => rule.Message));
					sb.AppendLine();
				}
			}

			if (IsCheckHaveIBeenPwned)
			{
				// Check if pass has been pwned on the external website
				HaveIBeenPNDService pndService = new HaveIBeenPNDService();

				PNDPassword pndPassword = await pndService.HaveIBeenPND(Password);

				if (pndPassword != null)
				{
					sb.AppendLine($"Your password is PWNED ({pndPassword.PNDCount} times), consider changing it!");
				}
				else
				{
					sb.AppendLine($"Your password hasn't been PWNED...yet.");
				}
			}

			// Empty string builder to console
			Console.Write(sb);
		}
	}
}
