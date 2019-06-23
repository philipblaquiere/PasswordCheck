using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using HaveIBeenPND.Contracts;
using HaveIBeenPND.Entities;
using Flurl;
using Flurl.Http;

namespace HaveIBeenPND
{
	public class HaveIBeenPNDClient : IHaveIBeenPNDClient
	{
		public const string HaveIBeenPwnedBaseUrl = "https://api.pwnedpasswords.com";

		public IFlurlRequest RangeEndpoint => HaveIBeenPwnedBaseUrl
			.WithHeader("User-Agent", "PasswordChecker/1.0.0")
			.WithHeader("Connection", "Keep-Alive")
			.WithHeader("Accept", "text/plain")
			.AppendPathSegment("range");

		public async Task<IEnumerable<PNDPassword>> Range(string prefix)
		{
			var responseText = await RangeEndpoint
				.AppendPathSegment(prefix)
				.GetStringAsync();

			return responseText
				.Split("\r\n")
				.Select(prefexCountEntry => prefexCountEntry.Split(':'))
				.Select(prefixCount => new PNDPassword(prefix, prefixCount[0], int.Parse(prefixCount[1])));
		}
	}
}
