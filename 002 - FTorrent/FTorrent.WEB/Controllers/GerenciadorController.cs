using FTorrent.WEB.Services;
using Microsoft.AspNetCore.Mvc;

namespace FTorrent.WEB.Controllers
{
	public class GerenciadorController : Controller
	{
		private readonly IFileService _fileService;
        private readonly HttpClient _httpClient;

        public GerenciadorController(IFileService fileService, HttpClient httpClient)
		{
			_fileService = fileService;
			_httpClient = httpClient;
		}

		public async Task<IActionResult> Central()
		{
			var token = HttpContext.Request.Cookies["jwt"];
			if (token == null)
			{
				return RedirectToAction("Index", "Home");
			}
			var list = await _fileService.ListarMyFiles(token);

			return View(list);
		}

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
	}
}
