using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SyZero.Application.Attributes;
using SyZero.Application.Routing;
using SyZero.FileStore.IApplication.File.Dto;

namespace SyZero.FileStore.IApplication.Users
{
    [Api("Container")]
    public interface IFileAppService : IApplicationServiceBase
    {
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <returns></returns>
        [Post("{containerName}/File/{fileName}")]
        Task<bool> UploadFile(string containerName, string fileName, IFormFile file);

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <returns></returns>
        [Delete("{containerName}/File/{fileName}")]
        Task<bool> DeleteFile(string containerName, string fileName);

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <returns></returns>
        [Get("{containerName}/File/{fileName}")]
        Task<AppFileStreamResult> DownloadFile(string containerName, string fileName);

        /// <summary>
        /// 获取文件信息
        /// </summary>
        /// <returns></returns>
        [Get("{containerName}/File/{fileName}/Info")]
        Task<FileInfoDto> FileInfo(string containerName, string fileName);

        /// <summary>
        /// 获取容器下的所有文件
        /// </summary>
        /// <returns></returns>
        [Get("{containerName}/File")]
        Task<List<FileInfoDto>> GetFileList(string containerName);
    }
}



