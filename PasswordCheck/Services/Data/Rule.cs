namespace PasswordCheck.Data
{
	public class Rule
	{
		public string? Pattern { get; set; }

		public int Weight { get; set; }

		public string? Name { get; set; }

		public int MinimumMatchCount { get; set; }

		public string Description => "Ensures password " + Message;

		public string? Message { get; set; }

		public bool IsOptional { get; set; }
	}
}