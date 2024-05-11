using FTorrent.API.Repositorio;
using FTorrent.API.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FTorrent.API.Controllers
{
	[Route("api/v1/LHome")]
	[ApiController]
	public class UserController : Controller
	{
		private readonly IUser _user;

		public UserController(IUser user)
		{
			_user = user;
		}
		[Authorize]
		[HttpPost("Register")]
		public async Task<ActionResult<UserVO>> Register(UserVO user)
		{
			var newuser = await _user.CreateUser(user);
			return Ok(newuser);
		}
		[HttpGet("Login")]
		public async Task<ActionResult<ResultLogin>> Login([FromQuery]LoginUser loginUser)
		{
			var loginn = await _user.Login(loginUser);
			return Ok(loginn);
		}

		[Authorize]
		[HttpGet("Usuarios")]
		public async Task<ActionResult<IEnumerable<NameUserVO>>> Usuarios()
		{
			var usuarios = await _user.ListUsers();
			return Ok(usuarios);
		}

	}
}
