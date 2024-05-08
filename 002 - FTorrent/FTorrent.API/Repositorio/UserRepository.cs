using AutoMapper;
using FTorrent.API.Data;
using FTorrent.API.Models;
using FTorrent.API.Service;
using FTorrent.API.ViewModel;
using Microsoft.EntityFrameworkCore;


namespace FTorrent.API.Repositorio
{
    public class UserRepository : IUser
	{

		private readonly ConnApplication _db;
		private readonly IMapper _mapper;

		public UserRepository(ConnApplication db, IMapper mapper)
		{
			_db = db;
			_mapper = mapper;
		}

		public async Task<UserVO> CreateUser(UserVO user)
		{
			UserModel userd = await _db.Users.FirstOrDefaultAsync(x => x.Name == user.Name.ToLower()) ?? new UserModel();
			if (userd.Id != null) { throw new Exception("Nome informado já existe em nossa base, use outro!"); }

			user.Password = HashPassword.CodPassword(user.Password);
			user.Name = user.Name.ToLower();

			UserModel newUser = _mapper.Map<UserModel>(user);
			_db.Users.Add(newUser);
			await _db.SaveChangesAsync();

			newUser.Password = "******-******";

			return _mapper.Map<UserVO>(newUser);
		}

		public async Task<UserVO> FindByID(string id)
		{
			UserModel user = await _db.Users.Where(x => x.Id == int.Parse(id)).FirstOrDefaultAsync() ?? new UserModel();
			return _mapper.Map<UserVO>(user);
		}

		public async Task<UserVO> FindByName(string name)
		{
			UserModel user = await _db.Users.Where(x => x.Name == name).FirstOrDefaultAsync() ?? new UserModel();
			return _mapper.Map<UserVO>(user);
		}

		public async Task<UserVO> UpdateUser(UserVO user)
		{
			UserModel auser = await _db.Users.Where(x => x.Name == user.Name).FirstOrDefaultAsync() ?? new UserModel();
			_db.Users.Update(auser);
			await _db.SaveChangesAsync();
			return _mapper.Map<UserVO>(auser);
		}

		public async Task<string> Login(LoginUser loginUser)
		{
			UserModel auser = await _db.Users.Where(x => x.Name == loginUser.UserName.ToLower() &&  x.Password == HashPassword.CodPassword(loginUser.Password)).FirstOrDefaultAsync() ?? new UserModel();
			if (auser.Id <= 0) { throw new Exception("Credenciais (Usuario, Senha), Invalidos!"); }
			var token = GenToken.GeneretionToken(_mapper.Map<UserVO>(auser));
			return token;
		}
	}
}
