using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AspDotNetCore_WebAPIs.MiddleWare
{
    public class GlobalExceptionHandlingMiddleWare(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
               await HandlingException(context, ex);
            }
        }


        // This method handles exceptions in an ASP.NET Core HTTP context
        public static async Task HandlingException(HttpContext context, Exception ex)
        {
            // Set the HTTP response status code to 500 (Internal Server Error)
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            // Create a ProblemDetails object to provide structured error information
            var problemDetails = new ProblemDetails
            {
                Status = (int)HttpStatusCode.InternalServerError, // HTTP status code
                Title = "Internal Server Error", // Short title for the error
                Detail = "An internal server error to help the client understand the issue.", // Detailed message
                Type = "https://httpstatuses.com/500", // Link to more info about status code 500
                Instance = context.Request.Path // Path of the request that caused the error
            };

            // Write the ProblemDetails object to the HTTP response in JSON format
            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }
}
