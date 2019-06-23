using System.Collections.Generic;
using System.Threading.Tasks;
using PasswordCheck.Contracts;
using PasswordCheck.Data;
using PasswordCheck.Services.Contracts;
using PasswordCheck.Services.Data;
using HaveIBeenPND;
using HaveIBeenPND.Contracts;
using HaveIBeenPND.Entities;

namespace PasswordCheck.Services
{
    public class CheckPasswordService : ICheckPasswordService
    {
        private readonly IRuleSetService ruleSetService;
        private readonly IRankingSetService rankingSetService;
        private readonly IScoreNormalizer scoreNormalizer;
        private readonly IHaveIBeenPNDService pndService;

        public CheckPasswordService(
            IRuleSetService ruleSetService = null,
            IRankingSetService rankingSetService = null,
            IScoreNormalizer scoreNormalizer = null,
            IHaveIBeenPNDService pndService = null)
        {
            this.ruleSetService = ruleSetService ?? new RuleSetService();
            this.rankingSetService = rankingSetService ?? new RankingSetService();
            this.scoreNormalizer = scoreNormalizer ?? new ScoreNormalizer();
            this.pndService = pndService ?? new HaveIBeenPNDService();
        }

        public async Task<CheckPasswordResult> Check(
            string password,
            string ruleSetName,
            string rankingSetName,
            bool isCheckHaveIBeenPwned)
        {
            RuleSet ruleSet = await this.ruleSetService.GetRuleSet(ruleSetName);
            RankingSet rankingSet = await this.rankingSetService.GetRankingSet(rankingSetName);

            // Test Password
            RuleSetTestResult ruleSetTestResults = ruleSet.Test(password);

            // Normalize Score
            int normalizedScore = this.scoreNormalizer.Normalize(
                ruleSetTestResults.IsSuccess ? ruleSetTestResults : null,
                ruleSet,
                rankingSet);

            // Interpret
            KeyValuePair<int, string>? interpretedRanking = rankingSet.GetClosestRanking(normalizedScore);

            PNDPassword pndPassword = null;

            if (isCheckHaveIBeenPwned)
            {
                // Check if pass has been pwned on the external website
                pndPassword = await this.pndService.HaveIBeenPND(password);
            }

            return new CheckPasswordResult(
                score: interpretedRanking?.Key,
                ranking: interpretedRanking?.Value,
                rankingSet: rankingSet,
                ruleSet: ruleSet,
                isSuccess: ruleSetTestResults.IsSuccess,
                pndPassword: pndPassword,
                rulesPassed: ruleSetTestResults.RulesPassed,
                rulesFailed: ruleSetTestResults.RulesFailed,
                rulesRecommendations: ruleSetTestResults.RulesRecommendations);
        }
    }
}
