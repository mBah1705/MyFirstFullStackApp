using AutoMapper;
using Business;
using Common.Utility;
using Dal.DBContext;
using Dal.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<ISampleBusiness, SampleBusiness>();
            services.AddScoped<ISampleRepository, SampleRepository>();
            services.AddScoped<IMyFirstFullStackApp_DEVContext, MyFirstFullStackApp_DEVContext>();
            services.AddScoped<ICandidatesBusiness, CandidatesBusiness>();
            services.AddScoped<ICandidatesRepository, CandidatesRepository>();

            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new Info {
                    Title = "My First FullStack App Core API",
                    Description = "The interface to test the solution's APIs",
                    Version = "0.0.1"
                });
            });

            var autoMapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile(new ApplicationProfile());
            });
            IMapper mapper = autoMapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint("v1/swagger.json", "Core API");
            });
        }
    }
}
