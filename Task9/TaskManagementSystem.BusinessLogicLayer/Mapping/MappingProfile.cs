using AutoMapper;
using TaskManagementSystem.BusinessLogicLayer.Models;
using TaskManagementSystem.DataAccessLayer;

namespace TaskManagementSystem.BusinessLogicLayer.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserEntity>().ReverseMap();
            CreateMap<Role, RoleEntity>().ReverseMap();
            CreateMap<Models.Task, TaskEntity>().ReverseMap();
        }
    }
}
