using FTorrent.WEB.Models;

namespace FTorrent.WEB.ViewModel
{
    public class DadosUserVO
    {
        public string name {  get; set; }
        public List<FileModel> files { get; set; }

        public DadosUserVO() { }

        public DadosUserVO(string name, List<FileModel> files)
        {
            this.name = name;
            this.files = files;
        }
    }
}
