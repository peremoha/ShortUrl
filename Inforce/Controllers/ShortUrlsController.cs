using Inforce.Interfaces;
using Inforce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inforce.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShortUrlsController: Controller
    {
        private readonly IUrlService _urlService;

        public ShortUrlsController(IUrlService urlService)
        {
            _urlService = urlService;
        }

        [HttpGet("GetUrls")]
        public async Task<ActionResult<IEnumerable<ShortUrlResponse>>> GetAll()
        {
            var urls = await _urlService.GetAllShortUrl();
            return Ok(urls.Select(url => new ShortUrlResponse
            {
                CreatedBy = url.CreatedBy,
                CreatedDate = url.CreatedDate,
                FullUrl = url.FullUrl,
                Id = url.Id
            }));
        }

        [HttpGet("GetUrls/{id}")]
        public async Task<ShortUrlResponse> GetOne(Guid id)
        {
            var url = await _urlService.GetShortUrl(id);
            var shortUrl = new ShortUrlResponse
            {
                CreatedBy = url.CreatedBy,
                CreatedDate = url.CreatedDate,
                FullUrl = url.FullUrl,
                Id = id
            };
            return shortUrl;
        }

        [HttpPost("AddUrls")]
        public async Task<ActionResult<ShortUrlResponse>> CreateUrl(ShortUrlRequest shortUrl)
        {
            var createdBy = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Login").Value;
            if (createdBy == null)
            {
                return BadRequest();
            }

            try
            {
                var url = await _urlService.AddShortUrl(shortUrl.FullUrl, createdBy);
                var response = new ShortUrlResponse
                {
                    CreatedBy = url.CreatedBy,
                    CreatedDate = url.CreatedDate,
                    FullUrl = url.FullUrl,
                    Id = url.Id
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpDelete("deleteUrls/{id}")]
        public async Task<ShortUrl> DeleteType(Guid id)
        {
            var deletedUrl = await _urlService.DeleteShortUrl(id);
            return deletedUrl;
        }

        [HttpPut("updateUrls/{id}")]
        public async Task UpdateUrls(Guid id, ShortUrl shortUrl)
        {
            await _urlService.UpdateShortUrl();
        }
    }
}
