using FTorrent.API.Data;
using FTorrent.API.Models;
using FTorrent.API.Service;
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

		public async Task<DadosUserVO> FindAllMyFiles(string name)
		{
			var ddname = await _conn.Users.Where(x => x.Name == name).FirstOrDefaultAsync();
			List<FilesModel> files = await _conn.Files.Where(x => x.recebedor == name).ToListAsync();
			DadosUserVO dados = new DadosUserVO(ddname.NameCompleto, files);
			return dados;
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

            string indenty = GeneryIdentificador.GenIdentificador($"{name_fornecedor}{name_recebedor}{file.FileName}{DateTime.Now}");
			string filename = $"{indenty.ToUpper()}.{GetFileType(file.FileName)}";
            var path = Path.Combine("Files", filename);

			using Stream filepath = new FileStream(path, FileMode.Create);
			await file.CopyToAsync(filepath);
			
			var files = new FilesModel(null, file.FileName.ToString(), file.Length, file.ContentType, path, name_fornecedor, user.Name, indenty.ToUpper() ,null);
			await _conn.Files.AddAsync(files);
			await _conn.SaveChangesAsync();

			return files;
		}

        public string GetFileType(string fileName)
        {
            // Obtém a extensão do arquivo
            string extension = Path.GetExtension(fileName);

            // Se a extensão não estiver vazia e começar com '.', remove o ponto
            if (!string.IsNullOrEmpty(extension) && extension.StartsWith('.'))
            {
                extension = extension.Substring(1);
            }

            return extension;
        }
    }
}
