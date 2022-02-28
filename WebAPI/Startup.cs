using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Services;

using WebAPI.Persistence;
using WebAPI.Repositories;
using WebAPI.Contexts;
using Microsoft.EntityFrameworkCore;

using AutoMapper;
using WebAPI.Interfaces;

namespace WebAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // Ajonaika kutsuu t‰t‰ menetelm‰‰. K‰yt‰ t‰t‰ menetelm‰‰ palveluiden lis‰‰miseen s‰ilˆˆn.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<AppDbContext>(options => {
                options.UseInMemoryDatabase("webapi-memory");
            });

            // depedendy injektion
            // services.AddDbContext<BarDBContext>(options =>
            // options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));

            services.AddScoped<IForceTypeRepository, ForceTypeRepository>();
            services.AddScoped<IForceTypeService, ForceTypeService>();
            services.AddScoped<IResultRepository, ResultRepository>();
            services.AddScoped<IResultService, ResultService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
            });

            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // Ajonaika kutsuu t‰t‰ menetelm‰‰. K‰yt‰ t‰t‰ tapaa m‰‰ritt‰‰ksesi HTTP-pyyntˆputken.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
