using SyZero.Application.Attributes;
using SyZero.Application.Service;

namespace SyZero.FileStore.IApplication
{
    [DynamicWebApi]
    public interface IApplicationServiceBase : IApplicationService, IDynamicWebApi
    {
    }
}



