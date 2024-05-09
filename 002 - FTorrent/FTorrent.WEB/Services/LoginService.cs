﻿using FTorrent.WEB.Models;
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
		public const String BasePatch = "api/v1/LHome";

		public LoginService(HttpClient httpClient)
		{
			_httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient)); ;
		}

		public async Task<ResultLogin> Login(LoginUser loginModel)
		{
			var response = await _httpClient.GetAsync($"https://localhost:7116/api/v1/LHome/Login?UserName={loginModel.UserName}&Password={loginModel.Password}");

			return await response.ReadContentAs<ResultLogin>();
		}

		public async Task<IEnumerable<FileModel>> MyFiles(string token)
		{
			_httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
			var response = await _httpClient.GetAsync("https://localhost:7116/api/v1/Files/MeusFiles");
			return await response.ReadContentAs<IEnumerable<FileModel>>();
		}
	}
}
