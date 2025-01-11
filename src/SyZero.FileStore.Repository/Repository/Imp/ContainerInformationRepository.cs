
using System.Linq;
using SyZero.FileStore.Core.Container;
using SyZero.FileStore.Core.File;
using SyZero.SqlSugar.Repositories;

namespace SyZero.FileStore.Repository
{
    public class ContainerInformationRepository : SqlSugarRepository<ContainerInformation>, IContainerInformationRepository
    {
        public string GetTest()
        {
            var pp = this.GetList().ToList();
            return "";
        }
    }
}



