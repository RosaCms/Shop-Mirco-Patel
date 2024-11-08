using Mango.Framework.Core.Enums;
using System.Text.Json.Serialization;

namespace Mango.Framework.Core.Models
{
    public class ResponseApi<T>
    {
      
        public T? Data { get; set; }
    
        public bool HasError { get; set; }=false;
        public string Message { get; set; } = string.Empty;
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ResultStatusEnum ResultStatus { get; set; }
        public int ResultStatusId
        {
            get => (int)ResultStatus;
        }

        #region Methods

        public void SetSuccess(T value, string? message)
        {
            SetResult(value, false, message, ResultStatusEnum.Successful);
        }

        public void SetError(string message)
        {
            SetResult(default(T), true, message, ResultStatusEnum.Error);
        }
        public void SetFail(string message)
        {
            SetResult(default(T), true, message, ResultStatusEnum.Fail);
        }

        public void SetResult(T? value, bool hasError, string? message, ResultStatusEnum status)
        {
            this.Data = value;
            this.HasError = hasError;
            this.Message = message ?? "";
            this.ResultStatus = status;
        }

        #endregion


    }

    public class ResponseApi : ResponseApi<object> { }
}
