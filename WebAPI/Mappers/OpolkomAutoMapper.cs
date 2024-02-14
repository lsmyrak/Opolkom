using AutoMapper;
using Contracts.Dtos.Task;
using Contracts.Dtos.User;
using Domain.Model;

namespace WebAPI.Mappers
{
    public class OpolkomAutoMapper : Profile
    {
        public OpolkomAutoMapper()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<UserDto, RegisterUserDto>();
            CreateMap<RegisterUserDto, UserDto>();
            CreateMap<RegisterUserDto, User>();
            CreateMap<User, RegisterUserDto>();

            CreateMap<Role, RoleDto>();
            CreateMap<RoleDto, Role>();

            CreateMap<Work, WorkDto>();
            CreateMap<WorkDto, Work>();


            CreateMap<User, UserWorkDto>()
            .ForMember(dest => dest.WorkListDto, opt => opt.MapFrom(src => new WorkListDto
            {
                Tasks = src.Works.Select(x => x.ToDto()).ToList(),
            }));

            CreateMap<UserWorkDto, UserWorkOnlyCalcDto>()
                .ForMember(dest => dest.TaskCount, src => src.MapFrom(src => src.WorkListDto.Count))
                .ForMember(dest => dest.TotalPrice, src => src.MapFrom(src => src.WorkListDto.TotalPrice));
        }
    }
}
