using FTorrent.WEB.Models;
using FTorrent.WEB.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FTorrent.WEB.Services
{
    public interface IFileService
    {
        Task<DadosUserVO> ListarMyFiles();
        Task<IActionResult> SendFile(IFormFile file, string recebedor);

    }
}
