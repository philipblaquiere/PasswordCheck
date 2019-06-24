using System.Threading.Tasks;
using HaveIBeenPND.Entities;

namespace HaveIBeenPND.Contracts
{
    public interface IHaveIBeenPNDService
    {
        /// <summary>
        /// Checks if range of password has been pnwd
        /// </summary>
        /// <param name="password">Password to be verified</param>
        /// <returns>A list of PNDPasswords that have been pwnd</returns>
        Task<PNDPassword> HaveIBeenPND(string password);
    }
}
