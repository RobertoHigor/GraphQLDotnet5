using System.ComponentModel.DataAnnotations;

namespace GraphQL.Models
{
    public class Command
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string HowTo { get; set; }
        [Required]
        public string CommandLine { get; set; }
        
        // Pertence a uma platform
        [Required]
        public int PlatformId { get; set; }
        public Platform Platform { get; set; }
    }
}