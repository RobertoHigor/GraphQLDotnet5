using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HotChocolate;

namespace GraphQL.Models
{
    // Descrições comentadas pois foram extraídas para PlatformType (Abstraindo da model)
    //[GraphQLDescription("Represents any software or service that has a command line interface")]
    public class Platform
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        //[GraphQLDescription("Represents a purchased, valid license for the platform")]
        public string LicenseKey { get; set; }

        // Pode ter um ou mais commands
        public ICollection<Command> Commands { get; set; } //= new List<Command>();
    }
}