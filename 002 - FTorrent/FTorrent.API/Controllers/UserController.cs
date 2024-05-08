using FTorrent.API.Repositorio;
using FTorrent.API.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FTorrent.API.Controllers
{
	public class UserController : Controller
	{
		private readonly IUser _user;

		public UserController(IUser user)
		{
			_user = user;
		}
		[Authorize(Roles = "GERENTE")]
		[HttpPost("Register")]
		public async Task<ActionResult<UserVO>> Register(UserVO user)
		{
			var newuser = await _user.CreateUser(user);
			return Ok(newuser);
		}
		[HttpGet("Login")]
		public async Task<ActionResult> Login(LoginUser loginUser)
		{
			var loginn = await _user.Login(loginUser);
			return Ok(loginn);
		}

	}
}
