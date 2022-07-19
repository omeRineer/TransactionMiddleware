using Microsoft.AspNetCore.Builder;
using TransactionMiddleware.Middlewares;

namespace TransactionMiddleware.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomTransaction(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<TransactionMiddleware.Middlewares.TransactionMiddleware>();
        }
    }
}
