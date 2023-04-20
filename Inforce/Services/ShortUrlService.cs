using Inforce.Interfaces;
using Inforce.Models;
using Inforce.Repositories;

namespace Inforce.Services
{
    public class ShortUrlService: IUrlService
    {
        private readonly IUrlRepository _urlRepository;

        public ShortUrlService(IUrlRepository urlRepository)
        {
            _urlRepository = urlRepository;
        }

        public async Task<ShortUrl> AddShortUrl(string fullUrl, string createdBy)
        {
            var shortUrl = new ShortUrl { FullUrl = fullUrl, CreatedBy = createdBy, CreatedDate = DateTime.Now };
            var url = await _urlRepository.AddShortUrl(shortUrl);
            return url;
        }
        public async Task<ShortUrl> GetShortUrl(Guid id)
        {
            var url = await _urlRepository.GetShortUrl(id);
            return url;
        }
        public async Task<IEnumerable<ShortUrl>> GetAllShortUrl()
        {
            var urls = await _urlRepository.GetAllShortUrl();
            return urls.ToList();
        }
        public async Task<ShortUrl> DeleteShortUrl(Guid id)
        {
            var deletedUrl = await _urlRepository.DeleteShortUrl(id);
            return deletedUrl;
        }
        public async Task UpdateShortUrl()
        {
            _urlRepository.UpdateShortUrl();
        }
    }
}
