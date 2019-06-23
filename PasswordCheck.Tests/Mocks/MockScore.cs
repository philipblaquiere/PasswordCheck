using PasswordCheck.Contracts;

namespace PasswordCheck.Tests.Data
{
	public class MockScore : IScore
	{
		public MockScore(int score)
		{
			Score = score;
		}

		public int Score { get; }
	}
}
