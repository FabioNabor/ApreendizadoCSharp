using Aprendendo.Models;

namespace Aprendendo
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<UserModel> users = new List<UserModel>();
			users.Add(new UserModel("FABIO NABOR", "BCARD123"));
			users.Add(new UserModel("JOESLENA F NABOR", "BCARD123"));
			users.Add(new UserModel("FABIANA NABOR NABOR", "BCARD123"));
			var conteudo = users.Where(x => x.UserName.Contains("F")).ToList();


			int[][] ints = new int[3][];

			Console.WriteLine(ints);


			foreach (var user in conteudo)
			{
				Console.WriteLine( user.ToString());
			}
		}
	}
}
