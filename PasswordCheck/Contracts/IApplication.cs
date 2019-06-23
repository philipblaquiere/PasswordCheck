using System.Threading.Tasks;

namespace PasswordCheck.Contracts
{
	public interface IApplication
	{
		/// <summary>
		/// Runs the Application
		/// </summary>
		/// <returns></returns>
		Task Run();
	}
}
