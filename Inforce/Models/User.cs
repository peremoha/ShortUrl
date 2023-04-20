using System.ComponentModel.DataAnnotations;

namespace Inforce.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string PasswordHash { get; set; }

        public int RoleId { get; set; }
        public Role? Role { get; set; }
        public List<ShortUrl> ShortUrls { get; set; } = new();
    }
}
