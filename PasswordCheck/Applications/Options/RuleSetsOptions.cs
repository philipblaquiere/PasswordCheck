using CommandLine;

namespace PasswordCheck.Applications.Options
{
	[Verb("ruleset", HelpText = "Rule Sets Commands")]
	public class RuleSetsOptions
	{
		[Option('l', "list", Required = false, HelpText = "List available rulesets")]
		public bool ListRuleSets{ get; set; }

		[Option('d', "details", Required = false, HelpText = "Displays the list of rules specified in the ruleset")]
		public string RuleSet { get; set; }
	}
}
