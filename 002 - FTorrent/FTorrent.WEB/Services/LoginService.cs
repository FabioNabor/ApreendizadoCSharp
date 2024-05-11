using FTorrent.WEB.Models;
using FTorrent.WEB.NewException;
using FTorrent.WEB.Utils;
using FTorrent.WEB.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace FTorrent.WEB.Services
{
	public class LoginService : ILoginService
	{
		private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _token = null;

		public LoginService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
		{
			_httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
			_httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException();
            _token = _httpContextAccessor.HttpContext.Request.Cookies["jwt"];
        }

		public async Task<ResultLogin> Login(LoginUser loginModel)
		{
			var response = await _httpClient.GetAsync($"https://localhost:7116/api/v1/LHome/Login?UserName={loginModel.UserName}&Password={loginModel.Password}");

			if (!response.IsSuccessStatusCode)
			{
				return new ResultLogin();			
			}

			return await response.ReadContentAs<ResultLogin>();

		}

		public async Task<IEnumerable<NameUserVO>> Usuarios()
		{
            if (_token == null) { throw new Exception("Não foi encontrado nenhum token"); }
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);
            var response = await _httpClient.GetAsync("https://localhost:7116/api/v1/LHome/Usuarios");
            if (!response.IsSuccessStatusCode) { throw new Exception("Houve algum erro!"); }
			return await response.ReadContentAs<IEnumerable<NameUserVO>>();
        }

	}
}
