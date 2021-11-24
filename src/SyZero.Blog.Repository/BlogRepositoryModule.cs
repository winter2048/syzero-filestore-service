using Autofac;
using SyZero.Domain.Repository;
using SyZero.SqlSugar;

namespace SyZero.Blog.Repository
{
    public class BlogRepositoryModule : Module
    {
        public BlogRepositoryModule()
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
            // 首先注册 options，供 DbContext 服务初始化使用
            builder.AddSyZeroSqlSugar<BlogDbContext>();
            //注册仓储泛型
            builder.RegisterGeneric(typeof(BlogRepositoryBase<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope().PropertiesAutowired();
            ////注册持久化
            builder.RegisterType<UnitOfWork<BlogDbContext>>().As<IUnitOfWork>().InstancePerLifetimeScope().PropertiesAutowired();

        }
    }
}



