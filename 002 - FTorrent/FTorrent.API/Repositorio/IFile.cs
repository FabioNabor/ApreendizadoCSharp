using FTorrent.API.Models;
using FTorrent.API.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FTorrent.API.Repositorio
{
	public interface IFile
	{
		Task<FilesModel> UpdateFile(IFormFile file, string id_fornecedor, string name_recebedor);
		Task<FilesModel> FindFile(string name);
		Task<IEnumerable<FilesModel>> FindAllFiles();
		Task<DadosUserVO> FindAllMyFiles(string name);
	}
}
