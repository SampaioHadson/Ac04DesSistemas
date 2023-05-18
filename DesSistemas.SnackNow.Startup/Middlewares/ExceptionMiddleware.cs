using DesSistemas.SnackNow.Startup.Exceptions;
using Microsoft.AspNetCore.Http;

namespace DesSistemas.SnackNow.Startup.Middlewares
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
            catch (HttpExceptionBase ex)
            {
                context.Response.StatusCode = ex.StatusCode;
                await context.Response.WriteAsJsonAsync(new
                {
                    Erro = ex.Message,
                });
            }
            catch (Exception e)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(new
                {
                    Erro = "Ocorreu um erro inesperado no servidor",
                });
            }
        }
    }
}
