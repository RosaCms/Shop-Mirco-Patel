
using System.Net;
using Mango.Framework.Core.Enums;
using Mango.Framework.Core.Models;
using Mango.Framework.Infrastructure.Service;
using Mango.Framework.Web.Resources;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Mango.Framework.Web.Services
{
    public class BaseService<T>(IHttpClientFactory httpClientFactory, IStringLocalizer localizer,ILogger<BaseService<T>> logger) : IBaseService<T>
    {
        public async Task<ResponseApi<T?>> SendAsync(RequestApi<T> request)
        {
            ResponseApi<T> result = new();
            try
            {
                HttpClient client = httpClientFactory.CreateClient("MangoApi");
                HttpRequestMessage message = new();

                message.Headers.Add("Accept", "application/json");
                //todo; Token
                message.RequestUri = new Uri(request.Url);

                if (request.Data is not null)
                    message.Content = new StringContent(JsonConvert.SerializeObject(request.Data));

                HttpResponseMessage? apiResponse = null;

                message.Method = request.ApiType switch
                {
                    ApiTypeEnum.GET => HttpMethod.Get,
                    ApiTypeEnum.POST => HttpMethod.Post,
                    ApiTypeEnum.PUT => HttpMethod.Put,
                    ApiTypeEnum.DELETE => HttpMethod.Delete,
                    _ => HttpMethod.Get
                };

                apiResponse = await client.SendAsync(message);

                switch (apiResponse.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        result.SetError(localizer["Not Found"]);
                        break;
                    case HttpStatusCode.BadRequest:
                        result.SetFail(localizer["Bad Request"]);
                        break;
                    case HttpStatusCode.Forbidden:
                        result.SetFail(localizer["Access Denied"]);
                        break;
                    case HttpStatusCode.Unauthorized:
                        result.SetFail(localizer["Unauthorized"]);
                        break;
                    case HttpStatusCode.InternalServerError:
                        result.SetError(localizer["Internal Server Error"]);
                        break;
                    default:
                        var apiContent = await apiResponse.Content.ReadAsStringAsync();
                        var model = JsonConvert.DeserializeObject<T>(apiContent);
                        result.SetSuccess(model, localizer["Request Success"]);
                        break;
                }

            }
            catch (Exception e)
            {
                result.SetError(e.Message);
                logger.LogError(20000,$"Error In BaseService: {e.Message}");
            }
            return result;
        }

        private void ResultProccess(HttpResponseMessage apiResponse)
        {


        }
    }
}
