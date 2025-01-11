using Org.BouncyCastle.Crypto.Tls;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using SyZero.Application.Service;
using SyZero.FileStore.IApplication.Users;
using SyZero.FileStore.Repository;
using SyZero.Cache;
using SyZero.Logger;
using SyZero.Runtime.Security;
using SyZero.Runtime.Session;
using SyZero.Serialization;
using SyZero.Web.Common;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using SyZero.FileStore.Core.File;
using SyZero.Application.Routing;
using System.Linq;
using SyZero.FileStore.IApplication.File.Dto;

namespace SyZero.FileStore.Application.Users
{
    public class FileAppService : ApplicationService, IFileAppService
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

        public FileAppService(IFileInformationRepository fileInformationRepository,
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

        public async Task<bool> DeleteFile(string containerName, string fileName)
        {
            var container = await _containerInformationRepository.GetModelAsync(p => p.Name == containerName);
            if (container == null)
            {
                throw new SyMessageException("容器不存在！");
            }

            var file = await _fileInformationRepository.GetModelAsync(p => p.Name == fileName && p.ContainerId == container.Id);
            if (file == null)
            {
                throw new SyMessageException("文件不存在！");
            }

            var path = Path.Combine(Directory.GetCurrentDirectory(), file.FilePath);

            if ((await _fileInformationRepository.DeleteAsync(file.Id)) > 0)
            {
                if (File.Exists(path) && await _fileInformationRepository.CountAsync(p => p.Hash == file.Hash) == 0)
                {
                    File.Delete(path);
                }

                return true;
            }

            return false;
        }

        public async Task<AppFileStreamResult> DownloadFile(string containerName, string fileName)
        {
            var container = await _containerInformationRepository.GetModelAsync(p => p.Name == containerName);
            if (container == null)
            {
                throw new SyMessageException("容器不存在！");
            }

            var file = await _fileInformationRepository.GetModelAsync(p => p.Name == fileName && p.ContainerId == container.Id);
            if (file == null)
            {
                throw new SyMessageException("文件不存在！");
            }

            var path = Path.Combine(Directory.GetCurrentDirectory(), file.FilePath);

            return new AppFileStreamResult(File.OpenRead(path), file.OriginalName, file.ContentType);
        }

        public async Task<FileInfoDto> FileInfo(string containerName, string fileName)
        {
            var container = await _containerInformationRepository.GetModelAsync(p => p.Name == containerName);
            if (container == null)
            {
                throw new SyMessageException("容器不存在！");
            }

            var file = await _fileInformationRepository.GetModelAsync(p => p.Name == fileName && p.ContainerId == container.Id);
            if (file == null)
            {
                throw new SyMessageException("文件不存在！");
            }

            return ObjectMapper.Map<FileInfoDto>(file);
        }

        public async Task<List<FileInfoDto>> GetFileList(string containerName)
        {
            var container = await _containerInformationRepository.GetModelAsync(p => p.Name == containerName);
            if (container == null)
            {
                throw new SyMessageException("容器不存在！");
            }

            var list = await _fileInformationRepository.GetListAsync(p => p.ContainerId == container.Id);

            return ObjectMapper.Map<List<FileInfoDto>>(list);
        }

        public async Task<bool> UploadFile(string containerName, string fileName, IFormFile file)
        {
            // 检查文件是否为空
            if (file == null || file.Length == 0)
            {
                throw new SyMessageException("请上传一个有效的文件！");
            }

            var container = await _containerInformationRepository.GetModelAsync(p => p.Name == containerName);
            if (container == null)
            {
                throw new SyMessageException("容器不存在！");
            }

            var count = await _fileInformationRepository.CountAsync(p => p.Name == fileName && p.ContainerId == container.Id);
            if (count > 0)
            {
                throw new SyMessageException("文件已存在！");
            }

            // 获取文件的哈希值
            string fileHash;
            using (var stream = file.OpenReadStream())
            {
                fileHash = stream.GetFileHash();
            }

            var exFileInfo = (await _fileInformationRepository.GetListAsync(p => p.Hash == fileHash && p.ContainerId == container.Id)).FirstOrDefault();

            if (exFileInfo == null)
            {
                // 设置保存文件的路径
                var path = Path.Combine(Directory.GetCurrentDirectory(), $"UploadedFiles/{containerName}", $"{DateTime.Now.ToString("yyMMddHHmmssfff")}-{file.FileName}");

                // 确保目录存在
                if (!Directory.Exists(Path.GetDirectoryName(path)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(path));
                }

                // 将文件内容写入到指定路径
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                await _fileInformationRepository.AddAsync(new FileInformation()
                {
                    ContainerId = container.Id,
                    Name = fileName,
                    OriginalName = file.FileName,
                    Hash = fileHash,
                    FilePath = Path.GetRelativePath(Directory.GetCurrentDirectory(), path),
                    ContentType = file.ContentType,
                });
            }
            else
            {
                await _fileInformationRepository.AddAsync(exFileInfo.Copy(fileName, file.FileName));
            }

            return true;
        }
    }
}