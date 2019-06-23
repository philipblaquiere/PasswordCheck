using System.Threading.Tasks;
using HaveIBeenPND.Contracts;
using HaveIBeenPND.Entities;
using HaveIBeenPND.Tests.Stubs;

namespace HaveIBeenPND.Tests.Mocks
{
	public class MockHaveIBeenPNDClientEmpty : IHaveIBeenPNDClient
	{
		public Task<HaveIBeenPwndRangeResponse> Range(string prefix)
		{
			return Task.Run(() => HaveIBeenPwndRangeResponseStubs.EmptyResponse);
		}
	}
}
