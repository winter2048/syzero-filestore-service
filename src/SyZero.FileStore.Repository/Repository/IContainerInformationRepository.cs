
using SyZero.Domain.Repository;
using SyZero.FileStore.Core.Container;

namespace SyZero.FileStore.Repository
{
    public interface IContainerInformationRepository : IRepository<ContainerInformation>
    {
        string GetTest();
    }
}



