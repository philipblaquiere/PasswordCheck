using System.Collections.Generic;
using System.Threading.Tasks;
using HaveIBeenPND.Entities;

namespace HaveIBeenPND.Contracts
{
	public interface IHaveIBeenPNDClient
	{
		/// <summary>
		/// Checks if range of password prefix has been pnwd
		/// </summary>
		/// <param name="prefix">First 5 characters of SHA-1 Password</param>
		/// <returns>A list of suffix along with their pwn count</returns>
		Task<HaveIBeenPwndRangeResponse> Range(string prefix);
	}
}
