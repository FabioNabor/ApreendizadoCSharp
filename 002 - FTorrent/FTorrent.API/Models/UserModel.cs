using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace FTorrent.API.Models
{
	public class UserModel
	{
		[Key]
		public int? Id { get; set; }
		public string NameCompleto { get; set; }
		public string Name { get; set; }
		public string Password { get; set; }
		public string role { get; set; } = "FUNCIONARIO";
		public DateTime? DataCadastro { get; set; } = DateTime.Now;

		public UserModel() { }

		public UserModel(int? id, string name, string NameCompleto, string password, string role, DateTime? dataCadastro)
		{
			Id = id;
			Name = name;
			this.NameCompleto = NameCompleto;
			Password = password;
			this.role = role;
			DataCadastro = dataCadastro;
		}

	}
}
