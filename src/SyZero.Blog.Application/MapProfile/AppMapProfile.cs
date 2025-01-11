using AutoMapper;
using SyZero.FileStore.Core.Users;
using SyZero.FileStore.IApplication.Users.Dto;

namespace SyZero.FileStore.Application.MapProfile
{
    public class AppMapProfile : Profile
    {
        public AppMapProfile()
        {
            CreateMap<User, CreateUserDto>();
            CreateMap<CreateUserDto, User>();

            
        }
    }
}