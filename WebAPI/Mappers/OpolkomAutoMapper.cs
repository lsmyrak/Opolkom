using AutoMapper;
using Contracts.Dtos.User;
using Domain.Model;

namespace WebAPI.Mappers
{
    public class OpolkomAutoMapper:Profile
    {
        public OpolkomAutoMapper()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<Role, RoleDto>();
            CreateMap<RoleDto, Role>();
        }
    }
}
