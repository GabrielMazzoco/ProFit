using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ProFIt.Api.Configs
{
    public class GestaoEventosExceptionHandler
    {
        public async Task Invoke(HttpContext context)
        {
            const HttpStatusCode httpStatus = HttpStatusCode.InternalServerError;

            var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
            if (exception != null)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)httpStatus;

                await context.Response.WriteAsync(JsonConvert.SerializeObject(new
                {
                    ErroMessage = $"{exception.Message} - {exception.InnerException} - {exception.StackTrace}",
                    Status = httpStatus
                }));
            }
        }
    }
}
