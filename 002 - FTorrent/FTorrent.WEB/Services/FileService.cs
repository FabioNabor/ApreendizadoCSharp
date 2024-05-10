using FTorrent.WEB.Models;
using FTorrent.WEB.Utils;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FTorrent.WEB.Services
{
    public class FileService : IFileService
    {
        private readonly HttpClient _httpClient;
        public const String BasePatch = "api/v1/Files";

        public FileService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Download(string name, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync($"https://localhost:7116/api/v1/Files/Arquivo/{name}");

            return await response.ReadContentAs<IActionResult>();
        }

        public async Task<IEnumerable<FileModel>> ListarMyFiles(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync("https://localhost:7116/api/v1/Files/MeusFiles");
            return await response.ReadContentAs<IEnumerable<FileModel>>();
        }
    }
}
