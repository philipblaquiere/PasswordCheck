using System.Threading.Tasks;
using HaveIBeenPND.Contracts;
using HaveIBeenPND.Entities;
using HaveIBeenPND.Tests.Stubs;

namespace HaveIBeenPND.Tests.Mocks
{
	public class MockHaveIBeenPNDClient : IHaveIBeenPNDClient
	{
		public Task<HaveIBeenPwndRangeResponse> Range(string prefix)
		{
			return Task.Run(() => HaveIBeenPwndRangeResponseStubs.SampleResponse);
		}
	}
}
