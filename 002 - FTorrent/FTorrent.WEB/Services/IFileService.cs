using FTorrent.WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace FTorrent.WEB.Services
{
    public interface IFileService
    {
        Task<IEnumerable<FileModel>> ListarMyFiles(string token);
        Task<IActionResult> Download(string name, string token);

    }
}
