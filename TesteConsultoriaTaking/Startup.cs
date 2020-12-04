using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using TesteConsultoriaTaking.Helpers;
using TesteConsultoriaTaking.Migrations;

namespace TesteConsultoriaTaking
{
    public class Startup
    {
        private IServiceCollection _services;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _services = services;

            InjecaoDependencia.AdicionarContexto(services, Configuration);

            //services.AddDbContext<DatabaseContext>(options => 
            //    options.UseSqlServer(Configuration.GetConnectionString("TesteConsultoriaTaking")));

            services.AddControllers().AddJsonOptions(jsonOptions => {
                jsonOptions.JsonSerializerOptions.IgnoreNullValues = true;
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
                
            });

            InjecaoDependencia.InjetarRepositorios(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            InjecaoDependencia.InstanciarRepositorios(_services, serviceProvider, Configuration);
        }
    }
}
