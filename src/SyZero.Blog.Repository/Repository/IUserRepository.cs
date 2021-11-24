
using SyZero.Blog.Core.Users;
using SyZero.Domain.Repository;

namespace SyZero.Blog.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        string GetTest();
    }
}



