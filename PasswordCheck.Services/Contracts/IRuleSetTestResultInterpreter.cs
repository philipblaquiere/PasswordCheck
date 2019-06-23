using PasswordCheck.Data;

namespace PasswordCheck.Contracts
{
	public interface IRuleSetTestResultInterpreter : IScoreNormalizer
	{
		/// <summary>
		/// Provides an Natural Language interpretation of the passwords Score
		/// </summary>
		/// <param name="passwordTestResult"></param>
		/// <param name="ruleSet"></param>
		/// <returns></returns>
		string Interpret(RuleSetTestResult passwordTestResult, RuleSet ruleSet);
	}
}
