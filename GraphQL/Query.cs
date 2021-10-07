using System.Linq;
using GraphQL.Data;
using GraphQL.Models;
using HotChocolate;
using HotChocolate.Data;

namespace GraphQL.GraphQL
{
    public class Query
    {
        // Injeção de dependência via método do Hot Chocolate
        // É exibido como schema Platform (omitindo o Get por padrão) na interface web
        [UseDbContext(typeof(AppDbContext))] // Diz para obter o dbContext do pool
        //[UseProjection] // Para buscar objetos filhos. Não é necessário caso tenha um resolver
        [UseFiltering]
        [UseSorting]
        public IQueryable<Platform> GetPlatform([ScopedService] AppDbContext context)
        {
            return context.Platforms;
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Command> GetCommand([ScopedService] AppDbContext context)
        {
            return context.Commands;
        }
    }
}