using System.Linq;
using System.Threading.Tasks;
using HaveIBeenPND.Contracts;
using HaveIBeenPND.Entities;
using HaveIBeenPND.Helpers;

namespace HaveIBeenPND
{
	public class HaveIBeenPNDService : IHaveIBeenPNDService
	{
		public HaveIBeenPNDService()
		{
			HaveIBeenPNDClient = new HaveIBeenPNDClient();
		}

		internal IHaveIBeenPNDClient HaveIBeenPNDClient { get; }

		public async Task<PNDPassword> HaveIBeenPND(string password)
		{
			if(string.IsNullOrEmpty(password))
			{
				return null;
			}

			var hashedPassword = HashHelper.SHA1Hash(password);

			var passwords = await HaveIBeenPNDClient.Range(hashedPassword.Substring(0,5));

			return passwords.FirstOrDefault(pndPassword => pndPassword.SHA1Password == hashedPassword);
		}
	}
}
