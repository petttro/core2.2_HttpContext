using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Sample.Api.Middleware;
using Sample.Api.Models;

namespace Sample.Api
{
    
    public class Startup
    {
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            ConfigureDefaultServices(services);
            services.AddOptions();

            services.AddTransient<ConfigurationResponse>(serviceProvider =>
            {
                var httpContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
                if (httpContextAccessor?.HttpContext == null)
                {
                    // !!! it should be null
                    throw new Exception("Why HttpContext is null?");
                }

                return new ConfigurationResponse();
            });

            return services.BuildServiceProvider();
        }

        public void ConfigureDefaultServices(IServiceCollection services)
        {
            services.AddLogging();
            services.AddCors();
            services.AddMvc();
            services.AddMvcCore().AddApiExplorer();
            services.AddHttpContextAccessor();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDefaultFiles();
            app.UseMiddleware<DistinctTraceIdMiddleware>();
            app.UseCors("CorsPolicy");
            app.UseMvc();
            app.UseAuthentication();
        }
    }
}
