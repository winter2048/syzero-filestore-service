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
using SyZero.Application.Routing;
using SyZero.FileStore.IApplication.File.Dto;

namespace SyZero.FileStore.IApplication.Users
{
    public class FileAppServiceFallback : IFileAppService, IFallback
    {
        private readonly ILogger _logger;

        public FileAppServiceFallback(ILogger logger)
        {
            _logger = logger;
        }

        public Task<bool> DeleteFile(string containerName, string fileName)
        {
               _logger.Error("Fallback => AuthAppService:Login");
            return null;
        }

        public Task<AppFileStreamResult> DownloadFile(string containerName, string fileName)
        {
               _logger.Error("Fallback => AuthAppService:Login");
            return null;
        }

        public Task<FileInfoDto> FileInfo(string containerName, string fileName)
        {
               _logger.Error("Fallback => AuthAppService:Login");
            return null;
        }

        public Task<List<FileInfoDto>> GetFileList(string containerName)
        {
               _logger.Error("Fallback => AuthAppService:Login");
            return null;
        }

        public Task<bool> UploadFile(string containerName, string fileName, IFormFile file)
        {
               _logger.Error("Fallback => AuthAppService:Login");
            return null;
        }
    }
}
