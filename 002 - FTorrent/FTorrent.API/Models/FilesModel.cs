using System.ComponentModel.DataAnnotations;

namespace FTorrent.API.Models
{
	public class FilesModel
	{
		[Key]
		public int? id { get; set; }
		public string filename { get; set; }
		public decimal size { get; set; }
		public string filetype { get; set; }
		public string diretory { get; set; }
		public string fornecedor { get; set; }
		public string recebedor { get; set; }
		public string Identificador { get; set; }
		public DateTime date { get; set; } = DateTime.Now;


		public FilesModel()
		{

		}

		public FilesModel(int? id, string filename, decimal size, string filetype, string diretory, string fornecedor, string recebedor, string Identificador,DateTime? date)
		{
			this.id = id;
			this.filename = filename;
			this.size = size;
			this.filetype = filetype;
			this.diretory = diretory;
			this.fornecedor = fornecedor;
			this.recebedor = recebedor;
			this.Identificador = Identificador;
            this.date = DateTime.Now;
		}
	}
}
