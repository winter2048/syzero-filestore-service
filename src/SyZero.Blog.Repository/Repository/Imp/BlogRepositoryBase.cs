using SyZero.Domain.Entities;
using SyZero.SqlSugar.Repositories;

namespace SyZero.Blog.Repository
{
    public class BlogRepositoryBase<TEntity> : SqlSugarRepository<BlogDbContext, TEntity>
        where TEntity : class, IEntity, new()
    {
        public BlogRepositoryBase(BlogDbContext dbContext) : base(dbContext)
        {

        }

        //add common methods for all repositories
    }


}



