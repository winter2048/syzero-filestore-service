using AutoMapper;
using SyZero.Blog.Core.Users;
using SyZero.Blog.IApplication.Users.Dto;

namespace SyZero.Blog.Application.MapProfile
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