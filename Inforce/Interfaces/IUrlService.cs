using Inforce.Models;

namespace Inforce.Interfaces
{
    public interface IUrlService
    {
        public Task<ShortUrl> AddShortUrl(string fullUrl, string createdBy);
        public Task<ShortUrl> GetShortUrl(Guid id);
        public Task<IEnumerable<ShortUrl>> GetAllShortUrl();
        public Task<ShortUrl> DeleteShortUrl(Guid id);
        public Task UpdateShortUrl();
    }
}
