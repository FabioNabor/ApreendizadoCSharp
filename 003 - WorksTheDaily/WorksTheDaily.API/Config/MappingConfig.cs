using AutoMapper;
using WorksTheDaily.API.Model;
using WorksTheDaily.API.View;

namespace WorksTheDaily.API.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration( config =>
            {
                config.CreateMap<TaskPO, TaskModel>();
                config.CreateMap<TaskModel, TaskPO>();
            });
            return mappingConfig;
        }
    }
}
