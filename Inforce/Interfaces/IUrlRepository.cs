using Inforce.Models;

namespace Inforce.Interfaces
{
    public interface IUrlRepository
    {
        public Task<ShortUrl> AddShortUrl(ShortUrl shortUrl);
        public Task<ShortUrl> GetShortUrl(Guid Id);
        public Task<IEnumerable<ShortUrl>> GetAllShortUrl();
        public Task<ShortUrl> DeleteShortUrl(Guid id);
        public Task UpdateShortUrl();
    }
}
