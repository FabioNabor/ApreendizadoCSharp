using FTorrent.WEB.Models;
using FTorrent.WEB.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FTorrent.WEB.Services
{
	public interface ILoginService
	{
		Task<ResultLogin> Login(LoginUser loginModel);
		Task<IEnumerable<FileModel>> MyFiles(string token);
	}
}
