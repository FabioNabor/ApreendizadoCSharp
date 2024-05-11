namespace FTorrent.WEB.Models
{
	public class FileModel
	{
        public int id { get; set; }
        public string filename { get; set; }
        public decimal size { get; set; }
        public string filetype { get; set; }
        public string diretory { get; set; }
        public string fornecedor { get; set; }
        public string recebedor { get; set; }
        public string Identificador { get; set; }
        public DateTime date { get; set; }
    }
}
