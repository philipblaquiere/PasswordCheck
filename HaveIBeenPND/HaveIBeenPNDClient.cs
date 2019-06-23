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

		public async Task<HaveIBeenPwndRangeResponse> Range(string prefix)
		{
			string response = await RangeEndpoint
				.AppendPathSegment(prefix)
				.GetStringAsync();

			return new HaveIBeenPwndRangeResponse(response);
		}
	}
}
