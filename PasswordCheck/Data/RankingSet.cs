using System.Collections.Generic;

namespace PasswordCheck.Data
{
	public class RankingSet
	{
		public RankingSet(
			string name, 
			KeyValuePair<int, string>[] rankings)
		{
			Name = name;
			Rankings = rankings;
		}

		public string Name { get; }

		public KeyValuePair<int, string>[] Rankings { get; }
	}
}
