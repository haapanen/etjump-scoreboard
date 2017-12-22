using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using ETJump.Scoreboard.Api.Filters;
using ETJump.Scoreboard.Api.IoC;
using ETJump.Scoreboard.Api.Middleware;
using ETJump.Scoreboard.Core.IoC;
using ETJump.Scoreboard.SqlAdapter.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace ETJump.Scoreboard.Api
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
            services.AddMvc(opt => { opt.Filters.Add(typeof(ModelStateFilter)); });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v2", new Info {Title = "ETJump timeruns API v2", Version = "v2"});
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new ApiModule());
            builder.RegisterModule(new CoreModule());
            builder.RegisterModule(new SqlModule(@"F:\ETJump\et\etjump\timeruns.db"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<ExceptionMiddleware>();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ETJump timeruns API v2");
            });
        }
    }
}
