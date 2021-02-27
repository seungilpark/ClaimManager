using ClaimManager.Api.Extensions;
using ClaimManager.Api.Middlewares;
using ClaimManager.Application.Extensions;
using ClaimManager.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ClaimManager.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration _configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationLayer();
            services.AddContextInfrastructure(_configuration);
            services.AddPersistenceContexts(_configuration);
            services.AddRepositories();
            services.AddSharedInfrastructure(_configuration);
            services.AddEssentials();
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy(name: "BlazorPolicy",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                        .AllowAnyMethod();
                        // builder.WithOrigins("domain1", "domain2",...).WithMethod("GET",""...);
                    });
            });
            services.AddMvc(o =>
            {
                //var policy = new AuthorizationPolicyBuilder()
                    //.RequireAuthenticatedUser()
                    //.Build();
                //o.Filters.Add(new AuthorizeFilter(policy));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.ConfigureSwagger();
            app.UseHttpsRedirection();
            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseRouting();
            app.UseCors("BlazorPolicy");
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}