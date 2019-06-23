using HaveIBeenPND;
using HaveIBeenPND.Contracts;
using HaveIBeenPND.Entities;
using PasswordCheck.Data;
using PasswordCheck.Services.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PasswordCheck.Services
{
	public class CheckPasswordService : ICheckPasswordService
	{
		public async Task<CheckPasswordResult> Check(
			string password,
			string ruleSetName,
			string rankingSetName,
			bool isCheckHaveIBeenPwned)
		{
			RuleSet ruleSet = RuleSetProvider.GetRuleSet(ruleSetName); 

			// Test Password
			RuleSetTestResult ruleSetTestResults = ruleSet.Test(password);

			ScoreNormalizer scoreInterpreter = new ScoreNormalizer();

			RankingSet rankingSet = RankingSetProvider.GetRanking(rankingSetName);

			// Normalize Score
			int normalizedScore = scoreInterpreter.Normalize(
				ruleSetTestResults.IsSuccess ? ruleSetTestResults : null,
				ruleSet,
				rankingSet);

			// Interpret
			KeyValuePair<int, string>? interpretedRanking = rankingSet.GetClosestRanking(normalizedScore);

			PNDPassword pndPassword = null;

			if (isCheckHaveIBeenPwned)
			{
				// Check if pass has been pwned on the external website
				IHaveIBeenPNDService pndService = new HaveIBeenPNDService();

				pndPassword = await pndService.HaveIBeenPND(password);
			}

			return new CheckPasswordResult(
				score: interpretedRanking?.Key,
				ranking: interpretedRanking?.Value,
				rankingSetName: rankingSet?.Name,
				ruleSet: ruleSet,
				isSuccess: ruleSetTestResults.IsSuccess,
				pndPassword: pndPassword,
				rulesPassed: ruleSetTestResults.RulesPassed,
				rulesFailed: ruleSetTestResults.RulesFailed,
				rulesRecommendations: ruleSetTestResults.RulesRecommendations);
		}
	}
}
