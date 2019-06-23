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
		public HaveIBeenPNDService(IHaveIBeenPNDClient client = null)
		{
			HaveIBeenPNDClient = client ?? new HaveIBeenPNDClient();
		}

		internal IHaveIBeenPNDClient HaveIBeenPNDClient { get; }

		public async Task<PNDPassword> HaveIBeenPND(string password)
		{
			if(string.IsNullOrEmpty(password))
			{
				return null;
			}

			var hashedPassword = HashHelper.SHA1Hash(password);

			string prefix = hashedPassword.Substring(0, 5);

			var response = await HaveIBeenPNDClient.Range(prefix);

			return response
				.GetPNDPasswords(prefix)
				.FirstOrDefault(pndPassword => pndPassword.SHA1Password == hashedPassword);
		}
	}
}
