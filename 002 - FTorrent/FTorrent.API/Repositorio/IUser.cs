using FTorrent.API.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FTorrent.API.Repositorio
{
	public interface IUser
	{
		Task<UserVO> FindByID(string id);
		Task<UserVO> FindByName(string name);
		Task<UserVO> CreateUser(UserVO user);
		Task<UserVO> UpdateUser(UserVO user);
		Task<ResultLogin> Login(LoginUser login);
	}
}
