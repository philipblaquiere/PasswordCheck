using System.Threading.Tasks;
using HaveIBeenPND.Entities;

namespace HaveIBeenPND.Contracts
{
	public interface IHaveIBeenPNDService
	{
		/// <summary>
		/// Checks if range of password prefix has been pnwd
		/// </summary>
		/// <param name="prefix">First 5 characters of SHA-1 Password</param>
		/// <returns>A list of Password that have been pwnd</returns>
		Task<PNDPassword> HaveIBeenPND(string prefix);
	}
}
