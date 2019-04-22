using IsoCRM_Integrador_de_APIs.APIs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace IsoCRM_Integrador_de_APIs.Utils
{
    public static class GlobalExceptionHandler
    {
        public static void UseGlobalExceptionHandler(this IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    IExceptionHandlerFeature exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (exceptionHandlerFeature != null)
                    {
                        Exception ex = exceptionHandlerFeature.Error;

                        ILogger logger = loggerFactory.CreateLogger("GlobalExceptionHandler");
                        logger.LogError($"Unexpected error: {ex}");

                        if (ex is ApiResponseException)
                        {
                            HandleApiResponseException(context, ex as ApiResponseException);
                        }
                        else
                        {
                            HandleExceptionInternal(context, ex);
                        }
                    }
                    // Adicionado apenas para suprimir o aviso CS1998 que é gerado na linha "builder.Run(async context =>"
                    await Task.FromResult(0);
                });
            });
        }

        private static void HandleApiResponseException(HttpContext context, ApiResponseException ex)
        {
            HttpStatusCode status = HttpStatusCode.BadRequest;
            string message = "Ocorreu um erro por parte da API alvo.";
            object details = ex.apiErrorPayload;
            SendResponse(context, status, message, details);
        }

        private static void HandleExceptionInternal(HttpContext context, Exception ex)
        {
            HttpStatusCode status = HttpStatusCode.InternalServerError;
            string message = ex.Message;
            object details = ex.StackTrace;
            SendResponse(context, status, message, details);
        }

        private async static void SendResponse(HttpContext context, HttpStatusCode status, string message, object details)
        {
            context.Response.StatusCode = (int)status;
            context.Response.ContentType = "application/json";
            object json = new
            {
                Message = message,
                Details = details
            };
            await context.Response.WriteAsync(JsonConvert.SerializeObject(json));
        }
    }
}
