using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Transactions;

namespace TransactionMiddleware.Middlewares
{
    public class TransactionMiddleware
    {
        RequestDelegate _next;
        public TransactionMiddleware(RequestDelegate next)
        {
            _next=next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            using (TransactionScope transaction=new TransactionScope())
            {
                try
                {
                    await _next(context);
                    transaction.Complete();
                }
                catch (System.Exception)
                {
                    transaction.Dispose();
                }
            }
            
        }
    }
}
