using AutoMapper;
using FTorrent.API.Models;
using FTorrent.API.ViewModel;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FTorrent.API.Service
{
	public class GenToken
	{

		public static string GeneretionToken(UserVO user)
		{

			var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c"));
			var issuer = "admin";
			var audience = "fabioOnabor";

			var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature);

			var tokenOptions = new JwtSecurityToken(
				issuer: issuer,
				audience: audience,
				claims: new[]
				{
					new Claim("nomecompleto", user.NameCompleto),
					new Claim("name", user.Name),
					new Claim(ClaimTypes.Role, user.role)
				},
				expires: DateTime.Now.AddMinutes(15),
				signingCredentials: signingCredentials);

			var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
			return token;
		}
	}
}
