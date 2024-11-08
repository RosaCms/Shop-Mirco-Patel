using Mango.Framework.Core.Models;

namespace Mango.Framework.Infrastructure.Service
{
    public interface IBaseService
    {
        Task<ResponseApi<TRes?>> SendAsync<TRes>(RequestApi request);
    }
 

}
