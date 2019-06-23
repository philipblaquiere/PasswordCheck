using System.Linq;
using System.Collections.Generic;

namespace HaveIBeenPND.Entities.Extensions
{
	public static class HaveIBeenPwndRangeResponseExtensions
	{
		public static IEnumerable<PNDPassword> GetPNDPasswords(this HaveIBeenPwndRangeResponse response, string prefix)
		{
			if(response == null || string.IsNullOrEmpty(response.Content))
			{
				return new PNDPassword[0];
			}

			return response
				.Content
				.Split("\r\n")
				.Select(prefexCountEntry => prefexCountEntry.Split(':'))
				.Select(prefixCount => new PNDPassword(prefix, prefixCount[0], int.Parse(prefixCount[1])));
		}
	}
}
