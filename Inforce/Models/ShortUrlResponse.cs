using System.ComponentModel.DataAnnotations;

namespace Inforce.Models
{
    public class ShortUrlResponse
    {
        public Guid Id { get; set; }
        public string FullUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ShortUrl { get { return "https//sho.rt/" + Id; } }
    }
}
