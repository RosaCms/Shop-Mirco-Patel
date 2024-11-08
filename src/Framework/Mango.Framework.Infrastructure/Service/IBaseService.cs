using Mango.Framework.Core.Models;

namespace Mango.Framework.Infrastructure.Service
{
    public interface IBaseService<T>
    {
        Task<ResponseApi<T?>> SendAsync(RequestApi<T> request);
    }

    public interface IBaseService : IBaseService<object>;
}
