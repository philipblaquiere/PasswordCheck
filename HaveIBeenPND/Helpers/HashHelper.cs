using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace HaveIBeenPND.Helpers
{
	public static class HashHelper
	{
		public static string SHA1Hash(string input)
		{
			return string.Join("", new SHA1Managed()
				.ComputeHash(Encoding.UTF8.GetBytes(input))
				.Select(inputByte => inputByte.ToString("X2"))
				.ToArray());
		}
	}
}
