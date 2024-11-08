using Mango.Framework.Core.Enums;

namespace Mango.Framework.Core.Models
{
    public class RequestApi
    {
        public object? Data { get; set; }=null;
        public string Url { get; set; } = String.Empty;
        public string AccessToken { get; set; }=String.Empty;
        public ApiTypeEnum ApiType { get; set; }
    }

}
