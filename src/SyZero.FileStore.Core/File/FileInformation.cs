using System;
using System.IO;
using System.Security.Cryptography;
using SyZero.Domain.Entities;

namespace SyZero.FileStore.Core.File
{
    /// <summary>
    /// 文件信息
    /// </summary>
    public class FileInformation : Entity
    {
        public long ContainerId { get; set; }

        /// <summary>
        /// 文件名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 文件名
        /// </summary>
        public string OriginalName { get; set; }

        /// <summary>
        /// 文件扩展名
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// 文件地址
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// 文件哈希值
        /// </summary>
        public string Hash { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; } = DateTime.Now;

        public FileInformation()
        {
        }

        public FileInformation Copy(string fileName = null, string originalName = null)
        {
            return new FileInformation()
            {
                Name = string.IsNullOrWhiteSpace(fileName) ? Name : fileName,
                FilePath = FilePath,
                Hash = Hash,
                ContentType = ContentType,
                ContainerId = ContainerId,
                OriginalName = string.IsNullOrWhiteSpace(originalName) ? OriginalName : originalName,
            };
        }
    }
}