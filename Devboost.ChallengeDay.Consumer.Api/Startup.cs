using Devboost.ChallengeDay.Consumer.Api.Extensions;
using Devboost.ChallengeDay.Consumer.Domain.Interfaces;
using Devboost.ChallengeDay.Shared.Domain.Constants;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Devboost.ChallengeDay.Consumer.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddHangfireService();
            services.AddSingletonServices(Configuration);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            var recurringJobManager = app.ApplicationServices.GetService<IRecurringJobManager>();
            var processorQueue = app.ApplicationServices.GetService<IProcessorQueue>();

            recurringJobManager.AddOrUpdate(Guid.NewGuid().ToString(), () => processorQueue.ProcessorQueueAsync(ProjectConsts.TOPIC_NAME), "*/5 * * * * *");

        }
    }
}
