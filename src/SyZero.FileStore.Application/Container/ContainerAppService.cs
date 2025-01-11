using Org.BouncyCastle.Crypto.Tls;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using SyZero.Application.Service;
using SyZero.FileStore.Repository;
using SyZero.Cache;
using SyZero.Logger;
using SyZero.Runtime.Security;
using SyZero.Runtime.Session;
using SyZero.Serialization;
using SyZero.Web.Common;
using System.IO;
using Microsoft.AspNetCore.Http;
using SyZero.FileStore.IApplication.Container;
using System.Net;
using System.Collections.Generic;
using SyZero.FileStore.IApplication.Container.Dto;
using SyZero.FileStore.Core.Container;
using AutoMapper.QueryableExtensions;
using System.Linq;
using SyZero.FileStore.Core.File;
using Microsoft.Extensions.FileProviders;
using Castle.Core.Resource;
using SyZero.Application.Routing;

namespace SyZero.FileStore.Application.Container
{
    public class ContainerAppService : ApplicationService, IContainerAppService
    {
        private readonly IFileInformationRepository _fileInformationRepository;
        private readonly IContainerInformationRepository _containerInformationRepository;
        private readonly ICache _cache;
        private readonly ISyEncode _syEncode;
        private readonly IToken _token;
        private readonly IJsonSerialize _jsonSerialize;
        private readonly ILogger _logger;
        private readonly ISySession _sySeeion;
        private readonly IHttpContextAccessor _contextAccessor;

        public ContainerAppService(IFileInformationRepository fileInformationRepository,
           ICache cache,
           ISyEncode syEncode,
           IToken token,
           IJsonSerialize jsonSerialize,
           ILogger logger,
           ISySession sySeeion,
           IHttpContextAccessor contextAccessor,
           IContainerInformationRepository containerInformationRepository)
        {
            _fileInformationRepository = fileInformationRepository;
            _cache = cache;
            _syEncode = syEncode;
            _token = token;
            _jsonSerialize = jsonSerialize;
            _logger = logger;
            _sySeeion = sySeeion;
            _contextAccessor = contextAccessor;
            _containerInformationRepository = containerInformationRepository;
        }

        public async Task<ContainerInfoDto> ContainerInfo(string containerName)
        {
            var container = await _containerInformationRepository.GetModelAsync(p => p.Name == containerName);
            if (container == null)
            {
                throw new SyMessageException("容器不存在！");
            }

            return ObjectMapper.Map<ContainerInfoDto>(container);
        }

        public async Task<bool> CreateContainer(string containerName, CreateContainerDto container)
        {
            var count = await _containerInformationRepository.CountAsync(p => p.Name == containerName);
            if (count > 0)
            {
                throw new SyMessageException("容器已存在！");
            }

            await _containerInformationRepository.AddAsync(new ContainerInformation(containerName, container.Description));
            return true;
        }

        public async Task<bool> DeleteContainer(string containerName)
        {
            var count = await _containerInformationRepository.CountAsync(p => p.Name == containerName);
            if (count == 0)
            {
                throw new SyMessageException("容器不存在！");
            }

            return (await _containerInformationRepository.DeleteAsync(p => p.Name == containerName)) > 0;
        }



        public async Task<List<ContainerInfoDto>> GetContainerList()
        {
            var list = await _containerInformationRepository.GetListAsync();

            return ObjectMapper.Map<List<ContainerInfoDto>>(list);
        }

        public async Task<bool> UpdateContainerInfo(string containerName, CreateContainerDto container)
        {
            var model = await _containerInformationRepository.GetModelAsync(p => p.Name == containerName);
            if (model == null)
            {
                throw new SyMessageException("容器不存在！");
            }

            model.Description = container.Description;

            return (await _containerInformationRepository.UpdateAsync(model)) > 0;
        }
    }
}