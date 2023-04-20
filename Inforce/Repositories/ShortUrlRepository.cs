using Inforce.Interfaces;
using Inforce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Inforce.Repositories
{
    public class ShortUrlRepository: IUrlRepository
    {
        private readonly ShortenerContext _context;

        public ShortUrlRepository(ShortenerContext context)
        {
            _context = context;
        }

        public async Task<ShortUrl> AddShortUrl(ShortUrl shortUrl)
        {
            var url = await _context.ShortUrls.AddAsync(shortUrl);
            _context.SaveChanges();
            return url.Entity;
        }
        public async Task<ShortUrl> GetShortUrl(Guid Id)
        {
            var url = await _context.ShortUrls.FirstOrDefaultAsync(x => x.Id == Id);
            return url;
        }
        public async Task<IEnumerable<ShortUrl>> GetAllShortUrl()
        {
            return _context.ShortUrls;
        }
        public async Task<ShortUrl> DeleteShortUrl(Guid Id)
        {
            var url = await _context.ShortUrls.FirstOrDefaultAsync(x => x.Id == Id);
            var deletedUrl = _context.ShortUrls.Remove(url);
            await _context.SaveChangesAsync();
            return deletedUrl.Entity;
        }
        public async Task UpdateShortUrl()
        {

        }
    }
}
