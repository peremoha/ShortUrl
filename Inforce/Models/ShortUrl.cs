using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace Inforce.Models
{
    public class ShortUrl
    {
        public Guid Id { get; set; }
        [Required]
        public string FullUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }

    }
}
