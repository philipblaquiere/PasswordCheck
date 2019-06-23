using CommandLine;

namespace PasswordCheck.Applications.Options
{
	[Verb("check", HelpText = "Checks the strength of a password")]
	public class CheckPasswordOptions
	{
		[Option('p', "password", Required = true, HelpText = "The password to check")]
		public string Password { get; set; }

		[Option('r', "ruleset", Default = "Default", Required = false, HelpText = "Specify a rule set to test upon")]
		public string RuleSetName { get; set; }

		[Option('k', "ranking", Default = "Default", Required = false, HelpText = "Specify a ranking to interpret the score upon")]
		public string RankingName { get; set; }

		[Option('h', "haveibeenpwnd", Default = false, Required = false, HelpText = "Adds check whether password has been pwned")]
		public bool IsHaveIBeenPWND { get; set; }

		[Option('d', "detail", Default = false, Required = false, HelpText = "Provides a detailed output")]
		public bool IsDetailedOutput { get; set; }
	}
}
