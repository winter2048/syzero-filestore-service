
using SyZero.FileStore.Core.Users;
using SyZero.Domain.Repository;

namespace SyZero.FileStore.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        string GetTest();
    }
}



