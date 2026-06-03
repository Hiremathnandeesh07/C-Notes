//This middleware provides global exception handling.
//Instead of writing try-catch blocks in every controller, service, and repository,
//any unhandled exception that reaches this middleware is caught and converted into a
//proper HTTP response.

using Microsoft.Data.SqlClient;

namespace Hospital_Management_Web_Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (SqlException ex)
            {
                context.Response.Clear();
                /*context.Response.Clear() is used to remove anything that has 
                already been written to the response before 
                sending your error response.*/
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsJsonAsync(new
                {
                    Message = ex.Message
                });
            }
            catch (Exception)
            {
                context.Response.Clear();
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsJsonAsync(new
                {
                    Message = "An unexpected error occurred."
                });
            }
        }
    }
}