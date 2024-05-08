using Aprendendo.Models;
using System.Text;

namespace Aprendendo
{
	internal class Program
	{
		static async Task Main(string[] args)
		{
			Task<int> str = batata();

			var r = await str;

			Console.WriteLine(str);
			Console.WriteLine("Oha");

			static async Task<int> batata()
			{
				await Task.Delay(1000);

				return 100+50;
			}
		}
	}
}
