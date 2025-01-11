
using System.Linq;
using SyZero.FileStore.Core.File;
using SyZero.SqlSugar.Repositories;

namespace SyZero.FileStore.Repository
{
    public class FileInformationRepository : SqlSugarRepository<FileInformation>, IFileInformationRepository
    {
        public string GetTest()
        {
            var pp = this.GetList().ToList();
            return "";
        }
    }
}



