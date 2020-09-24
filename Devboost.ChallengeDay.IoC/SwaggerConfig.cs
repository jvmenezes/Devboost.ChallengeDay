using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Diagnostics.CodeAnalysis;

namespace Devboost.ChallengeDay.IoC
{
    public static class SwaggerConfig
    {
        [ExcludeFromCodeCoverage]
        public static IServiceCollection SwaggerAdd(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Challenge Day",
                    Version = "v1"
                });
            });


            return services;
        }
        public static IApplicationBuilder SwaggerAdd(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Challenge Day"); });

            return app;
        }
    }

}
