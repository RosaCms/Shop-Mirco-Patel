using Mango.Framework.Core.Enums;

namespace Mango.Framework.Core.Models
{
    public class RequestApi<T>
    {
        public T? Data { get; set; }
        public string Url { get; set; } = String.Empty;
        public string AccessToken { get; set; }=String.Empty;
        public ApiTypeEnum ApiType { get; set; }
    }

    public class RequestApi : RequestApi<object>;
}
