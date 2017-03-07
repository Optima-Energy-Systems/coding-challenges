using System.Collections.Generic;
using System.Threading.Tasks;

namespace RobotWars.Console.Test.TestDoubles
{
	internal class StubReader
	{
		private readonly IEnumerator<string> _enumerator;

		public StubReader(IEnumerable<string> lines)
		{
			_enumerator = lines.GetEnumerator();
			LinesRead = 0;
		}

		public Task<string> Read()
		{
			return Task.FromResult(ReadLine());
		}

		private string ReadLine()
		{
			if (!_enumerator.MoveNext())
				return null;

			LinesRead++;
			return _enumerator.Current;
		}

		public int LinesRead { get; set; }
	}
}