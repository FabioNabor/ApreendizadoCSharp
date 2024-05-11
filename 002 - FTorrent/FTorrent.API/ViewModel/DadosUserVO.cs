using FTorrent.API.Models;

namespace FTorrent.API.ViewModel
{
    public class DadosUserVO
    {
        public string name { get; set; }
        public List<FilesModel> files { get; set; }

        public DadosUserVO() { }

        public DadosUserVO(string name, List<FilesModel> files)
        {
            this.name = name;
            this.files = files;
        }
    }
}
