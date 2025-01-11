using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyZero.Application.Service.Dto;

namespace SyZero.FileStore.IApplication.File.Dto
{
    public class FileInfoDto : EntityDto
    {
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
        /// 文件哈希值
        /// </summary>
        public string Hash { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}
