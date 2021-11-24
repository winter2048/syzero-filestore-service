using SyZero.Application.Attributes;
using SyZero.Application.Service;

namespace SyZero.Blog.IApplication
{
    [DynamicWebApi]
    public interface IApplicationServiceBase : IApplicationService, IDynamicWebApi
    {
    }
}



