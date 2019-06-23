namespace HaveIBeenPND.Entities
{
	public class PNDPassword
	{
		public PNDPassword(
			string sha1Prefix,
			string sha1Suffix, 
			int pndCount)
		{
			SHA1Prefix = sha1Prefix;
			SHA1Suffix = sha1Suffix;
			PNDCount = pndCount;
		}

		public string SHA1Prefix { get; }

		public string SHA1Suffix { get; }

		public string SHA1Password => SHA1Prefix + SHA1Suffix;

		public int? PNDCount { get; }
	}
}
