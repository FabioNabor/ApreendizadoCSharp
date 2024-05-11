using FTorrent.WEB.Models;
using FTorrent.WEB.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FTorrent.WEB.Controllers
{
	public class HomeController : Controller
	{
        private readonly ILoginService _lg;

        public HomeController( ILoginService loginService)
		{
			_lg = loginService;
		}

		public async Task<IActionResult> Index()
		{
            HttpContext.Response.Cookies.Delete("jwt");
            return View();
		}

        [HttpPost]
		public async Task<IActionResult> Login(string username, string password)
		{
            LoginUser model = new LoginUser();
            model.UserName = username;
            model.Password = password;
            var response = await _lg.Login(model);
            
            if (response.token != null)
            {
                HttpContext.Response.Cookies.Append("jwt", response.token);
                return RedirectToAction("Central", "Gerenciador");
            }
            TempData["UsuarioInvalido"] = "Credenciais (Usuário, Senha) invalidos!";
            return View("Index");  
        }
	}
}
