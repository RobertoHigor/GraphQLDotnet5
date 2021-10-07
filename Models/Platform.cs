using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GraphQL.Models
{
    public class Platform
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string LicenseKey { get; set; }

        // Pode ter um ou mais commands
        public ICollection<Command> Commands { get; set; } //= new List<Command>();
    }
}