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
            throw new NotImplementedException();
        }

        public Task<AppFileStreamResult> DownloadFile(string containerName, string fileName)
        {
            throw new NotImplementedException();
        }

        public Task<FileInfoDto> FileInfo(string containerName, string fileName)
        {
            throw new NotImplementedException();
        }

        public Task<List<FileInfoDto>> GetFileList(string containerName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UploadFile(string containerName, string fileName, IFormFile file)
        {
            throw new NotImplementedException();
        }
    }
}
