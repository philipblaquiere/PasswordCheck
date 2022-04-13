using HaveIBeenPND.Entities;
using PasswordCheck.Data;
using System.Collections.Generic;

namespace PasswordCheck.Services.Data
{
    public class CheckPasswordResult
    {
        public CheckPasswordResult(
            int? score,
            string? ranking,
            RankingSet rankingSet,
            RuleSet ruleSet,
            bool isSuccess,
            PNDPassword? pndPassword,
            Rule[]? rulesPassed,
            Rule[]? rulesFailed,
            Rule[]? rulesRecommendations)
        {
            Score = score;
            Ranking = ranking;
            RankingSet = rankingSet;
            RuleSet = ruleSet;
            IsSuccess = isSuccess;
            PNDPassword = pndPassword;
            RulesPassed = rulesPassed;
            RulesFailed = rulesFailed;
            RulesRecommendations = rulesRecommendations;
        }

        public int? Score { get; }

        public string? Ranking { get; }

        public RankingSet RankingSet { get; }

        public RuleSet RuleSet { get; }

        public bool IsSuccess { get; }

        public PNDPassword? PNDPassword { get; }

        public Rule[]? RulesPassed { get; }

        public Rule[]? RulesFailed { get; }

        public Rule[]? RulesRecommendations { get; }
    }
}
