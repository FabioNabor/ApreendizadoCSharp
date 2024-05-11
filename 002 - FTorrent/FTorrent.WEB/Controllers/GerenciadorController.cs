using FTorrent.WEB.Models;
using FTorrent.WEB.NewException;
using FTorrent.WEB.Services;
using FTorrent.WEB.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FTorrent.WEB.Controllers
{
	public class GerenciadorController : Controller
	{
		private readonly IFileService _fileService;
		private readonly ILoginService _loginService;
        private readonly HttpClient _httpClient;

        public GerenciadorController(IFileService fileService, ILoginService loginService,HttpClient httpClient)
		{
			_fileService = fileService;
			_loginService = loginService;
			_httpClient = httpClient;
		}

		public async Task<IActionResult> Central()
		{
			try
			{
				return View(await _fileService.ListarMyFiles());
			}
			catch (Exception ex)
			{
				return RedirectToAction("Index", "Home");
			}
		}

		[HttpGet]
		public async Task<IActionResult> DownloadFile(string file)
		{
			var token = HttpContext.Request.Cookies["jwt"];
			if (token == null)
			{
				return RedirectToAction("Index", "Home");
			}
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync($"https://localhost:7116/api/v1/Files/Arquivo?filename={file}");
			var fileBytes = await response.Content.ReadAsStreamAsync();
			var contentType = response.Content.Headers.ContentType?.MediaType;
			return File(fileBytes, contentType, file);
        }

        public async Task<IActionResult> Enviar()
		{
			var usuarios = await _loginService.Usuarios();
			return View(usuarios);
		}

        [HttpPost]
		public async Task<IActionResult> Enviar(IFormFile file, string recebedor)
		{
			try
			{
				var response = _fileService.SendFile(file, recebedor);
                TempData["Sucesso"] = "Arquivo enviado com sucesso!";
                return RedirectToAction("Central");
			}
			catch (MaxSizeFileException e)
			{
				TempData["ArquivoGrande"] = e.Message;
                return RedirectToAction("Central");
            }
		}

		public async Task<IActionResult> Logout()
		{
			HttpContext.Response.Cookies.Delete("jwt");
            return RedirectToAction("Index", "Home");
        }

		
	}
}
