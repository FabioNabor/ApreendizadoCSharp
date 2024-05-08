using AutoMapper;
using FTorrent.API.Models;
using FTorrent.API.ViewModel;

namespace FTorrent.API.Config
{
	public class MappingConfig
	{
		public static MapperConfiguration RegisterMaps()
		{
			var mappingConfig = new MapperConfiguration(config =>
			{
				config.CreateMap<UserModel, UserVO>();
				config.CreateMap<UserVO, UserModel>();
			});
			return mappingConfig;
		}
	}
}
