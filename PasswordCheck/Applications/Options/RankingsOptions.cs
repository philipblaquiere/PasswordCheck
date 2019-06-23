using CommandLine;

namespace PasswordCheck.Applications.Options
{
	[Verb("ranking", HelpText = "Ranking Commands")]
	public class RankingsOptions
	{
		[Option('l', "list", Required = false, HelpText = "List available rankings")]
		public bool ListRankings { get; set; }

		[Option('d', "details", Required = false, HelpText = "Displays the list of scores specified by the ranking")]
		public string Ranking { get; set; }
	}
}
