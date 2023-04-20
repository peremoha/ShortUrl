using System.ComponentModel.DataAnnotations;

namespace Inforce.Models
{
    public class Role
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string? Name { get; set; }
        public List<User> Users { get; set; } = new();
    }
}
