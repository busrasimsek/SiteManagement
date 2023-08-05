using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SiteManagement.Core.Response;
using System.Net;

namespace SiteManagement.Core.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var response = new ResponseItemManager();
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                // Log the exception (you can use a logging library of your choice)
                // Logger.Log(ex);

                // Set the response status code
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                // Create an error response object
                var errorResponse = response.Error(MessageCodesEnum.Error, ex.Message);

                // Serialize the error response to JSON
                var jsonResponse = JsonConvert.SerializeObject(errorResponse);

                // Write the JSON response to the client
                await context.Response.WriteAsync(jsonResponse);
            }
        }
        //public async Task InvokeAsync(HttpContext httpContext)
        //{
        //    try
        //    {
        //        await _next(httpContext);
        //    }
        //    catch (Exception ex)
        //    {
        //        await HandleExceptionAsync(httpContext, ex);
        //    }
        //}

        //private static Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        //{

        //    httpContext.Response.ContentType = "application/json";
        //    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        //    var now = DateTime.UtcNow;
        //    return httpContext.Response.WriteAsync(BaseResponseModel.BadRequest(ex.Message, httpContext.TraceIdentifier).ToString());
        //}
    }

}
