using System.Linq;
using System.Threading.Tasks;
using HaveIBeenPND.Contracts;
using HaveIBeenPND.Entities;
using HaveIBeenPND.Entities.Extensions;
using HaveIBeenPND.Helpers;

namespace HaveIBeenPND
{
    public class HaveIBeenPNDService : IHaveIBeenPNDService
    {
        private readonly IHaveIBeenPNDClient haveIBeenPNDClient;

        public HaveIBeenPNDService(IHaveIBeenPNDClient? haveIBeenPNDClient = null)
        {
            this.haveIBeenPNDClient = haveIBeenPNDClient ?? new HaveIBeenPNDClient();
        }

        public async Task<PNDPassword?> HaveIBeenPND(string? password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return null;
            }

            var hashedPassword = HashHelper.SHA1Hash(password);

            string prefix = hashedPassword[..5];

            var response = await this.haveIBeenPNDClient.Range(prefix);

            return response
                .GetPNDPasswords(prefix)
                .FirstOrDefault(pndPassword => pndPassword.SHA1Password == hashedPassword);
        }
    }
}
