using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyZero.Domain.Entities;

namespace SyZero.FileStore.Core.Container
{
    public class ContainerInformation : Entity
    {
        /// <summary>
        /// 容器名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; } = DateTime.Now;

        public ContainerInformation()
        {
        }

        public ContainerInformation(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public ContainerInformation(string name)
        {
            Name = name;
        }
    }
}
