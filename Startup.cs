using GraphQL.Data;
using GraphQL.GraphQL;
using GraphQL.Server.Ui.Voyager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GraphQL
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<AppDbContext>(opt 
            // Para multi-thread, cria instâncias de dbcontext de um tipo onde instâncias são chamadas para reuso
            services.AddPooledDbContextFactory<AppDbContext>(opt
                => opt.UseSqlServer(_configuration.GetConnectionString("SQL_SERVER")));

            // Injeção de dependência do GraphQL
            services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddProjections(); // Para ativar UseProjection
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // Adicionando GraphQL na pipeline (endpoint /GraphQL)
                endpoints.MapGraphQL();
            });

            // Biblioteca para exibir visualmente um mapa das schemas
            app.UseGraphQLVoyager("/graphql-voyager");
        }
    }
}
