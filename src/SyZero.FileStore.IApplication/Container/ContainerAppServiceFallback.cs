using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SyZero.Cache;
using SyZero.Client;
using SyZero.Logger;
using SyZero.Runtime.Security;
using SyZero.Serialization;
using System.IO;
using SyZero.FileStore.IApplication.Container.Dto;
using SyZero.Application.Routing;

namespace SyZero.FileStore.IApplication.Container
{
    public class ContainerAppServiceFallback : IContainerAppService, IFallback
    {
        private readonly ILogger _logger;

        public ContainerAppServiceFallback(ILogger logger)
        {
            _logger = logger;
        }

        public Task<ContainerInfoDto> ContainerInfo(string containerName)
        {
              _logger.Error("Fallback => AuthAppService:Login");
            return null;
        }

        public Task<bool> CreateContainer(string containerName, CreateContainerDto container)
        {
              _logger.Error("Fallback => AuthAppService:Login");
            return null;
        }

        public Task<bool> DeleteContainer(string containerName)
        {
              _logger.Error("Fallback => AuthAppService:Login");
            return null;
        }

        public Task<List<ContainerInfoDto>> GetContainerList()
        {
              _logger.Error("Fallback => AuthAppService:Login");
            return null;
        }

        public Task<bool> UpdateContainerInfo(string containerName, CreateContainerDto container)
        {
              _logger.Error("Fallback => AuthAppService:Login");
            return null;
        }
    }
}
