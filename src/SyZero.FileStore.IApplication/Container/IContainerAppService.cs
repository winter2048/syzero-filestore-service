using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SyZero.Application.Attributes;
using SyZero.Application.Routing;
using SyZero.FileStore.IApplication.Container.Dto;

namespace SyZero.FileStore.IApplication.Container
{
    public interface IContainerAppService : IApplicationServiceBase
    {
        /// <summary>
        /// 获取所有容器
        /// </summary>
        /// <returns></returns>
        [Get]
        Task<List<ContainerInfoDto>> GetContainerList();

        /// <summary>
        /// 创建容器
        /// </summary>
        /// <returns></returns>
        [Post("{containerName}")]
        Task<bool> CreateContainer(string containerName, CreateContainerDto container);

        /// <summary>
        /// 删除容器
        /// </summary>
        /// <returns></returns>
        [Delete("{containerName}")]
        Task<bool> DeleteContainer(string containerName);

        /// <summary>
        /// 获取容器信息
        /// </summary>
        /// <returns></returns>
        [Get("{containerName}")]
        Task<ContainerInfoDto> ContainerInfo(string containerName);

        /// <summary>
        /// 更新容器信息
        /// </summary>
        /// <returns></returns>
        [Put("{containerName}")]
        Task<bool> UpdateContainerInfo(string containerName, CreateContainerDto container);
    }
}



