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
    }
}
