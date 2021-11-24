
using SyZero.Blog.Core.Users;

namespace SyZero.Blog.Repository
{
    public class UserRepository : BlogRepositoryBase<User>, IUserRepository
    {
        public UserRepository(BlogDbContext dbContextProvider) : base(dbContextProvider)
        {

        }

        public string GetTest()
        {

            return "xxxxxx";

        }


    }
}



