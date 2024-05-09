using FTorrent.WEB.Models;
using FTorrent.WEB.Services;
using FTorrent.WEB.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FTorrent.WEB.Controllers
{
	public class LoginController : Controller
	{

		private readonly ILoginService _lg;

		public LoginController(ILoginService lg)
		{
			_lg = lg;
		}

		public async Task<IActionResult> LoginHome()
		{
			LoginUser model = new LoginUser();
			model.UserName = "fabionabor";
			model.Password = "bcard123";
			var response = await _lg.Login(model);

			var mostrar = await _lg.MyFiles(response.token);

			return View(mostrar);
		}
	}
}
