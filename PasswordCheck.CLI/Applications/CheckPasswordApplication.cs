using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordCheck.Contracts;
using PasswordCheck.Services;
using PasswordCheck.Services.Data;

namespace PasswordCheck.Applications
{
    public class CheckPasswordApplication : IApplication
    {
        public CheckPasswordApplication(
            string? password,
            string? ruleSet,
            string? rankingSet,
            bool isDetailedOutput,
            bool isCheckHaveIBeenPwned)
        {
            Password = password;
            RuleSetName = ruleSet;
            RankingSetName = rankingSet;
            IsDetailedOutput = isDetailedOutput;
            IsCheckHaveIBeenPwned = isCheckHaveIBeenPwned;
        }

        public string? Password { get; }

        public string? RuleSetName { get; }

        public string? RankingSetName { get; }

        public bool IsDetailedOutput { get; }

        public bool IsCheckHaveIBeenPwned { get; }

        public async Task Run()
        {
            StringBuilder sb = new();

            CheckPasswordService checkPasswordService = new();

            CheckPasswordResult result = await checkPasswordService.Check(
                Password,
                RuleSetName,
                RankingSetName,
                IsCheckHaveIBeenPwned);

            sb.AppendLine("PASSWORD CHECK: " + (result.IsSuccess ? "PASSED" : "FAILED"));
            sb.AppendLine($"STRENGTH: {result.Ranking} ({result.Score})");

            if (IsDetailedOutput)
            {
                sb.AppendLine($"RULE SET [{result.RuleSet.Name}]");
                sb.AppendLine($"RANKING SET [{result.RankingSet.Name}]");

                if (result.RulesPassed?.Any() ?? false)
                {
                    sb.AppendLine($"PASSED:");
                    var values = result.RulesPassed?.Select(rule => rule.Message);

                    if(values != null)
                    {
                        sb.AppendJoin("\n", values);
                    }
                    sb.AppendLine();
                }

                if (!result.IsSuccess)
                {
                    sb.AppendLine("FAILED:");
                    var values = result.RulesFailed?.Select(rule => rule.Message);

                    if (values != null)
                    {
                        sb.AppendJoin("\n", values);
                    }
                    sb.AppendLine();
                }

                if (result.RulesRecommendations?.Any() ?? false)
                {
                    sb.AppendLine("RECOMMENDATIONS:");
                    sb.AppendJoin("\n", result.RulesRecommendations.Select(rule => rule.Message));
                    sb.AppendLine();
                }
            }

            if (IsCheckHaveIBeenPwned)
            {
                if (result.PNDPassword != null)
                {
                    sb.AppendLine($"Your password is PWNED ({result.PNDPassword.PNDCount} times), consider changing it!");
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
