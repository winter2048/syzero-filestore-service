using AutoMapper;
using SyZero.FileStore.Core.File;
using SyZero.FileStore.IApplication.Container.Dto;
using SyZero.FileStore.Core.Container;
using SyZero.FileStore.IApplication.File.Dto;

namespace SyZero.FileStore.Application.MapProfile
{
    public class AppMapProfile : Profile
    {
        public AppMapProfile()
        {
            CreateMap<FileInformation, FileInfoDto>();
            CreateMap<FileInfoDto, FileInformation>();

            CreateMap<ContainerInformation, ContainerInfoDto>();
            CreateMap<ContainerInfoDto, ContainerInformation>();
        }
    }
}