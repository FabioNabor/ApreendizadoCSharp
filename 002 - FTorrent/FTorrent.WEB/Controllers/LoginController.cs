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

			Response.Cookies.Append("jwt",  response.token ,new CookieOptions
			{
				HttpOnly = true,
				Secure = true,
				SameSite = SameSiteMode.None
			});

			var token = HttpContext.Response.Cookies["jwt"];

			var mostrar = await _lg.MyFiles();

			return View(mostrar);
		}
	}
}
