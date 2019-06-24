using System.Threading.Tasks;
using PasswordCheck.Services.Data;

namespace PasswordCheck.Services
{
    public interface ICheckPasswordService
    {
        /// <summary>
        /// Calculates the password's strength depending on the rule set and ranking scheme
        /// Also verifies if password has been pwned
        /// </summary>
        /// <param name="password"></param>
        /// <param name="ruleSetName"></param>
        /// <param name="rankingSetName"></param>
        /// <param name="isCheckHaveIBeenPwned"></param>
        /// <returns></returns>
        Task<CheckPasswordResult> Check(
            string password,
            string ruleSetName = null,
            string rankingSetName = null,
            bool isCheckHaveIBeenPwned = false);

    }
}