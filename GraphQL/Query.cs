using System.Linq;
using GraphQL.Data;
using GraphQL.Models;
using HotChocolate;

namespace GraphQL.GraphQL
{
    public class Query
    {
        // Injeção de dependência via método do Hot Chocolate
        // É exibido como schema Platform (omitindo o Get por padrão) na interface web
        public IQueryable<Platform> GetPlatform([Service] AppDbContext context)
        {
            return context.Platforms;
        }
    }
}