using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Sample.Api.Middleware
{
    public class DistinctTraceIdMiddleware
    {
        private readonly RequestDelegate _next; public DistinctTraceIdMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            // !!! OVERIDE cause of HttpContex = null !!!
            context.TraceIdentifier = Guid.NewGuid().ToString("N");
            await _next(context);
        }
    }
}
