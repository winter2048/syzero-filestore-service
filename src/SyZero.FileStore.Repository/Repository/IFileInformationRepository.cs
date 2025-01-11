
using SyZero.Domain.Repository;
using SyZero.FileStore.Core.File;

namespace SyZero.FileStore.Repository
{
    public interface IFileInformationRepository : IRepository<FileInformation>
    {
        string GetTest();
    }
}



