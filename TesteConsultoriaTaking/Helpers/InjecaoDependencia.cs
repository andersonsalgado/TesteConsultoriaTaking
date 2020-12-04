using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using TesteConsultoriaTaking.Migrations;
using Microsoft.EntityFrameworkCore;
using TesteConsultoriaTaking.Repository;
using TesteConsultoriaTaking.Shared;
using TesteConsultoriaTaking.Models;
using System;

namespace TesteConsultoriaTaking.Helpers
{
    public static class InjecaoDependencia
    {
        public static void AdicionarContexto(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("TesteConsultoriaTaking")));
        }

        public static void InjetarRepositorios(IServiceCollection services)
        {
            services.AddTransient(typeof(ClienteRepository));

        }

        public static void InstanciarRepositorios(IServiceCollection services, IServiceProvider serviceProvider, IConfiguration Configuration)
        {
            //services.AddTransient(typeof(IAplicacaoInterface<ClienteModel>), typeof(ClienteRepository));

            var databaseContext = ((DatabaseContext)serviceProvider.GetRequiredService<DatabaseContext>());

            var clienteRepository = (ClienteRepository)serviceProvider.GetService<ClienteRepository>();
            clienteRepository = new ClienteRepository(databaseContext);

        }


    }
}
