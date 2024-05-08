using FTorrent.API.Data;
using FTorrent.API.Models;
using FTorrent.API.ViewModel;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FTorrent.API.Repositorio
{
	public class FileRepository : IFile
	{

		private readonly IUser _user;

		private readonly ConnApplication _conn;

		public FileRepository(IUser user, ConnApplication conn)
		{
			_user = user;
			_conn = conn;
		}

		public async Task<IEnumerable<FilesModel>> FindAllFiles()
		{
			List<FilesModel> files = await _conn.Files.ToListAsync();
			return files;
		}

		public async Task<IEnumerable<FilesModel>> FindAllMyFiles(string name)
		{
			List<FilesModel> files = await _conn.Files.Where(x => x.recebedor == name).ToListAsync();
			return files;
		}

		public async Task<FilesModel> FindFile(string name)
		{
			var file = await _conn.Files.FirstOrDefaultAsync(x => x.filename == name) ?? new FilesModel();
			return file;
		}

		public async Task<FilesModel> UpdateFile(IFormFile file, string name_fornecedor, string name_recebedor)
		{
			UserVO user = await _user.FindByName(name_recebedor);
			if (user.Name == null) { throw new Exception("Usuário não localizado!"); }

			var path = Path.Combine("Files", file.FileName);

			using Stream filepath = new FileStream(path, FileMode.Create);
			await file.CopyToAsync(filepath);

			var files = new FilesModel(null, file.FileName.ToString(), file.Length, file.ContentType, path, name_fornecedor, user.Name);
			await _conn.Files.AddAsync(files);
			await _conn.SaveChangesAsync();

			return files;
		}
	}
}
