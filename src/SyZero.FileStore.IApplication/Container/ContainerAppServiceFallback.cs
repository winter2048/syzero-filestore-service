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
using SyZero.Web.Common;
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
            throw new NotImplementedException();
        }

        public Task<bool> CreateContainer(string containerName, CreateContainerDto container)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteContainer(string containerName)
        {
            throw new NotImplementedException();
        }

        public Task<List<ContainerInfoDto>> GetContainerList()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateContainerInfo(string containerName, CreateContainerDto container)
        {
            throw new NotImplementedException();
        }
    }
}
