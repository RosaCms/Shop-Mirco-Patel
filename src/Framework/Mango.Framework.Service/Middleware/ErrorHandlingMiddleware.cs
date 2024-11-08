using Mango.Framework.Core.Enums;
using Mango.Framework.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace Mango.Framework.Service.Middleware
{
    public class ErrorHandlingMiddleware(RequestDelegate next,ILogger<ErrorHandlingMiddleware> logger)
    {

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context); 
            }
            catch (Exception ex)
            {
                await Task.FromResult(HandleExceptionAsync(context, ex));
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = HttpStatusCode.InternalServerError;
            var msg = (string.IsNullOrWhiteSpace(exception.Message)) ? $"خطایی در سیسم رخ داده است" : exception.Message;
            var errorResponse = new ResponseApi
            {
                Message = msg,
                Data =null ,
                ResultStatus = ResultStatusEnum.Error,
                HasError = true
            };
            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = "application/json";
            var json = JsonSerializer.Serialize(errorResponse);
            return context.Response.WriteAsync(json);
        }
    }
}
