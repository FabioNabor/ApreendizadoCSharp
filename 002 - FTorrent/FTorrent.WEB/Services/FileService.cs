using FTorrent.WEB.Models;
using FTorrent.WEB.NewException;
using FTorrent.WEB.Utils;
using FTorrent.WEB.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FTorrent.WEB.Services
{
    public class FileService : IFileService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _token = null;

        public FileService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
            _token = _httpContextAccessor.HttpContext.Request.Cookies["jwt"];
            if (_token == null) { throw new Exception("Não foi encontrado nenhum token"); }
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);
        }

        public async Task<DadosUserVO> ListarMyFiles()
        {
            var response = await _httpClient.GetAsync("https://localhost:7116/api/v1/Files/MeusFiles");
            if (!response.IsSuccessStatusCode) { throw new MaxSizeFileException("Houve algum erro ao tentar enviar o arquivo, Tente novamente!"); }
            return await response.ReadContentAs<DadosUserVO>();
        }

        public async Task<IActionResult> SendFile(IFormFile file, string recebedor)
        {
            var formData = new MultipartFormDataContent();
            formData.Add(new StreamContent(file.OpenReadStream()), "file", file.FileName);
            formData.Add(new StringContent(recebedor), "recebedor");
            var response = await _httpClient.PostAsync("https://localhost:7116/api/v1/Files/Enviar", formData);
            return await response.ReadContentAs<IActionResult>();
        }
    }
}
