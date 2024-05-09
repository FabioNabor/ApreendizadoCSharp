using FTorrent.API.Models;
using FTorrent.API.Repositorio;
using FTorrent.API.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FTorrent.API.Controllers
{
	[Route("api/v1/Files")]
	[Authorize]
	public class FileContoller : ControllerBase
	{
		private readonly IFile _filerp;

		public FileContoller(IFile filerp)
		{
			_filerp = filerp;

		}

		[HttpPost("Enviar")]
		public async Task<ActionResult> UploadFile(IFormFile file, string recebedor)
		{
			var	name = User.FindFirst("name")?.Value;
			if (name.ToLower() == recebedor) { return NotFound("Você não pode enviar arquivos pra você mesmo!"); }
			await _filerp.UpdateFile(file, name.ToLower(), recebedor);
			return Ok();
		}

		[HttpGet("Arquivo/{filename}")]
		public async Task<ActionResult> DownloadFile(string filename)
		{
			var name = User.FindFirst("name")?.Value;
			var file = await _filerp.FindFile(filename);

			if (file.recebedor != name.ToLower())
				return BadRequest("Esse arquivo não foi enviado a você, ou não te pertence!"); 
			

			var diretory = Path.Combine(Directory.GetCurrentDirectory(), file.diretory);

			if (file.id <= 0)  return BadRequest("Arquivo não encontrado"); 

			if (!System.IO.File.Exists(diretory))  return BadRequest("Arquivo não foi localizado no banco de dados de arquivos"); 
			var filestream = new FileStream(diretory, FileMode.Open);
			return File(filestream, file.filetype, filename);
		}

		[HttpGet("MeusFiles")]
		public async Task<ActionResult<IEnumerable<FilesModel>>> MyFiles()
		{
			var name = User.FindFirst("name")?.Value;
			var list = await _filerp.FindAllMyFiles(name.ToLower());
			return Ok(list);
		}
	}
}
